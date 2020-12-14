using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace TestApplication.Models
{
    static class DataReader
    {

        /*static public int[] GetQuestionIds(int id)
            {
                //List<int> query = binnenschifffahrt.T_Fragebogen_unter_Maschine.Where(x => x.FragebogenNr == id).Select(y => y.F_Id_SBF_Binnen).ToList<int>();

                List<int> query = new List<int>(0);
                List<int> result = new List<int>();
                foreach (int q in query)
                {
                    if (!result.Contains(q))
                    {
                        result.Add(q);
                    }
                }
                return result.ToArray();

            }*/

        public static List<Question> GetQuestions(int level, int limit, Questionaire questionaire)
        {
            List<Question> q = questionaire.Questions.Question;
            List<Question> x = new List<Question>();
            foreach (Question question in q)
            {
                if (question.Level == level && x.Count<limit)
                {
                    x.Add(question);
                }



            }
            return x;

        }
    }
}
