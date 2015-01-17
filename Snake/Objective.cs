using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Snake
{
    class Objective
    {
        //Properties
        public static Square objective { get; set; }
        private int squareSize = Gamefield.squareSize;

        //contructor
        public Objective(Point Location)
        {
            objective = new Square(new Size(squareSize, squareSize), Color.Blue, new Point(Location.X, Location.Y));
        }

        //Show
        public void Show()
        {
            objective.Show();
        }

        //Hide
        public void Hide()
        {
            objective.Hide();
        }
        
    }
}
