using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//Ian and Dominic
//Snake©
//Jan 22, 2010

namespace Snake
{
    public partial class frmMain : Form
    {
        //declare global variables
        private Snake snake;
        private Objective objective;
        Random random = new Random();
        int score = 0;       

        //set space bar check to true intially
        bool spaceBarCheck = true;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Space:
                    {
                        //allow user to click space bar to begin game
                        //set to false after space bar is checked
                        if (spaceBarCheck == true)
                        {
                            //clear message
                            lblMsg.Text = null;

                            //set timer
                            tmrGameClock.Enabled = true;

                            Application.DoEvents();

                            Gamefield.DrawingSurface = picGamefield.CreateGraphics();

                            //create snake
                            snake = new Snake(new Point(150, 70));
                            snake.Show();
                            Snake.currentDirection = Snake.Direction.Down;

                            //Radomize location and create objective
                            int x = random.Next(1, 30);
                            int y = random.Next(1, 15);
                            objective = new Objective(new Point(x * 10, y * 10));
                            objective.Show();

                            //set space bar check to false
                            spaceBarCheck = false;
                            break;
                        }
                        else
                        {
                            break;
                        }

                    }
                case Keys.Down:
                    if (spaceBarCheck == false)//Allow user to click keys after game has started
                    {
                        //If snake is not moving up, move snake down
                        if (Snake.currentDirection != Snake.Direction.Up)
                        {
                            snake.Down();
                            Snake.currentDirection = Snake.Direction.Down;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                case Keys.Right:
                    if (spaceBarCheck == false)//Allow user to click keys after game has started
                    {
                        //If snake is not moving left, move right
                        if (Snake.currentDirection != Snake.Direction.Left)
                        {
                            snake.Right();
                            Snake.currentDirection = Snake.Direction.Right;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                case Keys.Up:
                    if (spaceBarCheck == false)//Allow user to click keys after game has started
                    {
                        //If snake is not moving up, move down
                        if (Snake.currentDirection != Snake.Direction.Down)
                        {
                            snake.Up();
                            Snake.currentDirection = Snake.Direction.Up;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                case Keys.Left:
                    if (spaceBarCheck == false)//Allow user to click keys after game has started
                    {
                        //If snake is not moving left, move right
                        if (Snake.currentDirection != Snake.Direction.Right)
                        {
                            snake.Left();
                            Snake.currentDirection = Snake.Direction.Left;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
            }          
        }

        private void tmrGameClock_Tick(object sender, EventArgs e)
        {            

            //Check Direction of Snake, move automatically as timer ticks
            if (Snake.currentDirection == Snake.Direction.Down)
            {
                snake.Down();
            }
            else if (Snake.currentDirection == Snake.Direction.Right)
            {
                snake.Right();
            }
            else if (Snake.currentDirection == Snake.Direction.Up)
            {
                snake.Up();
            }
            else if (Snake.currentDirection == Snake.Direction.Left)
            {
                snake.Left();
            }

            //Check if snake collides with object
            if (Snake.snake[0].Location.X == Objective.objective.Location.X && Snake.snake[0].Location.Y == Objective.objective.Location.Y || Snake.DetectionCheck == Snake.ManualDetection.Detection)
            {
                //Increase score by 10
                score += 10;
                lblScore.Text = "Score: " + score.ToString();

                //Decrease time interval to increase timer tick
                //Incrases speed of snake
                if (tmrGameClock.Interval != 0)
                {
                    tmrGameClock.Interval -= 1;
                }

                //Reset snake collision detector in movement methods
                Snake.DetectionCheck = Snake.ManualDetection.noDetection;

                //Random generate the location of new objective
                int x = random.Next(1, 30);
                int y = random.Next(1, 15); 

                //Check if new objective location is equal to a snake square location
                for (int i = 0; i < Snake.snakeCounter; i++)
                {
                    if ((x * 10) == Snake.snake[i].Location.X && (y * 10) == Snake.snake[i].Location.Y)
                    {
                        //Generate new random location
                        x = random.Next(1, 30);
                        y = random.Next(1, 15);

                        //Reset increment to check all locations again
                        i = -1;
                    }
                }             

                //Create new objective
                objective = new Objective(new Point(x * 10, y * 10)); ;
                objective.Show();

                //Check the direction of the snake 
                //Add new square to back end of the tail
                if (Snake.currentDirection == Snake.Direction.Down)
                {
                    snake.addSnake(new Point(Snake.locationCounter[0], Snake.locationCounter[1] - 10));
                }
                else if (Snake.currentDirection == Snake.Direction.Up)
                {
                    snake.addSnake(new Point(Snake.locationCounter[0], Snake.locationCounter[1] + 10));
                }
                else if (Snake.currentDirection == Snake.Direction.Right)
                {
                    snake.addSnake(new Point(Snake.locationCounter[0] - 10, Snake.locationCounter[1]));
                }
                else
                {
                    snake.addSnake(new Point(Snake.locationCounter[0] + 10, Snake.locationCounter[1]));
                }
            }

            //Check if snake collides with self or boundaries
            if (Snake.snake.Length > 0)
            {
                for (int i = 1; i < Snake.snakeCounter + 1; i++)
                {
                    if (Snake.snake[i] != null && Snake.snake[0].Location == Snake.snake[i].Location || Gamefield.MovingCheck == Gamefield.SnakeMoving.NotMoving)
                    {
                        //Disable timer, run collision method, dispaly message, rest
                        tmrGameClock.Enabled = false;
                        snake.Collision();                        
                        MessageBox.Show("Game Over!" + "\r" + "Final Score: " + score.ToString());
                        Reset();
                        break;
                    }
                }
            }
        }


        private void Reset()
        {
            //Clear grid
            for (int i = 0; i < Gamefield.Width; i++)
            {
                for (int j = 0; j < Gamefield.Height; j++)
                {
                    Gamefield.Grid[i, j] = null;
                }
            }

            //Clear snake
            for (int i = 0; i < Snake.snakeCounter; i++)
            {
                Snake.snake[i] = null;
            }

            //Reset timer interval
            tmrGameClock.Interval = 75;
            
            //Reset moving check for stop square method
            Gamefield.MovingCheck = Gamefield.SnakeMoving.Moving;

            //Reset snake counter
            Snake.snakeCounter = 1;

            //Reset Square
            score = 0;
            lblScore.Text = "Score: 0";
            lblMsg.Text = "Press Space Bar to Begin";

            //Set space bar check to true so player can start game again
            spaceBarCheck = true;

            //Refresh game field
            this.Refresh();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void picGamefield_Click(object sender, EventArgs e)
        {

        }

        private void lblMsg_Click(object sender, EventArgs e)
        {

        }


    }


}
