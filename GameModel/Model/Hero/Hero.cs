﻿using System.Drawing;
using GameModel.Model.DirEntity;

namespace GameModel.Model.DirHero
{
    public class Hero : IEntity, IPVP
    {
        public string Name { get; set; }
        public Size Size { get; }
        public Manipulator Manipulator { get; }
        public Point Location { get; private set; }
        public double DownVelocity { get; set; }
        public double UpVelocity { get; set; }
        public double HorizontalVelocity { get; set; }
        public int Health { get; private set; }
        public int Attack { get; set; }
        public int Cooldown { get; set; }

        public Hero(string name, Size size, Point location, int health, int attack)
        {
            Name = name;
            Size = size;
            Location = location;
            Health = health;
            Attack = attack;
            Manipulator = new Manipulator(this);
        }
        
        public void Move(Point dPoint)
        {
            Location = new Point(Location.X + dPoint.X, Location.Y + dPoint.Y);
        }
        
        public bool IsActive() => Health > 0;
        
        public void GetDamage(int damage)
        {
            Health -= damage;
        }

        public void TryAttack()
        {
        }
    }
}