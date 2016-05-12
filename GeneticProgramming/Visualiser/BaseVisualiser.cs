using System;
using System.Collections.Generic;
using System.Linq;
using GeneticProgramming.Extensions;
using GeneticProgramming.Simulator.Maps;
using GeneticProgramming.Simulator.Tanks;

namespace GeneticProgramming.Visualiser
{
    abstract class BaseVisualiser
    {
        protected string[] GetField(Map map)
        {
            string[] result = GenerateEmptyFieldWithBorder(map.Width, map.Height);

            result[map.StartCoord.Y] = result[map.StartCoord.Y].ReplaceIndex(map.StartCoord.X, 'S');
            result [map.FinishCoord.Y] = result[map.FinishCoord.Y].ReplaceIndex(map.FinishCoord.X, 'F');

            foreach (var obstacle in map.Obstacles)
            {
                result[obstacle.Y] = result[obstacle.Y].ReplaceIndex(obstacle.X, '#');
            }
            foreach (var enemy in map.Enemies)
            {
                result[enemy.Coord.Y] = result[enemy.Coord.Y].ReplaceIndex(enemy.Coord.X, GetEnemyChar(enemy.Direction));
            }

            result[map.Tank.Coord.Y] = result[map.Tank.Coord.Y].ReplaceIndex(map.Tank.Coord.X, GetTankChar(map.Tank.Direction));

            return result;
        }

        protected string[] GenerateEmptyFieldWithBorder(int width, int height)
        {
            string[] result = new string[height + 2];
            string emptyLine = String.Join("", Enumerable.Repeat(" ", width));
            result[0] = String.Concat(Enumerable.Repeat("#", width + 2));
            for (int i = 1; i <= height; i++)
                result[i] = String.Concat("#", emptyLine, "#");
            result[height + 1] = String.Concat(Enumerable.Repeat("#", width + 2));
            return result;
        }

        public abstract void Visualise(Map map);

        #region CharsMethods

        private char GetTankChar(Direction direction)
        {
            return TankChars[direction];
        }

        private char GetEnemyChar(Direction direction)
        {
            return EnemyChars[direction];
        }

        private static readonly Dictionary<Direction, char> TankChars = new Dictionary<Direction, char>
        {
            { Direction.Up, '8'},
            { Direction.Left, '4'},
            { Direction.Right, '6'},
            { Direction.Down, '2'}
        };

        private static readonly Dictionary<Direction, char> EnemyChars = new Dictionary<Direction, char>
        {
            { Direction.Up, 'I' },
            { Direction.Left, 'J'},
            { Direction.Down, 'K'},
            { Direction.Right, 'L'}
        };
        #endregion
    }
}