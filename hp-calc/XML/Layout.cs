using System.Collections.Generic;
using System.Xml.Serialization;

namespace hp_calc.XML
{
    [XmlRoot(ElementName = "layout")]
    public class Layout
    {
        [XmlElement(ElementName = "element")]
        public List<Element> Element { get; set; }
    }
}
