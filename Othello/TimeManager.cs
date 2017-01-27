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
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TimeP1"));
        }
        private DateTime _now;
        private MainWindow mw;
        private bool player;

        public TimeManager(MainWindow mw)
        {
            this.mw = mw;
            player = true;
            _now = DateTime.Now;
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(500);
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }

        public DateTime TimeP1
        {
            get { return _now; }
            private set
            {
                _now = value;
                 NotifyPropertyChanged("TimeP1");
            }
        }

        public DateTime TimeP2
        {
            get { return _now; }
            private set
            {
                _now = value;
                NotifyPropertyChanged("TimeP2");
            }
        }

        void timer_Tick(object sender, EventArgs e)
        {
            if (player)
            {
                TimeP1 = DateTime.Now;
            }else
            {
                TimeP2 = DateTime.Now;
            }
            
        }

        public void changePlayer()
        {
            player = !player;
        }
    }
}
