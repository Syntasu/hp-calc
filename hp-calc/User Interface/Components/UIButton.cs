using hp_calc.User_Interface.Data;
using System.Windows.Forms;

namespace hp_calc.User_Interface.Components
{
    public class UIButton : UIComponent, IRenderable
    {
        public UIButton(params UIComponent[] components) : base(components) { }

        public void Render(dynamic args)
        {
            MessageBox.Show("hi");
            Form1.Instance.AddComponent(new Button());
        }
    }
}
