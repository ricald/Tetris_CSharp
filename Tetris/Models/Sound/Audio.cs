namespace Tetris
{
    using System;
    using System.Diagnostics;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Audioクラス
    /// </summary>
    public class Audio
    {
        /// <summary>再生スレッド</summary>
        private Thread playThread;

        /// <summary>ファイル名</summary>
        private string fileName;
        
        /// <summary>スレッド</summary>
        private bool shouldStop;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="fileName">ファイル名</param>
        public Audio(string fileName)
        {
            this.playThread = null;
            this.fileName = fileName;
            this.shouldStop = false;
        }

        /// <summary>
        /// デストラクタ
        /// </summary>
        ~Audio()
        {
            this.Stop();
        }

        /// <summary>
        /// 再生終了イベント
        /// </summary>
        public event EventHandler<EventArgs> Ending;

        /// <summary>
        /// 再生
        /// </summary>
        public void Play()
        {
            if (this.playThread != null)
            {
                this.shouldStop = true;
                this.playThread.Join();
                this.playThread = null;
            }

            this.shouldStop = false;
            this.playThread = new Thread(this.Run);
            this.playThread.SetApartmentState(ApartmentState.STA);
            this.playThread.Start();
        }

        /// <summary>
        /// 停止
        /// </summary>
        public void Stop()
        {
            if (this.playThread != null)
            {
                this.shouldStop = true;
                this.playThread.Join();
                this.playThread = null;
            }
        }

        /// <summary>
        /// 再生終了イベント
        /// </summary>
        /// <param name="e">イベント引数</param>
        protected void OnEnding(EventArgs e)
        {
            if (this.Ending != null)
            {
                this.Ending(this, e);
            }
        }

        /// <summary>
        /// MCI（メディアコントロールインターフェイス）デバイスへ、コマンド文字列を送信します。コマンドの送信先となるデバイスも、コマンド文字列の中で指定します。
        /// </summary>
        /// <param name="command">MCI コマンド文字列を保持している、NULL で終わる文字列へのポインタを指定します。コマンド文字列の詳細については、MSDN ライブラリの「Command Strings」(英語) を参照してください。</param>
        /// <param name="buffer">1 個のバッファへのポインタを指定します。関数から制御が返ると、このバッファに、情報が格納されます。すべてのコマンドが情報が格納するわけではありません。この情報が不要な場合、NULL を指定してください。</param>
        private void MciSendString(string command, StringBuilder buffer)
        {
            var ret = NativeMethods.MciSendString(command, buffer, buffer?.Capacity ?? 0, IntPtr.Zero);
            System.Diagnostics.Debug.WriteLine($"NativeMethods.MciSendString({command}, {buffer}, {buffer?.Capacity ?? 0}, {IntPtr.Zero})");
            if (ret != 0)
            {
                throw new InvalidOperationException("mciSendStringメソッドが0以外の戻り値を返しました。戻り値:" + ret.ToString());
            }
        }

        /// <summary>
        /// 再生スレッド処理
        /// </summary>
        private void Run()
        {
            // オープン(open)
            this.MciSendString("open \"" + this.fileName + "\" type mpegvideo", null);

            try
            {
                // 再生(play)
                this.MciSendString("play \"" + this.fileName + "\"", null);

                try
                {
                    // 再生が停止するまでの監視(status)
                    while (this.shouldStop == false)
                    {
                        StringBuilder sb = new StringBuilder(256);
                        this.MciSendString("status \"" + this.fileName + "\" mode", sb);
                        if (sb.ToString() == "stopped")
                        {
                            break;
                        }

                        Thread.Sleep(10);
                    }
                }
                finally
                {
                    // 停止(stop)
                    this.MciSendString("stop \"" + this.fileName + "\"", null);
                }
            }
            finally
            {
                // クローズ(close)
                this.MciSendString("close \"" + this.fileName + "\"", null);
            }

            // 再生終了イベント
            if (this.shouldStop == false)
            {
                Task.Run(() => this.OnEnding(new EventArgs()));
            }
        }

        /// <summary>
        /// NativeMethodsクラス
        /// </summary>
        internal class NativeMethods
        {
            /// <summary>
            /// MCI（メディアコントロールインターフェイス）デバイスへ、コマンド文字列を送信します。コマンドの送信先となるデバイスも、コマンド文字列の中で指定します。
            /// </summary>
            /// <param name="command">MCI コマンド文字列を保持している、NULL で終わる文字列へのポインタを指定します。コマンド文字列の詳細については、MSDN ライブラリの「Command Strings」(英語) を参照してください。</param>
            /// <param name="buffer">1 個のバッファへのポインタを指定します。関数から制御が返ると、このバッファに、情報が格納されます。すべてのコマンドが情報が格納するわけではありません。この情報が不要な場合、NULL を指定してください。</param>
            /// <param name="bufferSize">lpszReturnString パラメータが指すバッファのサイズを、文字単位で指定します。</param>
            /// <param name="hwndCallback">コマンド文字列で "notify" フラグを指定した場合、コールバックウィンドウのハンドルを指定します。</param>
            /// <returns>関数が成功すると、0 が返ります。関数が失敗すると、0 以外の値が返ります。この戻り値は DWORD 型であり、下位ワード（low-order word）はエラーコードです。エラーコードがデバイス固有のものであった場合、戻り値の上位ワード（high-order word）はドライバの識別子です。それ以外の場合、上位ワードは 0 です。戻り値のリストについては、MSDN ライブラリの「MCIERR Return Values」を参照してください。</returns>
            [System.Runtime.InteropServices.DllImport("winmm.dll", EntryPoint = "mciSendString")]
            public static extern int MciSendString(string command, StringBuilder buffer, int bufferSize, IntPtr hwndCallback);
        }
    }
}
