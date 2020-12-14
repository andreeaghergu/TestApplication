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

namespace TestApplication
{

    public partial class ResultsPage : Page
    {
        // Property for the Viewmodel
        public QuestionViewModel QuestionVM { get; set; }

        public ResultsPage(QuestionViewModel questionVM)
        {

            QuestionVM = questionVM;

            foreach (Question question in QuestionVM.level_question)
                if (!question.Solve())
                {
                    List<string> wrong = new List<string>();
                    WrongAnswer wrongAnswer = new WrongAnswer();
                    wrongAnswer.Question = "Question: " + question.QuestionText;
                    foreach (Answer answer in question.AnswerList.Answer)
                    {

                        if (answer.SelectedAnswer && !answer.CorrectAnswer)
                            wrongAnswer.SelectedAnswer = "WRONG: " + answer.Text;
                    }
                    foreach (Answer answer in question.AnswerList.Answer)
                    {

                        if (answer.CorrectAnswer)
                            wrongAnswer.RightAnswer = "RIGHT: " + answer.Text;
                    }
                    QuestionVM.WrongAnswers.Add(wrongAnswer);

                }

            InitializeComponent();
            this.DataContext = QuestionVM;
        }

        private void BackToMainClicked(object sender, RoutedEventArgs e)
        {
            QuestionViewModel currentVM = QuestionVM;
            NavigationService.Navigate(new StartPage(new QuestionViewModel(currentVM)));
        }
    }
}

