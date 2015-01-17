using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Snake
{
    class Snake
    {
        //snanke counter to increment snake array
        public static int snakeCounter = 1;
        //location counter to keep track of next locations for added squares
        public static int[] locationCounter = new int[2];          

        //Direction enum
        public enum Direction
        {
            Down = 1,
            Right = 2,
            Up = 3,
            Left = 4,
        }

        //Detection for manual collision in movement methods
        public enum ManualDetection
        {
            Detection = 1,
            noDetection = 2,
        }

        //Properites
        public static ManualDetection DetectionCheck = ManualDetection.noDetection;
        public static Direction currentDirection { get; set; }
        public static Square[] snake = new Square[100];

        private int squareSize = Gamefield.squareSize;

        //Constructor
        public Snake(Point Location)
        {
            snake[0] = new Square(new Size(squareSize, squareSize), Color.Black, new Point(Location.X, Location.Y));

        }

        //Adds squares to snake
        public void addSnake(Point Location)
        {
            snake[snakeCounter] = new Square(new Size(squareSize, squareSize), Color.Black, new Point(Location.X, Location.Y));
            snake[snakeCounter].Show();
            snakeCounter += 1;
        }

        //Show snake
        public void Show()
        {

            snake[0].Show();
        }

        //Hide Snake
        public void Hide()
        {

            snake[0].Hide();
        }


        //snake movements
        public bool Down()
        {
            if (Gamefield.IsEmpty(snake[0].Location.X, snake[0].Location.Y + 10))
            {
                //Set location counter to location of head before movement
                locationCounter[0] = snake[0].Location.X;
                locationCounter[1] = snake[0].Location.Y;

                //hide first
                Hide();

                //move down and show
                snake[0].Location = new Point(snake[0].Location.X, snake[0].Location.Y + 10);
                Show();

                //Follow snake if the counter snake has incremented
                if (snakeCounter > 1)
                {
                    followSnake();
                }

                //Set manual detection to detection if the location = objective after movement
                if (Snake.snake[0].Location.X == Objective.objective.Location.X && Snake.snake[0].Location.Y == Objective.objective.Location.Y)
                {
                    DetectionCheck = ManualDetection.Detection;
                }

                return true;
            }
            else
            {
                //Stop snake;
                Gamefield.StopSquare(snake[0], snake[0].Location.X / squareSize, snake[0].Location.Y / squareSize);

                return false;
            }
            
        }

        public bool Right()
        {
            if (Gamefield.IsEmpty(snake[0].Location.X + 10, snake[0].Location.Y))
            {
                //Set location counter to location of head before movement
                locationCounter[0] = snake[0].Location.X;
                locationCounter[1] = snake[0].Location.Y;

                //hide first
                Hide();

                //move down and show
                snake[0].Location = new Point(snake[0].Location.X + 10, snake[0].Location.Y);
                Show();

                //Follow snake if the counter snake has incremented
                if (snakeCounter > 1)
                {
                    followSnake();
                }

                //Set manual detection to detection if the location = objective after movement
                if (Snake.snake[0].Location.X == Objective.objective.Location.X && Snake.snake[0].Location.Y == Objective.objective.Location.Y)
                {
                    DetectionCheck = ManualDetection.Detection;
                }

                return true;
            }
            else
            {
                //Stop snake[0];
                Gamefield.StopSquare(snake[0], snake[0].Location.X / squareSize, snake[0].Location.Y / squareSize);

                return false;
            }

        }

        public bool Up()
        {
            if (Gamefield.IsEmpty(snake[0].Location.X, snake[0].Location.Y - 10))
            {
                //Set location counter to location of head before movement
                locationCounter[0] = snake[0].Location.X;
                locationCounter[1] = snake[0].Location.Y;

                //hide first
                Hide();

                //move down and show
                snake[0].Location = new Point(snake[0].Location.X, snake[0].Location.Y - 10);
                Show();

                //Follow snake if the counter snake has incremented
                if (snakeCounter > 1)
                {
                    followSnake();
                }

                //Set manual detection to detection if the location = objective after movement
                if (Snake.snake[0].Location.X == Objective.objective.Location.X && Snake.snake[0].Location.Y == Objective.objective.Location.Y)
                {
                    DetectionCheck = ManualDetection.Detection;
                }

                return true;
            }
            else
            {
                //Stop snake;
                Gamefield.StopSquare(snake[0], snake[0].Location.X / squareSize, snake[0].Location.Y / squareSize);

                return false;
            }

        }

        public bool Left()
        {
            if (Gamefield.IsEmpty(snake[0].Location.X - 10, snake[0].Location.Y))
            {
                //Set location counter to location of head before movement
                locationCounter[0] = snake[0].Location.X;
                locationCounter[1] = snake[0].Location.Y;

                //hide first
                Hide();

                //move down and show
                snake[0].Location = new Point(snake[0].Location.X - 10, snake[0].Location.Y);
                Show();

                //Follow snake if the counter snake has incremented
                if (snakeCounter > 1)
                {
                    followSnake();
                }

                //Set manual detection to detection if the location = objective after movement
                if (Snake.snake[0].Location.X == Objective.objective.Location.X && Snake.snake[0].Location.Y == Objective.objective.Location.Y)
                {
                    DetectionCheck = ManualDetection.Detection;
                }

                return true;
            }
            else
            {
                //Stop snake;
                Gamefield.StopSquare(snake[0], snake[0].Location.X / squareSize, snake[0].Location.Y / squareSize);

                return false;
            }

        }

        //Method to follow the snake
        public void followSnake()
        {
            //set temp locations
            int tempLocationX;
            int tempLocationY;

            //loop through snake array
            for (int i = 1; i < snakeCounter; i++)
            {
                //set temp location to location of square before movement
                tempLocationX = snake[i].Location.X;
                tempLocationY = snake[i].Location.Y;

                //Hide snake
                snake[i].Hide();
                //move to location counter (follows the location of previous square)
                snake[i].Location = new Point(locationCounter[0], locationCounter[1]);
                //Show snake
                snake[i].Show();

                //set location counter to the temp location
                locationCounter[0] = tempLocationX;
                locationCounter[1] = tempLocationY;
            }

        }

        //Collision method
        public void Collision()
        {
            for (int i = 0; i < Snake.snake.Length; i++)
            {
                if (Snake.snake[i] != null)
                {
                    //stop the square
                    Gamefield.StopSquare(snake[i], snake[i].Location.X / squareSize, snake[i].Location.Y / squareSize);

                }
            }

        }


    }
}
