using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TestApplication.Models
{
    public class AnswerList
    {
        [XmlElement("Answer")]
        public List<Answer> Answer { get; set; }

    }
}

