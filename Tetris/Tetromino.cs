//-----------------------------------------------------------------------
// <copyright file="Tetromino.cs" company="CompanyName">
//     Copyright © 2015 Ricald All Rights Reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Tetris
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;

    /// <summary>
    /// テトロミノクラス
    /// </summary>
    public class Tetromino : MovableModel
    {
        /// <summary>ブロック形定義</summary>
        private static Dictionary<TetrominoType, List<Block>> blockShapeDictionary = new Dictionary<TetrominoType, List<Block>>
        {
            { TetrominoType.I, new List<Block> { { new Block(new Point(-2,  0), BlockType.I) },  { new Block(new Point(-1,  0), BlockType.I) },  { new Block(new Point(0,  0), BlockType.I) },  { new Block(new Point(1,  0), BlockType.I) }, } },
            { TetrominoType.O, new List<Block> { { new Block(new Point(0,  -1), BlockType.O) },  { new Block(new Point(0,   0), BlockType.O) },  { new Block(new Point(1, -1), BlockType.O) },  { new Block(new Point(1,  0), BlockType.O) }, } },
            { TetrominoType.J, new List<Block> { { new Block(new Point(-1, -1), BlockType.J) },  { new Block(new Point(-1,  0), BlockType.J) },  { new Block(new Point(0,  0), BlockType.J) },  { new Block(new Point(1,  0), BlockType.J) }, } },
            { TetrominoType.Z, new List<Block> { { new Block(new Point(-1, -1), BlockType.Z) },  { new Block(new Point(0,  -1), BlockType.Z) },  { new Block(new Point(0,  0), BlockType.Z) },  { new Block(new Point(1,  0), BlockType.Z) }, } },
            { TetrominoType.L, new List<Block> { { new Block(new Point(-1,  0), BlockType.L) },  { new Block(new Point(0,   0), BlockType.L) },  { new Block(new Point(1,  0), BlockType.L) },  { new Block(new Point(1, -1), BlockType.L) }, } },
            { TetrominoType.S, new List<Block> { { new Block(new Point(-1,  1), BlockType.S) },  { new Block(new Point(0,   0), BlockType.S) },  { new Block(new Point(0,  1), BlockType.S) },  { new Block(new Point(1,  0), BlockType.S) }, } },
            { TetrominoType.T, new List<Block> { { new Block(new Point(-1,  0), BlockType.T) },  { new Block(new Point(0,   0), BlockType.T) },  { new Block(new Point(0, -1), BlockType.T) },  { new Block(new Point(1,  0), BlockType.T) }, } },
            { TetrominoType.H, new List<Block> { { new Block(new Point(-2,  0), BlockType.H1) }, { new Block(new Point(-1,  0), BlockType.H2) }, { new Block(new Point(0,  0), BlockType.H3) }, { new Block(new Point(1,  0), BlockType.H4) }, } },
            { TetrominoType.K, new List<Block> { { new Block(new Point(0,   0), BlockType.H1) }, } },
            { TetrominoType.P, new List<Block> { { new Block(new Point(0,   0), BlockType.H3) }, } },
        };

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="tetrominoType">ブロック種別</param>
        /// <param name="blockPosition">ブロック位置</param>
        public Tetromino(TetrominoType tetrominoType, Point blockPosition)
        {
            this.TetrominoType = tetrominoType;
            this.X = blockPosition.X;
            this.Y = blockPosition.Y;
            this.Blocks = Tetromino.blockShapeDictionary[tetrominoType];
        }

        /// <summary>テトロミノ種別</summary>
        public TetrominoType TetrominoType { get; set; }

        /// <summary>ブロック位置</summary>
        public Point Position { get; set; }

        /// <summary>ブロック達</summary>
        public List<Block> Blocks { get; set; }

        /// <summary>
        /// テトロミノ取得
        /// </summary>
        /// <returns>テトロミノ</returns>
        public static Tetromino Get()
        {
            TetrominoType result;
            do
            {
                var random = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);
                result = Enum.GetValues(typeof(TetrominoType))
                    .Cast<TetrominoType>()
                    .OrderBy(c => random.Next())
                    .FirstOrDefault();
            }
            while (result != TetrominoType.I &&
                result != TetrominoType.O &&
                result != TetrominoType.J &&
                result != TetrominoType.Z &&
                result != TetrominoType.L &&
                result != TetrominoType.S &&
                result != TetrominoType.T);

            return new Tetromino(result, new Point(4, 2));
        }

        /// <summary>
        /// テトロミノ取得(拡張)
        /// </summary>
        /// <returns>テトロミノ</returns>
        public static Tetromino GetEx()
        {
            var random = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);
            var result = Enum.GetValues(typeof(TetrominoType))
                .Cast<TetrominoType>()
                .OrderBy(c => random.Next())
                .FirstOrDefault();

            return new Tetromino(result, new Point(4, 2));
        }

        /// <summary>
        /// 左回りに回転
        /// </summary>
        public override void RotateLeft()
        {
            foreach (var block in this.Blocks)
            {
                block.RotateLeft();
            }
        }

        /// <summary>
        /// 右回りに回転
        /// </summary>
        public override void RotateRight()
        {
            foreach (var block in this.Blocks)
            {
                block.RotateRight();
            }
        }
    }
}
