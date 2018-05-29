using hp_calc.XML;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace hp_calc.UI
{
    public enum UIArgumentProperty
    {
        Value, 
        Multiline,
        Readonly,
        Checked,
        Visible,
    }

    public class UIArgumentList
    {
        private IDictionary<UIArgumentProperty, object> arguments;

        public void Populate(IList<Option> options)
        {
            arguments = new Dictionary<UIArgumentProperty, object>();

            foreach (Option option in options)
            {
                string propertyName = option.Type.ToLower();
                bool validProperty = Enum.TryParse(propertyName, true, out UIArgumentProperty prop);

                if (!validProperty)
                {
                    //We don't know what property this is, just ignore it I guess.
                    continue;
                }

                arguments.Add(prop, option.Text);
            }
        }

        public T Get<T>(UIArgumentProperty prop)
        {
            if(arguments == null || arguments.Count <= 0)
            {
                return default(T);
            }

            foreach (var arg in arguments)
            {
                if (arg.Key != prop) continue;

                try
                {
                    return (T)Convert.ChangeType(arg.Value, typeof(T));
                }
                catch(Exception e)
                {
                    MessageBox.Show("A wrong property value was supplied for " + arg.Key + "=" + arg.Value + ", error: " + e.Message);
                }
            }

            return default(T); // we did not find an argument with this propery type.
        }
    }
}
