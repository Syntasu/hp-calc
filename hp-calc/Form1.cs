using hp_calc.UI;
using System;
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

        /// <summary>
        ///     On form1 load, setup the custom user interface stuff.
        /// </summary>
		private void Form1_Load(object sender, EventArgs e)
		{
            //Create a grid based on the forms widht/height, feed that into the UI generator.
			UIGrid grid = new UIGrid(Width, Height);
			userInterface = new UIGenerator(grid);

            //Load the XML file and generate the controls.
            UIParser parser = new UIParser();
            parser.LoadUIFromFile(userInterface);

            //Add the controls we generated to the form.
            foreach (var controls in userInterface.ControlList)
            {
                Controls.Add(controls);
            }

            KeyPreview = true;
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            userInterface.Refresh(Width, Height);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                //Add the controls we generated to the form.
                foreach (var controls in userInterface.ControlList)
                {
                    Controls.Remove(controls);
                }

                userInterface = null;

                //Create a grid based on the forms widht/height, feed that into the UI generator.
                UIGrid grid = new UIGrid(Width, Height);
                userInterface = new UIGenerator(grid);

                //Load the XML file and generate the controls.
                UIParser parser = new UIParser();
                parser.LoadUIFromFile(userInterface);

                //Add the controls we generated to the form.
                foreach (var controls in userInterface.ControlList)
                {
                    Controls.Add(controls);
                }
            }
        }

        private void Form1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }


        //private float GetRowOffset(int row)
        //{
        //    const float padding = 0.0f;
        //    const float rowSize = 0.165f;

        //    return (row * rowSize) + padding;
        //}
    }
}
