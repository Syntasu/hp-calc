using hp_calc.Data;

namespace hp_calc.UI
{
    public class UIGrid
    {
        /// <summary>
        ///     The vector we want to scale the grid by.
        /// </summary>
        private Vector2 scaleVector;

        /// <summary>
        ///     The current (scaled) dimension we are using for translating the points.
        /// </summary>
        private Vector2 dimension;

        public UIGrid(int width, int height)
        {
            Resize(width, height);
            Scale(1.0f, 1.0f);
        }

        /// <summary>
        ///     Resize the grid to a new width and height.
        /// </summary>
        /// <param name="width"> The new width </param>
        /// <param name="height"> The new height </param>
        public void Resize(int width, int height)
        {
            dimension = new Vector2(width, height);
        }

        /// <summary>
        ///     Scale the grid in some x or y axis.
        /// </summary>
        /// <param name="sx"></param>
        /// <param name="sy"></param>
        public void Scale(float sx, float sy)
        {
            scaleVector = new Vector2(sx, sy);
        }

        /// <summary>
        ///     Refresh the dimensions to a new width or height.
        /// </summary>
        /// <param name="width"> The new width </param>
        /// <param name="height"> The new height </param>
        public void Refresh(int width, int height)
        {
            dimension = new Vector2(
                width * scaleVector.x, 
                height * scaleVector.y
            );
        }

        /// <summary>
        ///     Turn a given point/size into a Vector2 placed on a grid.
        /// </summary>
        /// <param name="x">The x axis we want to translate.</param>
        /// <param name="y">The y axis we want to translate</param>
        /// <returns>A new Vectoe2 that is placed on a grid.</returns>
        public Vector2 Translate(float x, float y)
        {
            return new Vector2(
                dimension.x * x,
                dimension.y * y
            );
        }
        
    }
}