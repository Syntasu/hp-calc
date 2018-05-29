using hp_calc.Data;

namespace hp_calc.UI
{
    public class UIGrid
    {
        private Vector2 scaleVector;
        private Vector2 intialDimensions;
        private Vector2 currentDimensions;

        public UIGrid(int width, int height)
        {
            Resize(width, height);
        }

        public void Resize(int width, int height)
        {
            currentDimensions = new Vector2(width, height);
            intialDimensions = currentDimensions;

            Scale(1.0f, 1.0f);
        }

        public void Scale(float sx, float sy)
        {
            scaleVector = new Vector2(sx, sy);
        }

        public void Refresh(int width, int height)
        {
            currentDimensions = new Vector2(
                width * scaleVector.x, 
                height * scaleVector.y
            );
        }

        public Vector2 Translate(float x, float y)
        {
            return new Vector2(
                currentDimensions.x * x,
                currentDimensions.y * y
            );
        }
        
    }
}