using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Xml.Serialization;

namespace TestApplication.Models
{
    public class Question
    {
        // Properties from XML
        [XmlAttribute("ID")]
        public int ID { get; set; }

        [XmlAttribute("Level")]
        public int Level { get; set; }
        [XmlAttribute("QuestionText")]
        public string QuestionText { get; set; }
        [XmlElement("AnswerList")]

        public AnswerList AnswerList { get; set; }




        public void AnswerClicked(int index)
        {
            foreach (Answer answer in AnswerList.Answer)
                if (answer.Index != index)
                    answer.SelectedAnswer = false;
                else
                    answer.SelectedAnswer = true;

        }


        public bool Solve()
        {
            bool correct = false;
            foreach (Answer answer in AnswerList.Answer)
                if (answer.CorrectAnswer && answer.SelectedAnswer)
                    correct = true;

            return correct;
        }
    }
}

