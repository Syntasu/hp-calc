using hp_calc.Data;
using System.Collections.Generic;
using System.Windows.Forms;

namespace hp_calc.UI
{
	public struct UIDesc
	{
		public string Name;
		public Vector2 Position;
		public Vector2 Size;
		public Control ControlRef;

		public UIDesc(string name, Vector2 position, Vector2 size, Control controlRef)
		{
			Name = name;
			Position = position;
			Size = size;
			ControlRef = controlRef;
		}
	}

	public class UIGenerator
	{
		private UIGrid grid;

		private Dictionary<string, UIDesc> controls = new Dictionary<string, UIDesc>();
		public Dictionary<string, UIDesc> Controls
		{
			get
			{
				return controls;
			}
		}

		public IEnumerable<Control> ControlList
		{
			get
			{
				foreach (var kvp in controls)
				{
					yield return kvp.Value.ControlRef;
				}
			}
		}

		public UIGenerator(UIGrid grid)
		{
			this.grid = grid;
		}

        public void Resize(int width, int height)
        {
            
        }

        public void Refresh(int width, int height)
        {
            grid.Refresh(width, height);

            foreach (var control in controls)
            {
                UIDesc desc = control.Value;

                desc.ControlRef.Location = grid.Translate(desc.Position.x, desc.Position.y);
                desc.ControlRef.Size = grid.Translate(desc.Size.x, desc.Size.y);
            }
        }

        public void AddTextbox(string name, float x, float y, float w, float h)
		{
            Vector2 position = grid.Translate(x, y);
            Vector2 size = grid.Translate(w, h);

            TextBox textBox = new TextBox
            {
                Text = "test",
                Multiline = true,
                Location = position,
                Size = size
            };

            controls.Add(name, MakeUIDescription(name, new Vector2(x, y), new Vector2(w, h), textBox));
        }

		public void AddButton(string name, float x, float y, float w, float h)
		{
            Vector2 position = grid.Translate(x, y);
            Vector2 size = grid.Translate(w, h);

            Button button = new Button
            {
                Text = "*",
                Location = position,
                Size = size
            };

            controls.Add(name, MakeUIDescription(name, new Vector2(x,y), new Vector2(w, h), button));
		}

		private UIDesc MakeUIDescription(string name, Vector2 position, Vector2 size, Control control)
		{
			return new UIDesc(name, position, size, control);
		}
	}
}
