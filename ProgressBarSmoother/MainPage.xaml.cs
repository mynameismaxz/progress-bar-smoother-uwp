using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ProgressBarSmoother
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private DispatcherTimer dispatch = new DispatcherTimer();

        public MainPage()
        {
            this.InitializeComponent();

            progressBar.Maximum = 100;

            double time = 100/5;            // define time in seconds as divider

            TimeSpan timeSpanConvert = TimeSpan.FromMilliseconds(time);

            dispatch.Interval = timeSpanConvert;
           
            dispatch.Tick += Dispatch_Tick;
        }

        int waitTime = 0;

        private void Dispatch_Tick(object sender, object e)
        {
            if (progressBar.Value < 100)
            {
                progressBar.Value++;
            } else
            {
                if (waitTime++ > 35)
                {
                    System.Diagnostics.Debug.WriteLine("Stop timer");
                    dispatch.Stop();
                }
            }
        }

        private void startTimer_Click(object sender, RoutedEventArgs e)
        {
            dispatch.Start();
        }
    }
}
