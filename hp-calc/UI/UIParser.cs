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
                ProccessElement(item);
            }

            reader.Close();
        }

        private void ProccessElement(Element e)
        {
            string elementName = e.Name;
            Vector2 position = Vector2.FromString(e.Position);
            Vector2 size = Vector2.FromString(e.Size);
            Options options = e.Options;

            //Check if a type was defined...
            if (e.Type == null)
            {
                throw new ArgumentException("Cannot add element to layout if type is undefined.");
            }

            UIArgumentList argsList = new UIArgumentList(options.Option);

            switch (e.Type.ToLower())
            {
                case "textbox":
                    currentGenerator.AddTextbox(elementName, position.x, position.y, size.x, size.y, argsList);
                    break;
                case "button":
                    currentGenerator.AddButton(elementName, position.x, position.y, size.x, size.y, argsList);
                    break;
            }
        }
    }
}
