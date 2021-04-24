﻿using System.Drawing;
using System.IO;
using GameModel.Model.DirHero;

namespace Game002.Controllers.Drawers
{
    public static class HeroDrawer
    {
        public static void DrawSheetHero(Graphics g, Hero hero) =>
            g.DrawRectangle(new Pen(Color.Blue), new Rectangle(hero.Location, hero.Size));
        
        public static void DrawHero(Graphics g, Hero hero)
        {
            g.DrawImage(
                new Bitmap(Path.GetFullPath(@"..\..\..\Sprites\MainCharacter\Naruto128x128.png")),
                new Rectangle(hero.Location, hero.Size));
            g.FillRectangle(
                new SolidBrush(Color.Red), 
                new Rectangle(new Point(10, 10), new Size(hero.GetHealth() * 3, 20)));
        }
    }
}