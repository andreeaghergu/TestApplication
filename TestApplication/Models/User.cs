using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace TestApplication.Models
{
    // user class 

    public class User
    {
        // Properties 
        public string Name { get; set; }
        public int SelectedQuestionaire { get; set; }
        public List<int> QuestionaireIDs { get; set; }

  
        public int QuestionLimit { get; set; }

        // Standard Constructor
        public User()
        {
            Name = "Anonim User";
            // used for questionaire creation from dropdown list
            SelectedQuestionaire = 1;
            QuestionaireIDs = new List<int>() { 1, 2, 3 };
            QuestionLimit = 5;
        }


    }
}

