﻿using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using GameModel.Model.DirEntity;
using GameModel.Model.Mobs;

namespace GameModel.Model
{
    public class Level
    {
        public readonly Hero CurrentHero;
        public readonly int TimerInterval;
        
        private readonly List<Map> _maps;
        
        private int _indexMap;
        
        public Level(Hero hero, List<Map> maps, int t)
        {
            CurrentHero = hero;
            _maps = maps;
            TimerInterval = t;
        }

        public void OnTimerTickEvents()
        {
            if (CheckOnGameOver()) 
                return;
            if (TryNextMap())
                CurrentHero.SetLocation(new Point(100, 100));
            UpdateLevelPhysics();
            CurrentHero.Manipulator.TryDamage(GetCurrentMap().GetActiveMobs());
            MobsController.MakeMoveAndAttack(GetCurrentMap(), CurrentHero);
        }

        private bool CheckOnGameOver()
        {
            return !CurrentHero.IsActive();
        }
        
        private void UpdateLevelPhysics()
        {
            Physics.UpdateMap(GetCurrentMap());
            var entityList = GetCurrentMap().MobList
                .Where(it => it.IsActive())
                .Select(it => it as IEntity)
                .ToList();
            entityList.Add(CurrentHero);
            Physics.TryMoveForEntity(entityList, TimerInterval);
        }

        private bool TryNextMap()
        {
            if (GetCurrentMap().MobList.Any(it => it.IsActive()) || _indexMap + 1 >= _maps.Count) 
                return false;
            _indexMap++;
            return true;
        }
        
        public Map GetCurrentMap() => _maps[_indexMap];
    }
}