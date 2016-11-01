using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace StopWatch
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Stopwatch components
          DispatcherTimer stopWatch = new DispatcherTimer();
          Stopwatch sw = new Stopwatch();
          string currentTime = string.Empty;

        public MainWindow()
        {
            InitializeComponent();

            //Sets the timer display to be in hours, minutes, seconds, & miliseconds.
            stopWatch.Interval = new TimeSpan(0, 0, 0, 1);
            stopWatch.Tick += new EventHandler(stopWatch_Tick);

            //Event handlers for key down actions
            this.PreviewKeyDown += new KeyEventHandler(HandleEsc);
            this.PreviewKeyDown += new KeyEventHandler(reset_KeyDown);
        }

        private void stopWatch_Tick(object sender, EventArgs e)
        {
            //Stopwatch display of the timer
            if (sw.IsRunning)
            {
                TimeSpan ts = sw.Elapsed;
                currentTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                    ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
                timer.Content = currentTime;
            }

        }

        //Resets the stopwatch back to default start up by clicking the Reset button.
        private void reset_Click(object sender, RoutedEventArgs e)
        {
            sw.Restart();
            sw.Stop();
            timer.Content = "00:00:00.00";

            pause.IsEnabled = false;
            this.unpause.Visibility = Visibility.Hidden;
            this.menuUnpause.Visibility = Visibility.Hidden;
            this.stop.Visibility = Visibility.Hidden;
            menuPause.IsEnabled = false;
            menuStart.IsEnabled = true;
            this.menuStart.Visibility = Visibility.Visible;
            this.menuStop.Visibility = Visibility.Hidden;
            this.menuPause.Visibility = Visibility.Visible;

        }

        //Resets the stopwatch back to default start up by pressing Ctrl+R
        private void reset_KeyDown(object sender, KeyEventArgs e)
        {   //Clears the canvas with Ctrl + X 
            if ((Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control && e.Key == Key.R)
            {
                sw.Restart();
                sw.Stop();
                timer.Content = "00:00:00.00";

                pause.IsEnabled = false;
                this.unpause.Visibility = Visibility.Hidden;
                this.menuUnpause.Visibility = Visibility.Hidden;
                this.stop.Visibility = Visibility.Hidden;
                menuPause.IsEnabled = false;
                menuStart.IsEnabled = true;
                this.menuStart.Visibility = Visibility.Visible;
                this.menuStop.Visibility = Visibility.Hidden;
                this.menuPause.Visibility = Visibility.Visible;
            }
        }

        //Resets the stopwatch back to default start up by clicking the "Reset, Ctrl+R" in the menu bar.
        private void menuReset_Click(object sender, RoutedEventArgs e)
        {
            sw.Restart();
            sw.Stop();
            timer.Content = "00:00:00.00";

            pause.IsEnabled = false;
            this.unpause.Visibility = Visibility.Hidden;
            this.menuUnpause.Visibility = Visibility.Hidden;
            this.stop.Visibility = Visibility.Hidden;
            menuPause.IsEnabled = false;
            menuStart.IsEnabled = true;
            this.menuStart.Visibility = Visibility.Visible;
            this.menuStop.Visibility = Visibility.Hidden;
            this.menuPause.Visibility = Visibility.Visible;
        }

        //Starts the timer of the stopwatch by clicking the start button.
        private void start_Click(object sender, RoutedEventArgs e)
        {
            stopWatch.Start();
            sw.Start();
            pause.IsEnabled = true;
            this.stop.Visibility = Visibility.Visible;
            menuPause.IsEnabled = true;
            this.menuStart.Visibility = Visibility.Hidden;
            this.menuStop.Visibility = Visibility.Visible;
        }

        //Starts the timer of the stopwatch by clicking the start button in the menu bar.
        private void menuStart_Click(object sender, RoutedEventArgs e)
        {
            stopWatch.Start();
            sw.Start();
            pause.IsEnabled = true;
            this.stop.Visibility = Visibility.Visible;
            menuPause.IsEnabled = true;
            this.menuStart.Visibility = Visibility.Hidden;
            this.menuStop.Visibility = Visibility.Visible;
        }

        //Pauses the timer of the stop watch by clicking the pause button.
        private void pause_Click(object sender, RoutedEventArgs e)
        {
            if (sw.IsRunning)
            {
                stopWatch.Stop();
            }
            this.unpause.Visibility = Visibility.Visible;
            this.menuUnpause.Visibility = Visibility.Visible;
            this.menuPause.Visibility = Visibility.Hidden;
        }

        //Pauses the timer of the stop watch by clicking the pause button in the menu bar.
        //The timer still runs in the background but does not show the value if "Stop" is not clicked.
        private void menuPause_Click(object sender, RoutedEventArgs e)
        {
            if (sw.IsRunning)
            {
                stopWatch.Stop();
            }
            this.unpause.Visibility = Visibility.Visible;
            this.menuUnpause.Visibility = Visibility.Visible;
            this.menuPause.Visibility = Visibility.Hidden;
        }

        //Unpauses the timer of the stopwatch by clicking the unpause button.
        private void unpause_Click(object sender, RoutedEventArgs e)
        {
            this.unpause.Visibility = Visibility.Hidden;
            this.menuUnpause.Visibility = Visibility.Hidden;
            this.menuPause.Visibility = Visibility.Visible;
            stopWatch.Start();
        }

        //Unpauses the timer of the stopwatch by clicking the unpause button in the menu bar.
        private void menuUnpause_Click(object sender, RoutedEventArgs e)
        {
            this.unpause.Visibility = Visibility.Hidden;
            this.menuUnpause.Visibility = Visibility.Hidden;
            this.menuPause.Visibility = Visibility.Visible;
            stopWatch.Start();
        }

        //Stops the stopwatch timer by clicking the stop button.
        private void stop_Click(object sender, RoutedEventArgs e)
        {
            if (sw.IsRunning)
            {
                sw.Stop();
            }
            this.stop.Visibility = Visibility.Hidden;
            this.menuStop.Visibility = Visibility.Hidden;
            this.menuStart.Visibility = Visibility.Visible;
        }

        //Stops the stopwatch timer by clicking the menu bar stop button.
        private void menuStop_Click(object sender, RoutedEventArgs e)
        {
            if (sw.IsRunning)
            {
                sw.Stop();
            }
            this.stop.Visibility = Visibility.Hidden;
            this.menuStop.Visibility = Visibility.Hidden;
            this.menuStart.Visibility = Visibility.Visible;
        }

        //Closes the application by pressing the Esc key.
        private void HandleEsc(object sender, KeyEventArgs e)
        {   //Closes the application with the Esc key.
            if (e.Key == Key.Escape)
            {
                Close();
            }
        }

        //Closes the application by clicking the Exit, Esc button in the menu bar.
        private void escExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }
}
