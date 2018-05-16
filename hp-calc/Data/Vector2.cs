using System.Drawing;

namespace hp_calc.Data
{
    public class Vector2
    {
        public float x;
        public float y;

        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public void Multiply(Vector2 b)
        {
            x *= b.x;
            y *= b.y;
        }

        public void Scalar(float scalar)
        {
            x *= scalar;
            y *= scalar;
        }

        public static implicit operator Point(Vector2 vector)
        {
            return new Point((int)vector.x, (int)vector.y);
        }

        public static implicit operator Size(Vector2 vector)
        {
            return new Size((int)vector.x, (int)vector.y);
        }
    }
}
