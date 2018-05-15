using System.Drawing;

namespace hp_calc.User_Interface.Data
{
    public struct Transform
    {
        public PointF Position;
        public PointF Size;

        public void SetSize(float w, float h)
        {
            Size = new PointF(w, h);
        }

        public void SetPosition(float x, float y)
        {
            Position = new PointF(x, y);
        }
    }
}
