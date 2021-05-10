﻿using System.Drawing;

namespace GameModel.Model.DirEntity
{
    public interface IEntity
    {
        public string Name { get; }
        public Size Size { get; }
        public Manipulator Manipulator { get; }
        public Point Location { get; }
        public double DownVelocity { get; set; }
        public double UpVelocity { get; set; }
        public double HorizontalVelocity { get; set; }
        public void Move(Point dp);
        public bool IsActive();
        public Direction Direction { get; set; }
    }
}