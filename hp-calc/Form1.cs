using hp_calc.UI;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace hp_calc
{
	public partial class Form1 : Form
	{
		private UIGenerator userInterface;

		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			UIGrid grid = new UIGrid(this, 32);
			userInterface = new UIGenerator(grid);

			userInterface.AddTextbox("input", new Point(0, 0), new Point(32, 8));

			userInterface.AddButton("one", new Point(1, 9), new Point(6, 14), "1", null);
			userInterface.AddButton("two", new Point(7, 9), new Point(12, 14), "2", null);
			userInterface.AddButton("three", new Point(13, 9), new Point(18, 14), "3", null);

			userInterface.AddButton("four", new Point(1, 15), new Point(6, 20), "4", null);
			userInterface.AddButton("five", new Point(7, 15), new Point(12, 20), "5", null);
			userInterface.AddButton("six", new Point(13, 15), new Point(18, 20), "6", null);

			userInterface.AddButton("seven", new Point(1, 21), new Point(6, 26), "7", null);
			userInterface.AddButton("eight", new Point(7, 21), new Point(12, 26), "8", null);
			userInterface.AddButton("nine", new Point(13, 21), new Point(18, 26), "9", null);

			userInterface.AddButton("plus", new Point(19, 9), new Point(24, 14), "+", null);
			userInterface.AddButton("minus", new Point(25, 9), new Point(30, 14), "-", null);

			userInterface.AddButton("divide", new Point(19, 15), new Point(24, 20), "÷", null);
			userInterface.AddButton("times", new Point(25, 15), new Point(30, 20), "×", null);

			AddGeneratedControls();	
		}

		private void Form1_ResizeEnd(object sender, EventArgs e)
		{
			userInterface.Refresh(this);
		}

		private void AddGeneratedControls()
		{
			foreach (var controls in userInterface.ControlList)
			{
				Controls.Add(controls);
			}
		}
	}
}
