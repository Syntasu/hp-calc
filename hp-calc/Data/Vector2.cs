using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

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

        public void Divide(Vector2 b)
        {
            x /= b.x;
            y /= b.y;
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

        public static Vector2 FromString(string input)
        {
            string[] values = new string(input.ToCharArray()
                .Where(c => !Char.IsWhiteSpace(c))
                .Where(c => !Char.Equals('f', c))
                .ToArray())
                .Split(',');

            if(values.Length < 2)
            {
                MessageBox.Show("Layout error; string to Vector2 failed, expected left and right hand side arguments, got: " + input, "Layout parsing error");
                Application.Exit();
                return new Vector2(0, 0);
            }

            bool parsedX = float.TryParse(values[0], out float x);
            bool parsedY = float.TryParse(values[1], out float y);

            if(!parsedX || !parsedY)
            {
                MessageBox.Show("Layout error; could not parse string to Vector2, input: " + input, "Layout parsing error");
                Application.Exit();
                return new Vector2(0, 0);
            }

            return new Vector2(x, y);
        }
    }
}
