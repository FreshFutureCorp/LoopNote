using LoopNote.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace LoopNote
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        public void EntityLoader(object sender, EventArgs e)
        {

            #region Timer

            this.Timer = new Timer();
            this.TimerDisp = new DispatcherTimer();
            this.TimerDisp.Tick += new EventHandler(TimerDispatcher);
            this.TimeSpan = TimeSpan.FromSeconds(Timer.Time);

            #endregion
           
        }


        #region Properties

        public DispatcherTimer TimerDisp;
        public TimeSpan TimeSpan;
        public Timer Timer;
        public List<NoteType> NoteList = null;
        public bool IsFinished = false;

        private Random random = null;
        #endregion

        public void RunOrStopTimer(object sender, EventArgs e)
        {
            Image imageController = (Image)sender;

            if (random == null)
                random = new Random();

            if (NoteList == null)
                NoteList = NoteTypeList.AllDefaultNoteType.ToList();

            if (imageController.Tag.Equals("Start"))
            {
                RandomizeNote();
                SetTimeRun();
            }
            else
                SetTimeOut();

        }

        private void RandomizeNote()
        {
            if (NoteList.Count > 0)
            {
                int note = random.Next(NoteList.Count - 1);
                NoteLabel.Content = NoteList.ElementAt(note).Description;

                NoteList.RemoveAt(note);
            }
            else
                IsFinished = true;
        }

        public void TimerDispatcher(object sender, EventArgs e)
        {

            if (IsFinished == false)
            {
                TimeSpan = TimeSpan.Add(TimeSpan.FromSeconds(-1));
                textTimer.Content = Timer.StartTimer(TimeSpan.Seconds);

                if (String.IsNullOrEmpty(textTimer.Content.ToString()))
                {
                    TimeSpan = TimeSpan.Add(TimeSpan.FromSeconds(Timer.Time));
                    textTimer.Content = Timer.StartTimer(TimeSpan.Seconds);
                    RandomizeNote();
                }
            }
            else
            {
                SetDefaultVariable();
                SetTimeOut();
            }
        }

        private void SetDefaultVariable()
        {
            NoteList = null;
            IsFinished = false;
        }

        private void SetTimeOut()
        {
            SetDefaultValueLabel();
            TimerDisp.Stop();
            this.TimerDisp.Interval = new TimeSpan(0, 0, 0);
        }

        private void SetDefaultValueLabel()
        {
            TimerButtonImage.Tag = "Start";
            TimerButtonImage.Source = new BitmapImage(new Uri(@"Image/play.png", UriKind.Relative));
            NoteLabel.Content = "";
            textTimer.Content = "";
        }

        private void SetTimeRun()
        {
            textTimer.Content = Timer.Time;
            this.TimerDisp.Interval = new TimeSpan(0, 0, 1);
            TimerButtonImage.Tag = "Stop";
            TimerButtonImage.Source = new BitmapImage(new Uri(@"Image/stop.png", UriKind.Relative));
            TimerDisp.Start();
        }
    }
}
