using hp_calc.Flow;
using System.Windows.Forms;

namespace hp_calc.UI
{
    public class UIEvents
    {
        private UIGenerator generator;

        public UIEvents(UIGenerator generator)
        {
            this.generator = generator;

            //Subscription to the Show Stack checkbox
            MessagePump.Subscribe("show_stack", "checked", ShowStack);

            //Register all nummeric buttons.
            MessagePump.Subscribe("one", "click", (n, a, b) => NummericButtons(1));
            MessagePump.Subscribe("two", "click", (n, a, b) => NummericButtons(2));
            MessagePump.Subscribe("three", "click", (n, a, b) => NummericButtons(3));
            MessagePump.Subscribe("four", "click", (n, a, b) => NummericButtons(4));
            MessagePump.Subscribe("five", "click", (n, a, b) => NummericButtons(5));
            MessagePump.Subscribe("six", "click", (n, a, b) => NummericButtons(6));
            MessagePump.Subscribe("seven", "click", (n, a, b) => NummericButtons(7));
            MessagePump.Subscribe("eight", "click", (n, a, b) => NummericButtons(8));
            MessagePump.Subscribe("nine", "click", (n, a, b) => NummericButtons(9));
            MessagePump.Subscribe("zero", "click", (n, a, b) => NummericButtons(0));
        }

        private void ShowStack(string name, string action, object[] args)
        {
            if (args.Length <= 0) return;

            bool showState = (bool)args[0];

            generator.SetControlVisibility("stack_desc", showState);
            generator.SetControlVisibility("stack_list", showState);
            generator.SetControlVisibility("radio_array", showState);
            generator.SetControlVisibility("radio_list", showState);
            generator.SetControlVisibility("radio_clist", showState);
        }

        private void NummericButtons(int numberOfButton)
        {
            TextBox input = generator.GetControlReference<TextBox>("input");

            if(input != null)
            {
                string text = input.Text;
                text += numberOfButton.ToString();

                input.Text = text;
            }
        }


    }
}
