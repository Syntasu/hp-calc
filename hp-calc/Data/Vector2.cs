using System;
using System.Drawing;
using System.Linq;

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

        public static Vector2 FromString(string input)
        {
            string[] values = new string(input.ToCharArray()
                .Where(c => !Char.IsWhiteSpace(c))
                .Where(c => !Char.Equals('f', c))
                .ToArray())
                .Split(',');

            if(values.Length < 2)
            {
                throw new ArgumentException("Cannot parse Vector2 if X and/or Y components are not defined.");
            }

            bool parsedX = float.TryParse(values[0], out float x);
            bool parsedY = float.TryParse(values[1], out float y);

            if(!parsedX || !parsedY)
            {
                throw new ArgumentException("Given values cannot be parsed to an Vector2 (to a float).");
            }

            return new Vector2(x, y);
        }
    }
}
