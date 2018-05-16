using hp_calc.XML;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace hp_calc.UI
{
    public class UIParser
    {
        public UIGenerator GetInterface()
        {
            //TODO: Not use a hardcoded path.
            XmlReader reader = XmlReader.Create(@"W:\hp-calc\hp-calc\layout.xml");
            XmlSerializer serializer = new XmlSerializer(typeof(Layout));
            Layout layout = serializer.Deserialize(reader) as Layout;

            foreach(var item in layout.Element)
            {
                string data = $"{item.Name}, {item.Position}, {item.Size}, {item.Type}, [ ";

                foreach (var option in item.Options.Option)
                {
                    data += $"{option.Type} = {option.Text}, ";
                }

                data += " ]";
                MessageBox.Show(data);
            }


            return null;
        }

        private void ProccessNode()
        {

        }
    }
}
