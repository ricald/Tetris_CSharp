//-----------------------------------------------------------------------
// <copyright file="RecordData.cs" company="CompanyName">
//     Copyright © 2015 Ricald All Rights Reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Tetris
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// 記録データクラス
    /// </summary>
    public class RecordData
    {
        /// <summary>唯一のインスタンス</summary>
        private static RecordData instance;

        /// <summary>記録データリスト</summary>
        private List<RecordDataInfo> recordDataInfoList;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        private RecordData()
        {
            this.recordDataInfoList = new List<RecordDataInfo>();
        }

        /// <summary>唯一のインスタンス</summary>
        public static RecordData Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RecordData();
                }

                return instance;
            }
        }

        /// <summary>記録データリスト</summary>
        public List<RecordDataInfo> RecordDataInfoList
        {
            get
            {
                return this.recordDataInfoList;
            }
        }

        /// <summary>
        /// 記録更新したか
        /// </summary>
        /// <param name="ownScore">自身のスコア</param>
        /// <returns>true：記録更新した、false：記録更新していない</returns>
        public bool IsNewRecord(int ownScore)
        {
            bool ret = false;

            // 自身のスコアがランキング内にあるかをチェック
            for (int index = 0; index < this.recordDataInfoList.Count; index++)
            {
                if (this.recordDataInfoList[index].Score <= ownScore)
                {
                    // 自身のスコアがランキング内にあれば記録更新とする
                    ret = true;
                    return ret;
                }
            }

            return ret;
        }

        /// <summary>
        /// セーブ
        /// </summary>
        /// <param name="name">名前</param>
        /// <param name="score">スコア</param>
        /// <returns>true：成功、false：失敗</returns>
        public bool Save(string name, int score)
        {
            bool ret = false;

            // 自身のスコアがランキング内にあるかをチェック
            for (int index = 0; index < this.recordDataInfoList.Count; index++)
            {
                if (this.recordDataInfoList[index].Score <= score)
                {
                    // 自身のスコアがランキング内にあればスコアを更新する
                    this.recordDataInfoList.Insert(index, new RecordDataInfo(name, score));
                    break;
                }
            }

            // スコアで10件を超えた分は削除する
            while (this.recordDataInfoList.Count > 10)
            {
                this.recordDataInfoList.RemoveAt(this.recordDataInfoList.Count - 1);
            }

            // スコアをセーブする
            string fileName = @"record.xml";

            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(List<RecordDataInfo>));
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(fileName, false, new System.Text.UTF8Encoding(false)))
            {
                serializer.Serialize(sw, this.recordDataInfoList);
            }

            return ret;
        }

        /// <summary>
        /// ロード
        /// </summary>
        /// <returns>true：成功、false：失敗</returns>
        public bool Load()
        {
            bool ret = false;

            // スコアをロードする
            string fileName = @"record.xml";

            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(List<RecordDataInfo>));

            if (System.IO.File.Exists(fileName))
            {
                using (System.IO.StreamReader sr = new System.IO.StreamReader(fileName, new System.Text.UTF8Encoding(false)))
                {
                    this.recordDataInfoList = (List<RecordDataInfo>)serializer.Deserialize(sr);
                }
            }
            else
            {
                for (int index = 0; index < 10; index++)
                {
                    this.recordDataInfoList.Add(new RecordDataInfo());
                }
            }

            // スコアの降順でソート
            this.recordDataInfoList.Sort((a, b) => b.Score - a.Score);

            return ret;
        }

        /// <summary>
        /// 記録データクラス
        /// </summary>
        public class RecordDataInfo
        {
            /// <summary>
            /// コンストラクタ
            /// </summary>
            public RecordDataInfo()
            {
                this.Name = "名無しさん";
                this.Score = 0;
            }

            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="name">名前</param>
            /// <param name="score">スコア</param>
            public RecordDataInfo(string name, int score)
            {
                this.Name = name;
                this.Score = score;
            }

            /// <summary>名前</summary>
            public string Name { get; set; }

            /// <summary>スコア</summary>
            public int Score { get; set; }
        }
    }
}
