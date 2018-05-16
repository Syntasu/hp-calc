using hp_calc.Data;

namespace hp_calc.UI
{
    public class UIGrid
    {
        private Vector2 intialDimensions;
        private Vector2 currentDimensions;

        private Vector2 scalingVector
        {
            get
            {
                float x = currentDimensions.x / intialDimensions.x;
                float y = currentDimensions.y / intialDimensions.y;

                return new Vector2(x, y);
            }
        }

        public UIGrid(int width, int height)
        {
            currentDimensions = new Vector2(width, height);
            intialDimensions = currentDimensions;
        }

        public void Refresh(int width, int height)
        {
            currentDimensions = new Vector2(width, height);
        }

        public Vector2 Translate(float x, float y)
        {
            Vector2 translation = new Vector2(
                currentDimensions.x * x,
                currentDimensions.y * y
            );

            return translation;
        }
        
    }
}