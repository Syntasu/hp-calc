using hp_calc.XML;
using System;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace hp_calc.UI
{
    public class UIParser
    {
        private string path
        {
            get
            {
                string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                string file = "layout.xml";
                return baseDir + file;
            }
        }
        

        public UIGenerator LoadUIFromFile()
        {
            XmlReader reader = XmlReader.Create(path);
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
