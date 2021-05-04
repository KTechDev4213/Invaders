using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Invaders
{
    class Player:Move
    {
        public Player(Canvas area)
            :base(new Windows.Foundation.Point(area.Width/2, area.Height - 2))
        {
            
            
        }
        public void Fire()
        {
            Bullet bullet = new Bullet(new Windows.Foundation.Point(Location.X, Location.Y - 2));
            World.bullets.Add(bullet);
            bullet.Fire(true);
        }
    }
}
