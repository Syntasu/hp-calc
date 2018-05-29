using hp_calc.Data;
using hp_calc.XML;
using System;
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

        private UIGenerator currentGenerator = null;
        

        public void LoadUIFromFile(UIGenerator generator)
        {
            currentGenerator = generator;

            XmlReader reader = XmlReader.Create(path);
            XmlSerializer serializer = new XmlSerializer(typeof(Layout));
            Layout layout = serializer.Deserialize(reader) as Layout;

            foreach (var item in layout.Element)
            {
                //tring data = $"{item.Name}, {item.Position}, {item.Size}, {item.Type}, [ ";
                ProccessElement(item);

                //foreach (var option in item.Options.Option)
                //{
                //    data += $"{option.Type} = {option.Text}, ";
                //}

                //data += " ]";
                //MessageBox.Show(data);
            }
        }

        private void ProccessElement(Element e)
        {
            string elementName = e.Name;
            Vector2 position = Vector2.FromString(e.Position);
            Vector2 size = Vector2.FromString(e.Size);
            Options options = e.Options;

            if(e.Type == null) throw new ArgumentException("Cannot add element to layout if type is undefined.");

            switch (e.Type.ToLower())
            {
                case "textbox":
                    currentGenerator.AddTextbox(elementName, position.x, position.y, size.x, size.y);
                    break;
            }
        }
    }
}
