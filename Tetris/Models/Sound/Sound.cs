//-----------------------------------------------------------------------
// <copyright file="Sound.cs" company="CompanyName">
//     Copyright © 2015 Ricald All Rights Reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Tetris
{
    using System;
    using System.Collections.Generic;

    /// <summary>音声ID</summary>
    public enum SoundId
    {
        /// <summary>タイトル</summary>
        Title,

        /// <summary>ゲーム1</summary>
        Game1,

        /// <summary>ゲーム2</summary>
        Game2,

        /// <summary>ゲームオーバー</summary>
        GameOver,

        /// <summary>置き音</summary>
        Put,

        /// <summary>消し音</summary>
        Erase,
    }

    /// <summary>音声種別</summary>
    public enum SoundType
    {
        /// <summary>BGM(ループ再生)</summary>
        Bgm,

        /// <summary>効果音(1度だけ再生)</summary>
        SoundEffect,
    }

    /// <summary>
    /// サウンドクラス
    /// </summary>
    public class Sound
    {
        /// <summary>唯一のインスタンス</summary>
        private static Sound instance;

        /// <summary>音声テーブル</summary>
        private Dictionary<SoundId, SoundInfo> soundTable = new Dictionary<SoundId, SoundInfo>
        {
            { SoundId.Title,    new SoundInfo(SoundType.Bgm,            new Audio(@"Title.mp3")) },
            { SoundId.Game1,    new SoundInfo(SoundType.Bgm,            new Audio(@"Game1.mp3")) },
            { SoundId.Game2,    new SoundInfo(SoundType.Bgm,            new Audio(@"Game2.mp3")) },
            { SoundId.GameOver, new SoundInfo(SoundType.SoundEffect,    new Audio(@"GameOver.mp3")) },
            { SoundId.Put,      new SoundInfo(SoundType.SoundEffect,    new Audio(@"Put.mp3")) },
            { SoundId.Erase,    new SoundInfo(SoundType.SoundEffect,    new Audio(@"Erase.mp3")) },
        };

        /// <summary>唯一のインスタンス</summary>
        public static Sound Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Sound();
                }

                return instance;
            }
        }

        /// <summary>
        /// 再生
        /// </summary>
        /// <param name="playSoundId">再生する音声ID</param>
        /// <returns>true：成功、false：失敗</returns>
        public bool Play(SoundId playSoundId)
        {
            bool ret = false;

            if (this.soundTable.ContainsKey(playSoundId))
            {
                // 音声情報を取得する
                SoundInfo playSoundInfo = this.soundTable[playSoundId];

                // 音声種別がBGMなら他のBGMを停止する
                if (playSoundInfo.Type == SoundType.Bgm)
                {
                    foreach (var row in this.soundTable)
                    {
                        SoundId soundId = row.Key;
                        SoundInfo soundInfo = row.Value;

                        if (soundInfo.Type == SoundType.Bgm)
                        {
                            soundInfo.Audio.Stop();
                        }
                    }
                }

                // 音声を再生する
                playSoundInfo.Audio.Play();

                // 処理結果＝成功
                ret = true;
            }

            return ret;
        }

        /// <summary>
        /// 停止
        /// </summary>
        /// <param name="stopSoundId">停止する音声ID</param>
        /// <returns>true：成功、false：失敗</returns>
        public bool Stop(SoundId stopSoundId)
        {
            bool ret = false;

            if (this.soundTable.ContainsKey(stopSoundId))
            {
                // 音声情報を取得する
                SoundInfo stopSoundInfo = this.soundTable[stopSoundId];

                // 音声を停止する
                stopSoundInfo.Audio.Stop();

                // 処理結果＝成功
                ret = true;
            }

            return ret;
        }

        /// <summary>
        /// 全ての音声を停止
        /// </summary>
        /// <returns>true：成功、false：失敗</returns>
        public bool Stop()
        {
            foreach (var row in this.soundTable)
            {
                SoundId soundId = row.Key;
                SoundInfo soundInfo = row.Value;

                // 音声を停止する
                soundInfo.Audio.Stop();
            }

            return true;
        }

        /// <summary>
        /// 音声情報クラス
        /// </summary>
        public class SoundInfo
        {
            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="type">音声種別</param>
            /// <param name="audio">オーディオクラス</param>
            public SoundInfo(SoundType type, Audio audio)
            {
                this.Type = type;
                this.Audio = audio;
                this.Audio.Ending += this.Audio_Ending;
            }

            /// <summary>音声種別</summary>
            public SoundType Type { get; set; }

            /// <summary>オーディオクラス</summary>
            public Audio Audio { get; set; }

            /// <summary>
            /// オーディオ終了時イベントハンドラ
            /// </summary>
            /// <param name="sender">通知元オブジェクト</param>
            /// <param name="e">イベント引数</param>
            private void Audio_Ending(object sender, EventArgs e)
            {
                Audio audio = sender as Audio;
                if (audio != null)
                {
                    // 音声を停止
                    audio.Stop();

                    // BGMならループ再生
                    if (this.Type == SoundType.Bgm)
                    {
                        audio.Play();
                    }
                }
            }
        }
    }
}
