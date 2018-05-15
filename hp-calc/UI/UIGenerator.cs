using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace hp_calc.UI
{
	public struct UIDesc
	{
		public string Name;
		public Point Position;
		public Size Size;
		public Control ControlRef;

		public UIDesc(string name, Point position, Size size, Control controlRef)
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
					UIDesc desc = kvp.Value;
					yield return desc.ControlRef;
				}
			}
		}

		public UIGenerator(UIGrid grid)
		{
			this.grid = grid;
		}

        //public void Refresh(Form1 form)
        //{
        //    grid.Refresh(form);

        //    foreach (var control in controls)
        //    {
        //        UIDesc description = control.Value;

        //        Tuple<Point, Size> postionAndSize = grid.GetPositionAndSize(description.Start, description.End);

        //        description.ControlRef.Location = postionAndSize.Item1;
        //        description.ControlRef.Size = postionAndSize.Item2;
        //    }
        //}

        public void AddTextbox(string name, float x, float y, float w, float h)
		{
            Point position = grid.Translate<Point>(x, y);
            Size size = grid.Translate<Size>(w, h);

            TextBox textBox = new TextBox
            {
                Text = "test",
                Multiline = true,
                Location = position,
                Size = size
            };

            controls.Add(name, MakeUIDescription(name, position, size, textBox));
        }

		public void AddButton(string name, float x, float y, float w, float h)
		{
            Point position = grid.Translate<Point>(x, y);
            Size size = grid.Translate<Size>(w, h);

            Button button = new Button
            {
                Text = "*",
                Location = position,
                Size = size
            };

            controls.Add(name, MakeUIDescription(name, position, size, button));
		}

		private UIDesc MakeUIDescription(string name, Point position, Size size, Control control)
		{
			return new UIDesc(name, position, size, control);
		}
	}
}
