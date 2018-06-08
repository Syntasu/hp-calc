using hp_calc.Flow;

namespace hp_calc.UI
{
    public class UIEvents
    {
        private UIGenerator generator;

        public UIEvents(UIGenerator generator)
        {
            this.generator = generator;
            MessagePump.Subscribe("show_stack", "checked", ShowStack);
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


    }
}
