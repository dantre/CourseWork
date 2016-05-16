﻿using System;
using System.Collections.Generic;
using GeneticProgramming.Simulator.Maps;
using GeneticProgramming.Simulator.Modules;
using GeneticProgramming.Simulator.Strategies;

namespace GeneticProgramming.Simulator.Tanks
{
    public class Tank 
    {
        public Coord Coord { get; set; }
        public Direction Direction { get; set; }
        public Strategy Strategy { get; set; }

        public bool IsAlive = true;
        public int viewArea;
        public int fireArea;
        public int ammunition;

        public static bool operator ==(Tank firstTank, Tank secondTank)
        {
            return firstTank?.Coord == secondTank?.Coord;
        }

        public static bool operator !=(Tank firstTank, Tank secondTank)
        {
            return !(firstTank == secondTank);
        }

        protected bool Equals(Tank other)
        {
            return Equals(Coord, other.Coord) && Direction == other.Direction;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Tank)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Coord != null ? Coord.GetHashCode() : 0) * 397) ^ (int)Direction;
            }
        }
    }
}
