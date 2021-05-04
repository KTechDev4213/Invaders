using System;
using System.Collections.Generic;
//using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI;

namespace Invaders
{
    public struct Success
    {
        public bool success { get; private set; }
        public string Message { get; private set; }
        public Success(bool success, string Message)
        {
            this.success = success;
            this.Message = Message;
        }
    }
    public enum Direction
    { Up, Down, Left, Right};
    abstract class Move
    {
       private Windows.Foundation.Point location;
       public Windows.Foundation.Point Location
        {
            get
            {
                return location;
            }
            set
            {
                location = value;
            }
        }
     public Move(Point location)
        {
            this.location = location;
        }
       public Success Go(Direction direction, int amount)
        {
            if(direction == Direction.Up)
            {
                location.Y -= amount;
            }
            else if(direction == Direction.Down)
            {
                location.Y -= amount;
            }    
            else if(direction == Direction.Left)
            {
                location.X -= amount;
            }
            else if(direction == Direction.Right)
            {
                location.X += amount;
            }
            else
            {
                return new Success(false, "Invalid direction");
            }
            return new Success(true, "Done");
        }
    }
}
