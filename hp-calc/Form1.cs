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
			UIGrid grid = new UIGrid(Width, Height);
			userInterface = new UIGenerator(grid);

            UIParser parser = new UIParser();
            parser.LoadUIFromFile();

            //Top row
            userInterface.AddTextbox("input", 0.0f, GetRowOffset(0), 0.66f, 0.165f);

            //Row 1
            userInterface.AddButton("one", 0.0f,     GetRowOffset(1), 0.165f, 0.165f);
            userInterface.AddButton("two", 0.165f,   GetRowOffset(1), 0.165f, 0.165f);
            userInterface.AddButton("three", 0.33f,  GetRowOffset(1), 0.165f, 0.165f);
            userInterface.AddButton("times", 0.495f, GetRowOffset(1), 0.165f, 0.165f);

            //Row 2
            userInterface.AddButton("four", 0.0f,    GetRowOffset(2), 0.165f, 0.165f);
            userInterface.AddButton("five", 0.165f,  GetRowOffset(2), 0.165f, 0.165f);
            userInterface.AddButton("six", 0.33f,    GetRowOffset(2), 0.165f, 0.165f);
            userInterface.AddButton("minus", 0.495f, GetRowOffset(2), 0.165f, 0.165f);

            //Row 3
            userInterface.AddButton("seven", 0.0f,   GetRowOffset(3), 0.165f, 0.165f);
            userInterface.AddButton("eight", 0.165f, GetRowOffset(3), 0.165f, 0.165f);
            userInterface.AddButton("nine", 0.33f,   GetRowOffset(3), 0.165f, 0.165f);
            userInterface.AddButton("plus", 0.495f,  GetRowOffset(3), 0.165f, 0.165f);
      
            //Row 4
            userInterface.AddButton("null0", 0.0f,  GetRowOffset(4), 0.165f, 0.165f);
            userInterface.AddButton("zero", 0.165f, GetRowOffset(4), 0.165f, 0.165f);
            userInterface.AddButton("null1", 0.33f, GetRowOffset(4), 0.165f, 0.165f);
            userInterface.AddButton("is", 0.495f,   GetRowOffset(4), 0.165f, 0.165f);







            //userInterface.AddButton("two", new Point(7, 9), new Point(12, 14), "2", null);
            //userInterface.AddButton("three", new Point(13, 9), new Point(18, 14), "3", null);

            //         //Row 2
            //userInterface.AddButton("four", new Point(1, 15), new Point(6, 20), "4", null);
            //userInterface.AddButton("five", new Point(7, 15), new Point(12, 20), "5", null);
            //userInterface.AddButton("six", new Point(13, 15), new Point(18, 20), "6", null);

            //         //Row 3
            //userInterface.AddButton("seven", new Point(1, 21), new Point(6, 26), "7", null);
            //userInterface.AddButton("eight", new Point(7, 21), new Point(12, 26), "8", null);
            //userInterface.AddButton("nine", new Point(13, 21), new Point(18, 26), "9", null);

            //         //Row 4
            //userInterface.AddButton("plus", new Point(19, 9), new Point(24, 14), "+", null);
            //userInterface.AddButton("minus", new Point(25, 9), new Point(30, 14), "-", null);

            //         //row 4
            //userInterface.AddButton("divide", new Point(19, 15), new Point(24, 20), "÷", null);
            //userInterface.AddButton("times", new Point(25, 15), new Point(30, 20), "×", null);

            AddGeneratedControls();	
		}

        private float GetRowOffset(int row)
        {
            const float padding = 0.0f;
            const float rowSize = 0.165f;

            return (row * rowSize) + padding;
        }

		private void Form1_ResizeEnd(object sender, EventArgs e)
		{
			userInterface.Refresh(Width, Height);
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
