using hp_calc.Data;
using hp_calc.XML;
using System;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace hp_calc.UI
{
    public class UIParser
    {
        /// <summary>
        ///     Define the path to the layout.xml file.
        /// </summary>
        private string path
        {
            get
            {
                string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                string file = "layout.xml";
                return baseDir + file;
            }
        }

        /// <summary>
        ///     Load a layout from an (xml) file.
        /// </summary>
        /// <param name="generator">The generator we want to apply all the mutation to.</param>
        public void LoadLayout(UIGenerator generator)
        {
            //Read, deserialize the file and convert it into a Layout object.
            Layout layout = default(Layout);
            XmlReader reader = null;
            XmlSerializer serializer = null;

            try
            {
                reader = XmlReader.Create(path);
                serializer = new XmlSerializer(typeof(Layout));
                layout = serializer.Deserialize(reader) as Layout;
            }
            catch(InvalidOperationException e)
            {
                MessageBox.Show("There was some syntax error in layout xml: " + e.InnerException.Message, "Layout parsing error");
                Application.Exit();
                return;
            }
            catch(FileNotFoundException e)
            {
                MessageBox.Show("Could not find layout.xml at: " + path);
                Application.Exit();
                return;
            }
            finally
            {
                if (reader != null && reader.ReadState != ReadState.Closed)
                {
                    reader.Close();
                }
            }

            //Process each individual element.
            foreach (var item in layout.Element)
            {
                ProccessElement(generator, item);
            }
        }

        /// <summary>
        ///     Process each individual element we read from the XML>
        /// </summary>
        /// <param name="generator">Generator we need to apply it to.</param>
        /// <param name="element">The element we are currently processing.</param>
        private void ProccessElement(UIGenerator generator, Element element)
        {
            //Check if the required fields are present.
            if(element.Name == null || element.Position == null || element.Size == null || element.Type == null)
            {
                MessageBox.Show(
                    "Cannot add element to layout if the required fields are undefined (required is type, name, position and size)." +
                    $"Element information: Name={element.Name}, Position={element.Position}, Size={element.Size}, Type={element.Type}",
                    "Layout parsing error"
                );
                return;
            }

            string elementName = element.Name;
            Vector2 position = Vector2.FromString(element.Position);
            Vector2 size = Vector2.FromString(element.Size);
            Options options = element.Options;

            UIArgumentList argsList = new UIArgumentList();

            //Only popluate the argument list if we have some options available.
            if(options != null && options.Option != null && options.Option.Count > 0)
            {
                argsList.Populate(options.Option);
            }

            switch (element.Type.ToLower())
            {
                case "textbox":
                    generator.AddControl<TextBox>(elementName, position.x, position.y, size.x, size.y, argsList);
                    break;
                case "button":
                    generator.AddControl<Button>(elementName, position.x, position.y, size.x, size.y, argsList);
                    break;
                case "radio":
                    generator.AddControl<RadioButton>(elementName, position.x, position.y, size.x, size.y, argsList);
                    break;
                case "checkbox":
                    generator.AddControl<CheckBox>(elementName, position.x, position.y, size.x, size.y, argsList);
                    break;
                case "list":
                    generator.AddControl<ListBox>(elementName, position.x, position.y, size.x, size.y, argsList);
                    break;
                case "label":
                    generator.AddControl<Label>(elementName, position.x, position.y, size.x, size.y, argsList);
                    break;
            }
        }
    }
}
