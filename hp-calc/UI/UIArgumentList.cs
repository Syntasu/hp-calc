using hp_calc.XML;
using System;
using System.Collections.Generic;

namespace hp_calc.UI
{
    public enum UIArgumentProperty
    {
        Value, 
        Multiline,
        Readonly,
        Checked,
        Visibillity
    }

    public class UIArgumentList
    {
        private IDictionary<UIArgumentProperty, object> arguments;

        public UIArgumentList(IList<Option> options)
        {
            arguments = new Dictionary<UIArgumentProperty, object>();

            foreach (Option option in options)
            {
                string propertyName = option.Type.ToLower();
                bool validProperty = Enum.TryParse(propertyName, true, out UIArgumentProperty prop);

                if(!validProperty)
                {
                    throw new ArgumentException("The given property is an unknown property.");
                }

                arguments.Add(prop, option.Text);
            }
        }

        public T Get<T>(UIArgumentProperty prop)
        {
            foreach (var arg in arguments)
            {
                if (arg.Key != prop) continue;

                return (T)Convert.ChangeType(arg.Value, typeof(T));
            }

            return default(T); // we did not find an argument with this propery type.
        }
    }
}
