using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.Storage;
using Windows.Storage.Streams;
using System.IO;

namespace Invaders
{
    [Serializable]
    static class World
    {
        private static int index = 0;
        public const int widthOffset = 30;
        public const int heightOffset = 30;
        private static bool Started = false;
        private static Player player;
        public static List<Invader> invaders = new List<Invader>();
        public static List<Bullet>  bullets =  new List<Bullet>();
        public static List<Invader> deados = new List<Invader>();
        async public static void Start(Canvas area)
        {
            DispatcherTimer hitTimer = new DispatcherTimer();
            hitTimer.Interval = TimeSpan.FromMilliseconds(4);
            hitTimer.Tick += HitTimer_Tick;
            hitTimer.Start();
            AddInvaders(area, 10);
            Started = true;
        }
        

        public static void AddInvaders(Canvas area, int amount)
        {
            Point loc = new Point(widthOffset, heightOffset);
            if(Started == true)
            {
                foreach(Invader invader in World.invaders)
                {
                    invader.Location = new Point(invader.Location.X, invader.Location.Y + heightOffset);
                }
            }
            for (int i = 0; i < amount + 1; i++)
            {
                loc.X += widthOffset;
                if (area.Width >= loc.X)
                {
                    loc.X = widthOffset;
                    loc.Y += heightOffset;
                }
                invaders.Add(new Invader(loc, InvaderType.Rocket) { Tag=index.ToString() });
                index++;
            }
        }

        private static void HitTimer_Tick(object sender, object e)
        {
            foreach(Invader invader in invaders)
            {
                foreach(Bullet bullet  in bullets)
                {
                    if(invader.dimens.Contains(bullet.Location))
                    {
                        invader.kill();
                    }
                }
            }
        }
    }
}
