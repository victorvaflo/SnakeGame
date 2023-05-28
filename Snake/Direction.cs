using System;
using System.Collections.Generic;

namespace Snake
{
    public class Direction
    {
        public readonly static Direction Left = new Direction(0, -1);
        public readonly static Direction Right = new Direction(0, 1);
        public readonly static Direction Up = new Direction(-1, 0);
        public readonly static Direction Down = new Direction(1, 0);
        public int RowOffset { get; }
        public int ColOffset { get; }
        private Direction(int rowOffset, int colOffset)
        {
            RowOffset = rowOffset;
            ColOffset = colOffset;
        }

        //Opposite : Returns the direction's opposite row and column offset
        public Direction Opposite()
        {
            return new Direction(-RowOffset, -ColOffset);
        }



        //Override equals and get hashcode so the direction class can be
        //used as the key in the dictionary
        //Press ctrl + .
        //Choose generate equals
        //Choose get Hash Code
        //Choose both offsets and Generate operators

        public override bool Equals(object obj)
        {
            return obj is Direction direction &&
                   RowOffset == direction.RowOffset &&
                   ColOffset == direction.ColOffset;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(RowOffset, ColOffset);
        }

        public static bool operator ==(Direction left, Direction right)
        {
            return EqualityComparer<Direction>.Default.Equals(left, right);
        }

        public static bool operator !=(Direction left, Direction right)
        {
            return !(left == right);
        }
    }
}
