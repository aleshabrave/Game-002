﻿using System.Collections.Generic;
using System.Drawing;
using GameModel.Model;
using GameModel.Model.DirEntity;
using GameModel.Model.DirHero;

namespace Game002.Levels
{
    public static class TestLevel
    {
        public static Level GetTestLevel0()
        {
            var naruto = new Hero(new Size(64, 64), new Point(0, 100));
            var mobTestList = new List<IEntity>();
            var testMap1 = new Map(15, 20, mobTestList)
            {
                BlockMap = new [,] {
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 1, 2, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 1, 2, 2, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 1, 2, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 1, 2, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 1, 2, 2, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 1, 2, 2, 2, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 1, 2, 2, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 1, 2, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2, 2, 2, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2}
                }
            };
            var testMap2 = new Map(15, 20, mobTestList)
            {
                BlockMap = new [,] {
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 1, 2, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 1, 2, 2, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 1, 2, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 1, 2, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 1, 2, 2, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 1, 2, 2, 2, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 1, 2, 2, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 1, 2, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2}
                }
            };
            return new Level(naruto, new List<Map> {testMap1, testMap2}, 5);
        }
    }
}