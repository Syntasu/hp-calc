using System;
using System.Drawing;

namespace hp_calc.UI
{
	public class UIGrid
	{
		private int resolution = 16;
		private int width;
		private int height;

		private int stepSizeX
		{
			get
			{
				return width / resolution;
			}

		}

		private int stepSizeY
		{
			get
			{
				return height / resolution;
			}

		}


		public UIGrid(Form1 form, int resolution)
		{
			this.resolution = resolution;

			width = form.Width;
			height = form.Height;
		}

		public Tuple<Point, Size> GetPositionAndSize(int startX, int startY, int endX, int endY)
		{
			return new Tuple<Point, Size>(GetPosition(startX, startY), GetSize(startX, startY, endX, endY));
		}

		public Tuple<Point, Size> GetPositionAndSize(Point from, Point to)
		{
			return GetPositionAndSize(from.X, from.Y, to.X, to.Y);
		}

		public Point GetPosition(int x, int y)
		{
			if (x >= resolution || x < 0 ||
				y >= resolution || y < 0)
			{
				return new Point(0, 0);
			}

			return new Point(x * stepSizeX, y * stepSizeY);
		}

		public Size GetSize(int startX, int startY, int endX, int endY)
		{
			//Calculate the difference in the xy axes.
			int dx = Math.Abs(startX - endX);
			int dy = Math.Abs(startY - endY);

			//Ensure element is atleast _one_ unit big.
			if(dx < 1)
			{
				dx = 1;
			}

			if(dy < 1)
			{
				dy = 1;
			}

			return new Size(dx * stepSizeX, dy * stepSizeY);
		}

	}
}