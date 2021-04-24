﻿using System;
using System.Collections.Generic;
using System.Drawing;
using GameModel.Model;
using GameModel.Model.DirEntity;

namespace Game002.Controllers.Drawers
{
    public static class MapDrawer
    {
        private static readonly string Path = System.IO.Path.GetFullPath(@"..\..\..\Sprites\StandartBlocks\");
        private static readonly Dictionary<int, Action<Map, Graphics, int, int>> DrawingBlocks =
            new Dictionary<int, Action<Map, Graphics, int, int>>
            {
                {-2, (map, g, x, y) => 
                    g.DrawRectangle(new Pen(Color.Chartreuse), x, y, map.CellSize, map.CellSize)}, // CellSheet
                {-1, (map, g, x, y) => 
                    g.DrawImage(new Bitmap(System.IO.Path.GetFullPath(@"..\..\..\Sprites\Backgrounds\BackgroundCity.png")),
                        new Rectangle(new Point(x, y), new Size(map.Width, map.Height)),
                        0, 0, 800, 600, GraphicsUnit.Pixel)}, // Background
                {0, (map, g, x, y) => {}}, // Empty area
                {1, (map, g, x, y) => 
                    g.DrawImage(new Bitmap(Path + @"EarthMiddle.png"),
                new Rectangle(new Point(x, y), new Size(map.CellSize, map.CellSize)),
                    0, 0, 128, 128, GraphicsUnit.Pixel)}, // EarthMiddle.png
                {2, (map, g, x, y) => 
                    g.DrawImage(new Bitmap(Path + @"EarthDown.png"),
                    new Rectangle(new Point(x, y), new Size(map.CellSize, map.CellSize)),
                    0, 0, 128, 128, GraphicsUnit.Pixel)}, // EarthDown
                {3, (map, g, x, y) => 
                    g.DrawImage(new Bitmap(Path + @"RightPlatform.png"),
                    new Rectangle(new Point(x, y), new Size(map.CellSize, map.CellSize)),
                    0, 0, 128, 128,
                    GraphicsUnit.Pixel)}, // RightPlatform
                {4, (map, g, x, y) => 
                    g.DrawImage(new Bitmap(Path + @"MiddlePlatform.png"),
                    new Rectangle(new Point(x, y), new Size(map.CellSize, map.CellSize)),
                    0, 0, 128, 128,
                    GraphicsUnit.Pixel)}, // MiddlePlatform,
                {5, (map, g, x, y) => 
                    g.DrawImage(new Bitmap(Path + @"LeftPlatform.png"),
                    new Rectangle(new Point(x, y), new Size(map.CellSize, map.CellSize)),
                    0, 0, 96, 128,
                    GraphicsUnit.Pixel)} // LeftPlatform
            };

        public static void DrawMap(Graphics g, Map map)
        {
            DrawingBlocks[-1](map, g, 0, 0);
            for(var i = 0; i < map.BlockMap.GetLength(0); i++)
                for (var j = 0; j < map.BlockMap.GetLength(1); j++)
                    DrawingBlocks[map.BlockMap[i, j]](map, g, i * map.CellSize, j * map.CellSize);
        }
        
        public static void DrawSheetMap(Graphics g, Map map)
        {
            for(var i = 0; i < map.BlockMap.GetLength(0); i++)
            for (var j = 0; j < map.BlockMap.GetLength(1); j++)
                DrawingBlocks[-2](map, g, i * map.CellSize, j * map.CellSize);
        }
    }
}