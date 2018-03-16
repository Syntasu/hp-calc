using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace hp_calc.UI
{
	public class UIGenerator
	{
		private UIGrid grid;

		private Dictionary<string, Control> controls = new Dictionary<string, Control>();
		public Dictionary<string, Control> Controls
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
					yield return kvp.Value;
				}
			}
		}

		public UIGenerator(UIGrid grid)
		{
			this.grid = grid;
		}

		public void AddTextbox(string name, Point from, Point to)
		{
			Tuple<Point, Size> postionAndSize = grid.GetPositionAndSize(from, to);

			TextBox textBox = new TextBox();
			textBox.Text = "azippityzaity";
			textBox.Multiline = true;
			textBox.Location = postionAndSize.Item1;
			textBox.Size = postionAndSize.Item2;

			controls.Add(name, textBox);
		}

		public void AddButton(string name, Point from, Point to, string text, Action<object, EventArgs> callback)
		{
			Tuple<Point, Size> postionAndSize = grid.GetPositionAndSize(from, to);

			Button button = new Button();
			button.Text = text;
			button.Location = postionAndSize.Item1;
			button.Size = postionAndSize.Item2;

			controls.Add(name, button);
		}
	}
}
