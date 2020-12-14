using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Xml.Serialization;

namespace TestApplication.Models
{
    [XmlRoot("Questionaire"), Serializable]
    public class Questionaire
    {
        [XmlElement("Questions")]
        
        public Questions Questions { get; set; }
        /*private int answeredCorrectly;



        // get and set based on answered questions
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
        }*/


    }
}

