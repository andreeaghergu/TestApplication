using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TestApplication.Models
{

    // Description of Answer.
    //Answer class for the observable object Answer

    public class Answer
    {
        [XmlAttribute("CorrectAnswer")]
        public bool CorrectAnswer { get; set; }
        [XmlAttribute("Index")]
        public int Index { get; set; }
        [XmlAttribute("Text")]
        public string Text { get; set; }



        public bool SelectedAnswer { get; set; }

    }
}

