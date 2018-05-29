using hp_calc.UI;
using System;
using System.Windows.Forms;

namespace hp_calc
{
	public partial class Form1 : Form
	{
		private UIGenerator userInterface;
        private UIGrid grid;

		public Form1()
		{
			InitializeComponent();
		}

        /// <summary>
        ///     On form1 load, setup the custom user interface stuff.
        /// </summary>
		private void Form1_Load(object sender, EventArgs e)
		{
            Text = "RPN Calculator";
            
            //Create a grid based on the forms widht/height, feed that into the UI generator.
			grid = new UIGrid(Width, Height);
            userInterface = new UIGenerator(grid);

            //Load the XML file and generate the controls.
            UIParser parser = new UIParser();
            parser.LoadLayout(userInterface);

            //Add the controls we generated to the form.
            foreach (var controls in userInterface.GetControlRenderList)
            {
                Controls.Add(controls);
            }

            KeyPreview = true;
        }

        /// <summary>
        ///     When the form1 resizes, we want to recalculate the user interface.
        /// </summary>
        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            userInterface.Refresh(Width, Height);
        }


        //TODO: DEBUG, REMOVE
        float sx = 0.5f;
        float sy = 0.5f;
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                //Add the controls we generated to the form.
                foreach (var controls in userInterface.GetControlRenderList)
                {
                    Controls.Remove(controls);
                }

                userInterface = null;

                //Create a grid based on the forms widht/height, feed that into the UI generator.
                UIGrid grid = new UIGrid(Width, Height);
                userInterface = new UIGenerator(grid);

                //Load the XML file and generate the controls.
                UIParser parser = new UIParser();
                parser.LoadLayout(userInterface);

                //Add the controls we generated to the form.
                foreach (var controls in userInterface.GetControlRenderList)
                {
                    Controls.Add(controls);
                }
            }

            if(e.KeyCode == Keys.F7)
            {
                sx += 0.01f;
                grid.Scale(sx, sy);
                userInterface.Refresh(Width, Height);
            }


            if (e.KeyCode == Keys.F8)
            {
                sx -= 0.01f;
                grid.Scale(sx, sy);
                userInterface.Refresh(Width, Height);
            }


            if (e.KeyCode == Keys.F9)
            {
                sy += 0.01f;
                grid.Scale(sx, sy);
                userInterface.Refresh(Width, Height);
            }


            if (e.KeyCode == Keys.F10)
            {
                sy -= 0.01f;
                grid.Scale(sx, sy);
                userInterface.Refresh(Width, Height);
            }
        }
    }
}
