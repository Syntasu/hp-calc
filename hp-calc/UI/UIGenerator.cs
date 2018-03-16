using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace hp_calc.UI
{
	public struct UIDesc
	{
		public string Name;
		public Point Start;
		public Point End;
		public Control ControlRef;

		public UIDesc(string name, Point start, Point end, Control controlRef)
		{
			Name = name;
			Start = start;
			End = end;
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
	
		public void Refresh(Form1 form)
		{
			grid.Refresh(form);

			foreach (var control in controls)
			{
				UIDesc description = control.Value;

				Tuple<Point, Size> postionAndSize = grid.GetPositionAndSize(description.Start, description.End);

				description.ControlRef.Location = postionAndSize.Item1;
				description.ControlRef.Size = postionAndSize.Item2;
			}
		}

		public void AddTextbox(string name, Point from, Point to)
		{
			Tuple<Point, Size> postionAndSize = grid.GetPositionAndSize(from, to);

			TextBox textBox = new TextBox();
			textBox.Text = "azippityzaity";
			textBox.Multiline = true;
			textBox.Location = postionAndSize.Item1;
			textBox.Size = postionAndSize.Item2;

			controls.Add(name, MakeDescription(name, from, to, textBox));
		}

		public void AddButton(string name, Point from, Point to, string text, Action<object, EventArgs> callback)
		{
			Tuple<Point, Size> postionAndSize = grid.GetPositionAndSize(from, to);

			Button button = new Button();
			button.Text = text;
			button.Location = postionAndSize.Item1;
			button.Size = postionAndSize.Item2;

			controls.Add(name, MakeDescription(name, from, to, button));
		}

		private UIDesc MakeDescription(string name, Point from, Point to, Control control)
		{
			return new UIDesc(name, from, to, control);
		}
	}
}
