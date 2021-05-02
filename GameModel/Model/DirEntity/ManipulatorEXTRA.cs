﻿using System;
using System.Collections.Generic;
using System.Drawing;
using GameModel.Model.DirEntity;

namespace GameModel.Model.DirHero
{
    public partial class Manipulator
    {
        public Point PreDownOrUpMove(Point dp, Map map) //TODO Testing
        {
            if (dp.X != 0)
                throw new ArgumentException("The X coordinate in PreDownOrUpMove method is not zero, but should");
            if (Math.Abs(dp.Y) > map.CellSize)
                throw new ArgumentException("Change in Y must not exceed the block height");
            if (dp.Y == 0)
                return new Point(0, 0);
            var nLPoint = new Point(
                entity.Location.X,
                 entity.Location.Y + dp.Y + (dp.Y > 0 ? entity.Size.Height : 0));
            for (var i = 0; i < entity.Size.Width; i++)
            {
                var cLPoint = new Point(nLPoint.X + i, nLPoint.Y);
                if (!map.IsBound(cLPoint))
                    return new Point(0, dp.Y > 0 ? map.Size.Height - nLPoint.Y + dp.Y : -entity.Location.Y);
                if (map.IsBlock(cLPoint))
                    return new Point(
                        0,
                        dp.Y > 0 ?
                            cLPoint.Y / map.CellSize * map.CellSize - nLPoint.Y + dp.Y :
                            cLPoint.Y / map.CellSize * map.CellSize - entity.Location.Y + map.CellSize);
            }
            return dp;
        }
        
        public Point PreRightOrLeftMove(Point dp, Map map)
        {
            if (dp.Y != 0)
                throw new ArgumentException("The Y coordinate in PreRightOrLeftMove method is not zero, but should");
            if (Math.Abs(dp.X) > map.CellSize)
                throw new ArgumentException("Change in X must not exceed the block width");
            if (dp.X == 0)
                return new Point(0, 0);
            var nLPoint = new Point(
                entity.Location.X + dp.X + (dp.X > 0 ? entity.Size.Width : 0), 
                entity.Location.Y);
            for (var i = 0; i < entity.Size.Height; i++)
            {
                var cLPoint = new Point(nLPoint.X, nLPoint.Y + i);
                if (!map.IsBound(cLPoint))
                    return new Point(
                        dp.X > 0 ?
                            map.Size.Width - entity.Location.X - entity.Size.Width :
                            -entity.Location.X,
                        0);
                if (map.IsBlock(cLPoint))
                    return new Point(
                        dp.X > 0 ?
                            cLPoint.X / map.CellSize * map.CellSize - entity.Location.X - entity.Size.Width :
                            cLPoint.X / map.CellSize * map.CellSize - entity.Location.X + map.CellSize,
                           0);
            }
            return dp;
        }

        private int ticks; 

        public void TryDamage(IEnumerable<IEntity> entities) //TODO Tests
        {
            if (((IDangerous) entity).IsReadyToAttack &&
                ticks % ((IDangerous)entity).Cooldown == 0)
                entities.ForEach(it =>
                {
                    var r1 = new Rectangle(it.Location, it.Size);
                    var r2 = new Rectangle(
                        new Point(
                            entity.Direction == Direction.Right ?
                                entity.Location.X + entity.Size.Width / 2 :
                                entity.Location.X - 25, entity.Location.Y),
                        entity.Size);
                    if (HelpMethods.AreIntersected(r1, r2) && ((IDangerous) entity).IsReadyToAttack)
                    {
                        DoDamage(it as IDangerous);
                        ((IDangerous) entity).IsReadyToAttack = false;
                        ticks++;
                    }
                });
            else if (ticks > 0)
                ticks = (1 + ticks) % ((IDangerous)entity).Cooldown;
            ((IDangerous) entity).IsReadyToAttack = false;
        }


        private void DoDamage(IDangerous e)
        {
            ticks = 0;
            e.GetDamage(((IDangerous) entity).Attack);
        }
    }
}