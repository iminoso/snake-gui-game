using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Snake
{
    class Square
    {

        //Properties
        public Point Location { get; set; }
        public Size Size { get; set; }
        public Color Color { get; set; }

        //constructor
        public Square(Size squareSize, Color color, Point location)
        {
            this.Size = squareSize;
            this.Color = color;
            this.Location = location;
        }

        //square methods
        //Show square
        public void Show()
        {
            Gamefield.DrawingSurface.FillRectangle(new SolidBrush(Color), Location.X, Location.Y, Size.Width, Size.Height);
            Gamefield.DrawingSurface.DrawRectangle(new Pen(Color.White), Location.X, Location.Y, Size.Width, Size.Height);
        }

        //Hide square
        public void Hide()
        {

            Gamefield.DrawingSurface.FillRectangle(new SolidBrush(Color.LightGray), Location.X, Location.Y, Size.Width, Size.Height);
            Gamefield.DrawingSurface.DrawRectangle(new Pen(Color.LightGray), Location.X, Location.Y, Size.Width, Size.Height);

        }


    }
}
