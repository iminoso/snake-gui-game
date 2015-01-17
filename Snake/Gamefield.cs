using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Snake
{
    class Gamefield
    {
        //Enum to detect if snake is moving
        public enum SnakeMoving
        {
            Moving = 1,
            NotMoving = 2,
        }

        //Variables fields for width and height
        public const int Height = 150;
        public const int Width = 300;
        public const int squareSize = 10;
        public static SnakeMoving MovingCheck = SnakeMoving.Moving;

        //2d array to store squares
        public static Square[,] Grid = new Square[Width, Height];

        public static Graphics DrawingSurface { set; get; }

        public static bool IsEmpty(int x, int y)
        {
            //this method returns if a square is occupied in the grid at location x,y
            if (y < 0 || y >= Height || x < 0 || x >= Width)
            {
                return false;
            }
            else
            {
                //check if SquareGrid contains a square at x,y                
                return Grid[x, y] == null;

            }
        }

        public static void StopSquare(Square square, int x, int y)
        {
            //when the block stops each square will be saved in it's location of SquareGrid
            Grid[x, y] = square;
            //set snake moving to not moving
            MovingCheck = SnakeMoving.NotMoving;

        }

        

    }
}
