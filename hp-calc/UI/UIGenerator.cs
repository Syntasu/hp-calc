using hp_calc.Data;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace hp_calc.UI
{
	public struct UIDesc
	{
		public string Name;
		public Vector2 Position;
		public Vector2 Size;
        public bool Visible;
		public Control ControlRef;

		public UIDesc(string name, bool visible, Vector2 position, Vector2 size, Control controlRef)
		{
			Name = name;
			Position = position;
            Visible = visible;
			Size = size;
			ControlRef = controlRef;
		}
	}

	public class UIGenerator
	{
		private UIGrid grid;
        public Dictionary<string, UIDesc> Controls { get; } = new Dictionary<string, UIDesc>();

        public IEnumerable<Control> ControlList
		{
			get
			{
				foreach (var kvp in Controls)
				{
					yield return kvp.Value.ControlRef;
				}
			}
		}

		public UIGenerator(UIGrid grid)
		{
			this.grid = grid;
		}

        public void Refresh(int width, int height)
        {
            grid.Refresh(width, height);

            foreach (var control in Controls)
            {
                UIDesc desc = control.Value;

                desc.ControlRef.Location = grid.Translate(desc.Position.x, desc.Position.y);
                desc.ControlRef.Size = grid.Translate(desc.Size.x, desc.Size.y);
            }
        }

        public void AddTextbox(string name, float x, float y, float w, float h, UIArgumentList args)
		{
            Vector2 position = grid.Translate(x, y);
            Vector2 size = grid.Translate(w, h);

            TextBox textBox = new TextBox
            {
                Text = args.Get<string>(UIArgumentProperty.Value),
                Multiline = args.Get<bool>(UIArgumentProperty.Multiline),
                ReadOnly = args.Get<bool>(UIArgumentProperty.Readonly),
                Location = position,
                Size = size
            };

            //bool visibillityState = args.Get<bool>(UIArgumentProperty.Visibillity);
            Controls.Add(name, MakeUIDescription(name, new Vector2(x, y), new Vector2(w, h), textBox));
        }

		public void AddButton(string name, float x, float y, float w, float h, UIArgumentList args)
		{
            Vector2 position = grid.Translate(x, y);
            Vector2 size = grid.Translate(w, h);

            Button button = new Button
            {
                Text = args.Get<string>(UIArgumentProperty.Value),
                Location = position,
                Size = size
            };

            //bool visibillityState = args.Get<bool>(UIArgumentProperty.Visibillity);
            Controls.Add(name, MakeUIDescription(name, new Vector2(x,y), new Vector2(w, h), button));
		}

        public void AddCheckBox(string name, float x, float y, float w, float h, UIArgumentList args)
        {
            Vector2 position = grid.Translate(x, y);
            Vector2 size = grid.Translate(w, h);

            CheckBox button = new CheckBox
            {
                Text = args.Get<string>(UIArgumentProperty.Value),
                Checked = args.Get<bool>(UIArgumentProperty.Checked),
                Location = position,
                Size = size
            };

            //bool visibillityState = args.Get<bool>(UIArgumentProperty.Visibillity);
            Controls.Add(name, MakeUIDescription(name, new Vector2(x, y), new Vector2(w, h), button));
        }

        public void AddLabel(string name, float x, float y, float w, float h, UIArgumentList args)
        {
            Vector2 position = grid.Translate(x, y);
            Vector2 size = grid.Translate(w, h);

            Label button = new Label
            {
                Text = args.Get<string>(UIArgumentProperty.Value),
                Location = position,
                Size = size
            };

            //bool visibillityState = args.Get<bool>(UIArgumentProperty.Visibillity);
            Controls.Add(name, MakeUIDescription(name, new Vector2(x, y), new Vector2(w, h), button));
        }

        public void AddList(string name, float x, float y, float w, float h, UIArgumentList args)
        {
            Vector2 position = grid.Translate(x, y);
            Vector2 size = grid.Translate(w, h);

            ListBox button = new ListBox
            {
                Location = position,
                Size = size,
            };

            //bool visibillityState = args.Get<bool>(UIArgumentProperty.Visibillity);
            Controls.Add(name, MakeUIDescription(name, new Vector2(x, y), new Vector2(w, h), button));
        }

        public void AddRadio(string name, float x, float y, float w, float h, UIArgumentList args)
        {
            Vector2 position = grid.Translate(x, y);
            Vector2 size = grid.Translate(w, h);

            RadioButton button = new RadioButton
            {
                Text = args.Get<string>(UIArgumentProperty.Value),
                Checked = args.Get<bool>(UIArgumentProperty.Checked),
                Location = position,
                Size = size,
            };

            //bool visibillityState = args.Get<bool>(UIArgumentProperty.Visibillity);
            Controls.Add(name, MakeUIDescription(name, new Vector2(x, y), new Vector2(w, h), button));
        }

        private UIDesc MakeUIDescription(string name, Vector2 position, Vector2 size, Control control)
		{
			return new UIDesc(name, true, position, size, control);
		}
	}
}
