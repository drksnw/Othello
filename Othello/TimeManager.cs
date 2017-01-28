using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Threading;
using System.Diagnostics;

namespace Othello
{
    public class TimeManager : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private DateTime startP1;
        private DateTime startP2;
        private DateTime reflexionP1; 
        private DateTime reflexionP2; 

        private MainWindow mw;
        private bool player;

        public TimeManager(MainWindow mw)
        {
            this.mw = mw;
            player = true;
            startP1 = new DateTime(1, 1, 1);
            startP2 = new DateTime(1, 1, 1);
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(500);
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }

        public DateTime TimeP1
        {
            get { return reflexionP1; }
            private set
            {
                reflexionP1 = value;
                NotifyPropertyChanged("TimeP1");
            }
        }

        public int PointsP1
        {
            get
            {
                return mw.LogicContext.getNbOwnedCases(Othellier.PLAYER_BLACK);
            }
            set
            {
                NotifyPropertyChanged("PointsP1");
            }
        }

        public int PointsP2
        {
            get
            {
                return mw.LogicContext.getNbOwnedCases(Othellier.PLAYER_WHITE);
            }
            set
            {
                NotifyPropertyChanged("PointsP2");
            }
        }

        public DateTime TimeP2
        {
            get { return reflexionP2; }
            private set
            {
                reflexionP2 = value;
                NotifyPropertyChanged("TimeP2");
            }
        }

        void timer_Tick(object sender, EventArgs e)
        {
            if (player)
            {
                startP1 = startP1.AddMilliseconds(500);
                TimeP1 = startP1;
            }
            else
            {
                startP2 = startP2.AddMilliseconds(500);
                TimeP2 = startP2;
            }
            
        }

        public void changePlayer()
        {
            player = !player;
        }

        public void SetTime(int player, string timestring)
        {
            string[] times = timestring.Split(':');
            if (player == Othellier.PLAYER_BLACK)
            {                
                startP1 = new DateTime(1,1,1).AddHours(int.Parse(times[0])).AddMinutes(int.Parse(times[1])).AddSeconds(int.Parse(times[2]));              
            }
            else
            {
                startP2 = new DateTime(1, 1, 1).AddHours(int.Parse(times[0])).AddMinutes(int.Parse(times[1])).AddSeconds(int.Parse(times[2]));
            }
        }
    }
}
