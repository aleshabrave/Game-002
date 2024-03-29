﻿using System.Drawing;
using GameModel.Model.Mobs;

namespace TestGame002.Controllers.Drawers
{
    public static class HeroDrawer
    {
        public static void DrawHero(Graphics g, Hero hero)
        {
            if (hero.IsActive)
                MapDrawer.DrawEntity(g, hero);
            MapDrawer.DrawHealthBar(g, hero.CombatManipulator, new Point(10, 10), new Size(hero.CombatManipulator.Health * 3, 20));
            MapDrawer.DrawStaminaBar(g, hero.CombatManipulator, new Point(10, 30), new Size(hero.CombatManipulator.Stamina * 3, 20));
        }
    }
}