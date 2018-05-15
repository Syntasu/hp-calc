using System;
using System.Drawing;

namespace hp_calc.UI
{
    public class UIGrid
    {
        private int resolution = 16;
        private int width;
        private int height;

        public UIGrid(Form1 form, int resolution)
        {
            this.resolution = resolution;

            width = form.Width;
            height = form.Height;
        }

        public void Refresh(Form1 form)
        {
            width = form.Width;
            height = form.Height;
        }

        public T Translate<T>(float a, float b)
        {
            int tx = (int)(width * a);
            int ty = (int)(height * b);

            return (T)Activator.CreateInstance(typeof(T), new object[] { tx, ty });
        }
        
    }
}