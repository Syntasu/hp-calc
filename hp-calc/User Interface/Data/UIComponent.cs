using hp_calc.User_Interface.Data;
using System.Collections.Generic;

namespace hp_calc.User_Interface
{
    public abstract class UIComponent
    {
        public Transform Transform = new Transform();
        public UIComponent Parent;
        public IList<UIComponent> Children;

        public UIComponent(params UIComponent[] components)
        {
            Children = new List<UIComponent>();

            //Add given components
            if (components != null && components.Length > 0)
            {
                //Add passed components as children
                foreach (UIComponent component in components)
                {
                    component.Parent = this;
                    Children.Add(component);
                }
            }
        }

        public void AddChildComponent(UIComponent component)
        {
            component.Parent = this;
            Children.Add(component);
        }


        public virtual void Build()
        {

        }
    }
}
