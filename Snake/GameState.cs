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
        //15 x 15 grid

        private void AddSnake()
        {
            int r = Rows / 2;

            for (int c = 1; c <= 3; c++)
            {
                Grid[r, c] = GridValue.Snake;
                snakePositions.AddFirst(new Position(r, c));
            }
        }

        //Add a method that will return all empty grid positions.
        //Loops through all R and C.
        private IEnumerable<Position> EmptyPositions()
        {
            for (int r = 0; r < Rows; r++)
            {
                for (int c = 0; c < Cols; c++)
                {
                    if (Grid[r, c] == GridValue.Empty)
                    {
                        yield return new Position(r, c);
                    }
                }
            }
        }

        //First, create a list of empty positions.
        //Second, pick a random position in the empty positions and set food.
        private void AddFood()
        {
            List<Position> empty = new List<Position>(EmptyPositions());

            //If there are no empty positions.
            //Else, the game would crash
            if (empty.Count == 0)
            {
                return;
            }
            //Picks an empty position at random
            Position pos = empty[random.Next(empty.Count)];
            Grid[pos.Row, pos.Col] = GridValue.Food;
        }

        //Method that will return the position of the snakes head
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
            snakePositions.AddFirst(pos);
            Grid[pos.Row, pos.Col] = GridValue.Snake;
        }
        //Method to modify the snake.
        //Removes the tail of the snake.
        private void RemoveTail()
        {
            Position tail = snakePositions.Last.Value;
            // Makes the last position in the list Empty.
            Grid[tail.Row, tail.Col] = GridValue.Empty;
            snakePositions.RemoveLast();
        }

        public void ChangeDirection(Direction dir)
        {
            Dir = dir;
        }

        //If we reach a wall 
        private bool OutsideGrid(Position pos)
        {
            return pos.Row < 0 || pos.Row >= Rows || pos.Col < 0 || pos.Col >= Cols;
        }

        //Takes a position as parameter and returns what the snake would hit if it moves there
        private GridValue WillHit(Position newHeadPos)
        {
            //If the new position is outside the grid, we will return our special grid value named Outside
            if (OutsideGrid(newHeadPos))
            {
                return GridValue.Outside;
            }

            //Tests if the new current head position is the same as the new current tail position
            if (newHeadPos == TailPosition())
            {
                return GridValue.Empty;
            }

            return Grid[newHeadPos.Row, newHeadPos.Col];
        }

        //Moves the snake one step in the current direction
        public void Move()
        {
            Position newHeadPos = HeadPosition().Translate(Dir);
            //Check what the head will hit using the WillHit Method
            GridValue hit = WillHit(newHeadPos);

            if (hit == GridValue.Outside || hit == GridValue.Snake)
            {
                GameOver = true;
            }
            //If the snake moves into an empty position
            //Removes the current tail, and add a new head.
            else if (hit == GridValue.Empty)
            {
                RemoveTail();
                AddHead(newHeadPos);
            }
            //If the snake hits a food
            //Dont remove the tail, but add a new head
            else if (hit == GridValue.Food)
            {
                AddHead(newHeadPos);
                Score++;
                AddFood();
            }
        }


    }
}
