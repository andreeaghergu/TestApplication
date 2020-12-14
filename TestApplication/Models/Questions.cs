using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;

namespace TestApplication.Models
{
    public class Questions
    {
        [XmlElement("Question")]
        public List<Question> Question { get; set; }
    }
}

