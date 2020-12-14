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


using System.Windows;
using System.ComponentModel;
using TestApplication.Models;
using TestApplication.Viewmodels;
using System.Diagnostics;

namespace TestApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// Basicaly the entrypoint for our app (after App.xaml)
    /// </summary>
    public partial class MainWindow : Window
    {
        //create the viewmodel and set it as data context for the views in constructor
        public QuestionViewModel QuestionVM { get; set; }

        public MainWindow()
        {
            QuestionVM = new QuestionViewModel();
            InitializeComponent();
            DataContext = QuestionVM;
        }

        private void MainWindowLoaded(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new StartPage(QuestionVM);
        }

        // TODO: maximize button and method, views should behave correctly no matter the screensize used (windowed or fullscreen or other resolutions / resized ) 

        private void MinimizeClicked(object sender, RoutedEventArgs e)
        {
            // TODO: minimize window here
        }

        private void ExitClicked(object sender, RoutedEventArgs e)
        {
            // close the app window to call the window closing event
            this.Close();
        }

        // Method to handle the Window.Closing event.
        private void Window_Closing(object sender, CancelEventArgs e)
        {
            var response = MessageBox.Show("Do you really want to exit?", "Exiting...", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
            if (response == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                Application.Current.Shutdown();
            }
        }
    }
}
