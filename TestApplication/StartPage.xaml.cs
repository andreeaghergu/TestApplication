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
using TestApplication.Models;
using TestApplication.Viewmodels;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace TestApplication
{
        /// <summary>
        /// Interaction logic for StartPage.xaml
        /// </summary>
        public partial class StartPage : Page
        {
            public QuestionViewModel QuestionVM { get; set; }

            //public StartPage()
            //{
            //    QuestionVM = new QuestionViewModel();
            //    InitializeComponent();
            //    this.DataContext = QuestionVM;
            //}

            public StartPage(QuestionViewModel questionVM)
            {
                QuestionVM = questionVM;
                InitializeComponent();
                this.DataContext = QuestionVM;
            }

            private void StartClicked(object sender, RoutedEventArgs e)
            {
                QuestionViewModel currentQuestionVM = QuestionVM;
                User user = new User();
                NavigationService.Navigate(new QuestionairePage(new QuestionViewModel(currentQuestionVM)));
            }



        }
    }

