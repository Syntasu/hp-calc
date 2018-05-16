using System.Collections.Generic;
using System.Xml.Serialization;

namespace hp_calc.XML
{
    [XmlRoot(ElementName = "options")]
    public class Options
    {
        [XmlElement(ElementName = "option")]
        public List<Option> Option { get; set; }
    }
}
