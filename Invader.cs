using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Invaders
{
    class Invader:Move
    {
        public string Tag;
        public InvaderType type;
        public  Rect dimens { get { return new Rect(Location.X, Location.Y, 50, 50); } }
        public Invader(Windows.Foundation.Point location, InvaderType type)
            :base(location)
        {
            this.type = type;
            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, object e)
        {
            
        }
        public void Fire()
        {
            Bullet bullet = new Bullet(Location);
            World.bullets.Add(bullet);
            bullet.Fire(false);
        }
        public void kill()
        {
            World.invaders.Remove(this);
            World.deados.Add(this);
        }
    }
    enum InvaderType
    {
        Rocket
    }
}
