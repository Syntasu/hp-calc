using System.Drawing;
using System.Windows.Forms;

namespace hp_calc.UI
{
	public class UIGrid
	{
		private int rows;
		private int cols;
		private Panel parent;
	
		public UIGrid(Panel parent, int rows, int cols)
		{
			this.rows = rows;
			this.cols = cols;
			this.parent = parent;

			MessageBox.Show(parent.Location.ToString());
		}

		public Point GetPosition(int rows, int cols)
		{
			int rowPosition = parent.Height / rows;
			int colPosition = parent.Width / cols;

			return new Point(colPosition, rowPosition);
		}
	}
}
