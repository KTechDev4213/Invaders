using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Xaml;

namespace Invaders
{
    class Bullet
    {
        private bool up;
        public void Fire(bool up)
        {
            this.up = up;
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(6);
            if(up == true)
                timer.Tick += Timer_Tick;
            else
                timer.Tick += Timer_Tick1;
            timer.Start();
        }

        private void Timer_Tick1(object sender, object e)
        {
            Location = new Point(Location.X, Location.Y + 2);
        }

        public Point Location { get; private set; }
        private void Timer_Tick(object sender, object e)
        {
            Location = new Point(Location.X, Location.Y - 2);
        }
        /// <summary>
        /// initialize the location
        /// </summary>
        /// <param name="origin">The location where the bullet is originalty</param>
        public Bullet(Point origin)
        {
            Location = origin;
        }
    }
}
