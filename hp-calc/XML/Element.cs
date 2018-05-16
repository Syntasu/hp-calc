using System.Xml.Serialization;

namespace hp_calc.XML
{
    [XmlRoot(ElementName = "element")]
    public class Element
    {
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "position")]
        public string Position { get; set; }

        [XmlElement(ElementName = "size")]
        public string Size { get; set; }

        [XmlElement(ElementName = "options")]
        public Options Options { get; set; }

        [XmlElement(ElementName = "type")]
        public string Type { get; set; }

    }

}
