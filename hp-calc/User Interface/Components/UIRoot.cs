namespace hp_calc.User_Interface.Components
{
    public class UIRoot : UIComponent
    {
        private UIMetadata metadata;

        public UIRoot(params UIComponent[] components) : base(components)
        {
            Transform.SetPosition(0.0f, 0.0f);
            Transform.SetSize(1.0f, 1.0f);
        }

        public void SetMetadata(UIMetadata metadata)
        {
            this.metadata = metadata;
        }
    }
}
