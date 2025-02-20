﻿using Domain.Core;
using Domain.Core.Exceptions;

namespace Domain.Entities
{
    public sealed class PointOfInterest : Entity
    {
        public string Name { get; set; } = string.Empty;
        public int X { get; set; }
        public int Y { get; set; }

        public PointOfInterest(string name, int x, int y)
        {
            if (x < 0 || y < 0) throw new NotValidDataException("The provided coordinates XY must be non-negative integers");
            if (string.IsNullOrEmpty(name)) throw new NotValidDataException("A Point of Interest must have a NAME");

            Name = name;
            X = x;
            Y = y;
        }
    }
}
