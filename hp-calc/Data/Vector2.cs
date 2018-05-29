using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace hp_calc.Data
{
    /// <summary>
    ///     A representation of a 2D point on a windows form.
    /// </summary>
    public class Vector2
    {
        public float x;
        public float y;

        /// <summary>
        ///     Consturctor for new vector.
        /// </summary>
        /// <param name="x"> The point on the x axis </param>
        /// <param name="y"> The point on the y axia </param>
        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        ///     Multiply THIS vector by vector B.
        /// </summary>
        /// <param name="b">Vector to multiply by.</param>
        public void Multiply(Vector2 b)
        {
            x *= b.x;
            y *= b.y;
        }

        /// <summary>
        ///     Divide the values of this vector by vector B.
        /// </summary>
        /// <param name="b"> The vector we want to define by.</param>
        public void Divide(Vector2 b)
        {
            x /= b.x;
            y /= b.y;
        }

        /// <summary>
        ///     Scale the vector by some scalar value.
        /// </summary>
        /// <param name="scalar"> The scalar.</param>
        public void Scalar(float scalar)
        {
            x *= scalar;
            y *= scalar;
        }

        /// <summary>
        ///     Allow for implicit conversions to a Point class.
        /// </summary>
        /// <param name="vector"> The vector we want to convert to Point. </param>
        public static implicit operator Point(Vector2 vector)
        {
            return new Point((int)vector.x, (int)vector.y);
        }

        /// <summary>
        ///     Allow for implicit conversion to a Size class.
        /// </summary>
        /// <param name="vector"> The vector we want to convert to a Size class.</param>
        public static implicit operator Size(Vector2 vector)
        {
            return new Size((int)vector.x, (int)vector.y);
        }

        /// <summary>
        ///     Generate a Vector2 from a string. Ex: "0.5f, 0.33f".
        /// </summary>
        /// <param name="input"> The string we want to parse to a Vector2.</param>
        /// <returns>A new instance of a Vector2.</returns>
        public static Vector2 FromString(string input)
        {
            //Strip any whitespace or 'f' character from the string.
            //Then put it back to an array and split it by a comma.
            string[] values = new string(input.ToCharArray()
                .Where(c => !Char.IsWhiteSpace(c))
                .Where(c => !Char.Equals('f', c))
                .ToArray())
                .Split(',');

            //Check if we indeed have 2 values (lhs and rhs).
            if(values.Length != 2)
            {
                MessageBox.Show("Layout error; string to Vector2 failed, expected left and right hand side arguments, got: " + input, "Layout parsing error");
                Application.Exit();
                return new Vector2(0, 0);
            }

            //Parse the string to an valid float, do some error checking.
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
