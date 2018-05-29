using hp_calc.XML;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace hp_calc.UI
{
    /// <summary>
    ///     Enum for the types of properties we allow to be used.
    /// </summary>
    public enum UIArgumentProperty
    {
        Value, 
        Multiline,
        Readonly,
        Checked,
        Visible,
    }

    /// <summary>
    ///     An adapter class for converting IList<Options> to something we can interpret.
    ///     IList<Options> originates from deserializing the XML document.
    /// </summary>
    public class UIArgumentList
    {
        /// <summary>
        ///     The arguments we've gotten from the XML file.
        /// </summary>
        private IDictionary<UIArgumentProperty, object> arguments;

        /// <summary>
        ///     Populate the arguments dictionary, by converting the options array to something we can interpret.
        /// </summary>
        /// <param name="options"> The options array/list we obtained from deserialzing the XML.</param>
        public void Populate(IList<Option> options)
        {
            arguments = new Dictionary<UIArgumentProperty, object>();

            foreach (Option option in options)
            {
                //Try to match the string with the enum value(s).
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

        /// <summary>
        ///     Grab an argument from this list.
        /// </summary>
        /// <typeparam name="T"> The type we want to receive (if the value is present).</typeparam>
        /// <param name="prop">The property we need to find in the arguement list.</param>
        /// <returns>The value form the list as T.</returns>
        public T Get<T>(UIArgumentProperty prop)
        {
            //Don't bother searching if we don't have any arguments.
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
