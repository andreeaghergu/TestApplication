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

using System.Diagnostics;
using TestApplication.Viewmodels;
using TestApplication.Models;
using System.Collections.ObjectModel;

namespace TestApplication
{

    // Interaction logic for QuestionairePage.xaml

    public partial class QuestionairePage : Page
    {
        // Property for the Viewmodel
        public QuestionViewModel QuestionVM { get; set; }

        // ctor for first question of a questionaire
        // TODO: questionaire selection

        public QuestionairePage(QuestionViewModel questionVM)
        {
            // the Viewmodel 
            QuestionVM = questionVM;
            InitializeComponent();

            // set the views data context to the model object in the viewmodel
            this.DataContext = QuestionVM;
            bool result = QuestionVM.Question.Solve();

            
        }
        // ctor for forward and back navigation
        public QuestionairePage(QuestionViewModel questionVM, int questionIndex)
        {
            // Instantiate the Viewmodel
            QuestionVM = questionVM;
            if (questionIndex >= 0 && questionIndex < QuestionVM.level_question.Count)
            {
                QuestionVM.Question = QuestionVM.level_question[questionIndex];
                
                ObservableCollection<Answer> answersVM = new ObservableCollection<Answer>();
                for (int i = 0; i < QuestionVM.level_question[questionIndex].AnswerList.Answer.Count; i++)
                {
                    answersVM.Add(QuestionVM.level_question[questionIndex].AnswerList.Answer[i]);
                }
                QuestionVM.Answers = answersVM;
                QuestionVM.DisplayedQuestionIndex = questionIndex;
            }


            InitializeComponent();
            // set the views data context to the model object in the viewmodel
            this.DataContext = QuestionVM;
        }


        public int CompletedQuestionsCount(QuestionViewModel questionVM)
        {
            int questionsCompleted = 0;
            //foreach (Question question in questionVM.Questionaire.Questions.Question)
            foreach (Question question in questionVM.level_question)
                
                foreach (Answer answer in question.AnswerList.Answer)
                    if (answer.SelectedAnswer)
                        questionsCompleted += 1;
            return questionsCompleted;
        }

        private void AnswerClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            var test = sender as RadioButton;
            //var test = sender as CheckBox;
            string str = test.Tag.ToString();
            int i = Int32.Parse(str);
            
            QuestionVM.AnswerClicked(i);
        }

        private void ForwardClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            
            QuestionVM.CompletedQuestions = CompletedQuestionsCount(QuestionVM);
            
            if (QuestionVM.CompletedQuestions == QuestionVM.level_question.Count)
            {
                // get selected and correct answer ids
                int selectedAnswerID = -1;
                int correctAnswerID = -1;
                foreach (Answer answer in QuestionVM.Answers)
                {
                    if (answer.SelectedAnswer)
                        selectedAnswerID = answer.Index;
                    if (answer.CorrectAnswer)
                        correctAnswerID = answer.Index;
                }

                NavigationService.Navigate(new ResultsPage(QuestionVM));
            }
            else 
            {
                
                if (QuestionVM.DisplayedQuestionIndex + 1 < QuestionVM.level_question.Count)
                {
                    
                    int selectedAnswerID = -1;
                    int correctAnswerID = -1;
                    foreach (Answer answer in QuestionVM.Answers)
                    {
                        if (answer.SelectedAnswer)
                            selectedAnswerID = answer.Index;
                        if (answer.CorrectAnswer)
                            correctAnswerID = answer.Index;
                    }

                    NavigationService.Navigate(new QuestionairePage(QuestionVM, QuestionVM.DisplayedQuestionIndex + 1));
                }
                else 
                {
                    
                    int positionUnansweredQuestion = 0;
                    foreach (Question question in QuestionVM.level_question) 
                    {
                        bool selectedFound = false;
                        foreach (Answer answer in question.AnswerList.Answer) 
                        {
                            
                            if (answer.SelectedAnswer)
                            {
                                
                                positionUnansweredQuestion += 1;
                                selectedFound = true;
                            }
                        }
                        
                        if (!selectedFound)
                            NavigationService.Navigate(new QuestionairePage(QuestionVM, positionUnansweredQuestion)); 
                    }
                }
            }
        }

        private void BackClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            QuestionVM.CompletedQuestions = CompletedQuestionsCount(QuestionVM);
            
            if (QuestionVM.DisplayedQuestionIndex > 0)
            {
                
                if (QuestionVM.CompletedQuestions == QuestionVM.level_question.Count)
                {
                    
                    NavigationService.Navigate(new QuestionairePage(QuestionVM, QuestionVM.DisplayedQuestionIndex - 1));
                }
                else 
                    NavigationService.Navigate(new QuestionairePage(QuestionVM, QuestionVM.DisplayedQuestionIndex - 1));
            }
            else 
            {
                // do nothing
            
            }
        }
    }
}