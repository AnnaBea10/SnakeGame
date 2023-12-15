using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class GameState
    {
        public int Rows { get; }
        public int Cols { get; }
        public Grid[,] Grid { get; }
        public Direction Dir { get; private set; }
        public int Score { get; private set; }
        public bool GameOver { get; private set; }

        private readonly LinkedList<Position> snakePosition = new LinkedList<Position>();
        private readonly Random random = new Random();

        public GameState(int rows, int cols)
        {
            Rows = rows;
            Cols = cols;
            Grid = new Grid[rows, cols];
            Dir = Direction.Right;

            AddSnake();
        }

        private void AddSnake()
        {
            int r = Rows / 2;

            for(int c = 1; c <= 3; c++)
            {
                Grid[r, c] = Grid.Snake;
                snakePosition.AddFirst(new Position(r, c));
            }
        }

        private IEnumerable<Position> EmptyPosition()
        {
            for(int r = 0; r < Rows; r++)
            {
                for(int c = 0; c < Cols; c++)
                {
                    if (Grid[r, c] != Grid.Empty)
                    {
                        continue;
                    }
                    yield return new Position(r, c);
                }
            }
        }

        private void AddFood()
        {
            List<Position> empty = new List<Position>(EmptyPosition());
            if (empty.Count == 0)
            {
                return;
            }
            Position pos = empty[random.Next(empty.Count)];
            Grid[pos.Row, pos.Col] = SnakeGame.Grid.Food;
        }

    }
}
