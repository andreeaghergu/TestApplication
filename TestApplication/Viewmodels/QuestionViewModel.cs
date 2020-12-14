using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Diagnostics;
using TestApplication.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using TestApplication.Viewmodels.Commands;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Xml.Serialization;
using System.IO;

namespace TestApplication.Viewmodels
{
    /// <summary>
    /// Description of QuestionViewModel. Handles the presentation logic.
    /// This class inherits from ObservableObject to enable one and two-way binding between the UI elements and the question model
    /// </summary>
    public class QuestionViewModel : ObservableObject
    {

        //private Questionaire questionaire;
        // fields hold observable objects of the models and results of user interaction
        // selected Questionaire
        private Questionaire questionaire;
        public List<Question> level_question = new List<Question>();
        // question to display
        private Question question;
        // answers to display
        private ObservableCollection<Answer> answers;

        //private List <int> ids;
        // number of questions with selected answers
        private int completedQuestions;
        // index of displayed question
        private int displayedQuestionIndex;
        // the User History, Settings, etc.
        private User user;
        // the wrong questions for results page
        private ObservableCollection<WrongAnswer> wrongAnswers;

        // the selected/displayed questionaire id and the list for selection 
        private int questionaireID;

        private int questionLimit=5;

        private int answeredCorrectly;

        public int AnsweredCorrectly
        {
            get
            {
                answeredCorrectly = CountCorrect();
                return answeredCorrectly;
            }
            set
            {
                answeredCorrectly = CountCorrect();
            }
        }



        public int CountCorrect()
        {
            int i = 0;
            foreach (Question question in level_question)
                if (question.Solve())
                    i++;

            return i;
        }

        // viewmodel constructor (hook the model up to the viewmodel)
        public QuestionViewModel()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Questionaire));
            FileStream loadStream = new FileStream("real_questions.xml", FileMode.Open, FileAccess.Read);
            Questionaire questionaire = (Questionaire)serializer.Deserialize(loadStream);
            // Instantiate the defaultUser for the view
            User = new User();

            /*foreach (Question q in questionaire.Questions.Question)
            {
                if (q.Level==User.SelectedQuestionaire && level_question.Count < User.QuestionLimit)
                {
                    level_question.Add(q);
                }
            }*/
            List<Question> level_question_aux = new List<Question>();
            foreach (Question q in questionaire.Questions.Question)
            {
                if (q.Level == User.SelectedQuestionaire)
                {
                    level_question_aux.Add(q);
                }
            }

            //shuffle pt level aux
            var rnd = new Random();
            var result = level_question_aux.OrderBy(item => rnd.Next());

            foreach (var item in result)
            {
                if (level_question.Count < User.QuestionLimit)
                {
                    level_question.Add(item);
                }
            }


            //DataReader.GetQuestions(questionaireID, questionLimit, questionaire);
            question = level_question[0];
            //question = questionaire.Questions.Question[0];
            // fills the observable collection with Answer objects
            Answers = new ObservableCollection<Answer>();
            for (int i = 0; i < question.AnswerList.Answer.Count; i++)
            {
                Answers.Add(question.AnswerList.Answer[i]);
            }
            // set these counters for logic and display
            CompletedQuestions = 0; // answers selected by user, wrapping
            DisplayedQuestionIndex = 0; // base 0 for navigation, wrapping
                                        // image string path

            // for results page
            WrongAnswers = new ObservableCollection<WrongAnswer>();

        }
        // ctor for new userselected questionaires
        public QuestionViewModel(QuestionViewModel oldQuestionViewModel)
        {
            User = oldQuestionViewModel.User;

            QuestionaireID = oldQuestionViewModel.User.SelectedQuestionaire;

            XmlSerializer serializer = new XmlSerializer(typeof(Questionaire));
            FileStream loadStream = new FileStream("real_questions.xml", FileMode.Open, FileAccess.Read);
            Questionaire questionaire = (Questionaire)serializer.Deserialize(loadStream);

            


            /*//List<Question> level_question = new List<Question>();
            foreach (Question q in questionaire.Questions.Question)
            {
                if (q.Level == User.SelectedQuestionaire && level_question.Count < User.QuestionLimit)
                {
                    level_question.Add(q);
                }
            }*/
            //pun in q_aux toate de levelul selectat
            List<Question> level_question_aux = new List<Question>();
            foreach (Question q in questionaire.Questions.Question)
            {
                if (q.Level == User.SelectedQuestionaire)
                {
                    level_question_aux.Add(q);
                }
            }

            //shuffle pt level aux
            var rnd = new Random();
            var result = level_question_aux.OrderBy(item => rnd.Next());

            foreach (var item in result)
            {
                if (level_question.Count < User.QuestionLimit)
                {
                    level_question.Add(item);
                }
            }



            //DataReader.GetQuestions(questionaireID, questionLimit, questionaire);
            question = level_question[0];

            //Questionaire = level_question;
            // create the displayed question
            //Question = Questionaire.Questions.Question[0];
            // fills the observable collection with Answer objects
            Answers = new ObservableCollection<Answer>();
            for (int i = 0; i < question.AnswerList.Answer.Count; i++)
            {
                Answers.Add(question.AnswerList.Answer[i]);
            }
            // set these counters for logic and display
            CompletedQuestions = 0;
            DisplayedQuestionIndex = 0;



            // for results page
            WrongAnswers = new ObservableCollection<WrongAnswer>();
        }



        // properties to display changes in the view
        public User User
        {
            get { return user; }
            set
            {
                user = value;
                OnPropertyChanged("User");
            }
        }
        public Question Question
        {
            get { return question; }
            set
            {
                question = value;
                OnPropertyChanged("Question");
            }
        }
        public ObservableCollection<Answer> Answers
        {
            get { return answers; }
            set
            {
                answers = value;
                OnPropertyChanged("Answers");
            }
        }
        public int QuestionaireID
        {
            get { return questionaireID; }
            set
            {
                questionaireID = value;
                OnPropertyChanged("QuestionaireID");
            }
        }
        /*public ObservableCollection<int> QuestionaireIDList
        {
            get { return questionaireIDList; }
            set
            {
                questionaireIDList = value;
                OnPropertyChanged("QuestionaireIDList");
            }
        }*/

        public Questionaire Questionaire
        {
            get { return questionaire; }
            set
            {
                questionaire = value;
                OnPropertyChanged("Questionaire");
            }
        }
        public ObservableCollection<WrongAnswer> WrongAnswers
        {
            get { return wrongAnswers; }
            set
            {
                wrongAnswers = value;
                OnPropertyChanged("WrongAnswers");
            }
        }
        public int CompletedQuestions
        {
            get { return completedQuestions; }
            set
            {
                completedQuestions = value;

                OnPropertyChanged("CompletedQuestions");
            }
        }
        public int DisplayedQuestionIndex
        {
            get { return displayedQuestionIndex; }
            set
            {
                displayedQuestionIndex = value;
                OnPropertyChanged("DisplayedQuestionIndex");
            }
        }

        public int QuestionLimit
        {
            get { return questionLimit; }
            set
            {
                questionLimit = value;
                OnPropertyChanged("QuestionLimit");
            }
        }


        // ICommand property provides specific implementation for each action.
        // the delegate will forward to methods defined here in the viewmodel.
        public ICommand AnswerClickedCommand
        {
            get
            {
                return new DelegatingCommand(o => AnswerClicked((int)o));
            }
        }
        // links to AnswerClicked method in Question model 
        public void AnswerClicked(int o)
        {
            Question.AnswerClicked(o);
            OnPropertyChanged("AnswerSelected");
        }
    }
}
