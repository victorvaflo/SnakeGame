using System;
using System.Collections.Generic;

namespace Snake
{
    //This class will store the current state of the game
    public class GameState
    {
        public int Rows { get; }
        public int Cols { get; }

        public GridValue[,] Grid { get; }
        public Direction Dir { get; private set; }
        public int Score { get; private set; }
        public bool GameOver { get; private set; }

        private readonly LinkedList<Position> snakePositions = new LinkedList<Position>();
        private readonly Random random = new Random();

        public GameState(int rows, int cols)
        {
            Rows = rows;
            Cols = cols;
            Grid = new GridValue[rows, cols];
            Dir = Direction.Right;

            AddSnake();
            AddFood();
        }

        //Add the position of the snake in the grid, where we want it to be.
        private void AddSnake()
        {

        }

        //Add a method that will return all empty grid positions.
        private IEnumerable<Position> EmptyPositions()
        {

        }

        //First, create a list of empty positions.
        //Second, pick a random position in the empty positions and set food.
        private void AddFood()
        {

        }

        //Helper method, that will return the position of the snakes head
        public Position HeadPosition()
        {
            return snakePositions.First.Value;
        }

        //Helper method, that will return the position of the snakes tail
        public Position TailPosition()
        {
            return snakePositions.Last.Value;
        }

        public IEnumerable<Position> SnakePositions()
        {
            return snakePositions;
        }

        //Method to modify the snake.
        //Adds the given position to the front of the snake, making it the new head.
        private void AddHead(Position pos)
        {

        }
        //Method to modify the snake.
        //Removes the tail of the snake.
        private void RemoveTail()
        {

        }

        public void ChangeDirection(Direction dir)
        {

        }


    }
}
