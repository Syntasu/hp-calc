using System.Xml.Serialization;

namespace hp_calc.XML
{
    [XmlRoot(ElementName = "option")]
    public class Option
    {
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
        [XmlText]
        public string Text { get; set; }
    }
}
