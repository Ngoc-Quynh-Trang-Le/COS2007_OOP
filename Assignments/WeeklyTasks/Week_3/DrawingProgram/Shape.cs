using SplashKitSDK;

namespace DrawingProgram
{
    // Represents a single shape on the screen.
    // Currently implemented as a rectangle with position, color, and selection state.
    public class Shape
    {
        private float _x;
        private float _y;
        private int _width = 50; //default size
        private int _height = 50;
        private Color _color;
        private bool _selected; // Default selection state is false
                                // Bcz a Boolean field is initialized to false by default.

        // Default constructor: creates a new shape at (0,0) with a Chocolate color
        public Shape()
        {
            _color = Color.Chocolate; // First name starts with "T" -> Chocolate
            _x = 0;
            _y = 0;
        }

        // X-coordinate of the top-left corner of the shape
        public float X
        {
            get { return _x; }
            set { _x = value; }
        }

        // Y-coordinate of the top-left corner of the shape
        public float Y
        {
            get { return _y; }
            set { _y = value; }
        }

        // Indicates whether this shape is currently selected
        public bool Selected
        {
            get { return _selected; }
            set { _selected = value; }
        }

        // Draws the shape on the screen.
        // If selected, also draws an outline around it.
        public void Draw()
        {
            // Fill the rectangle with the current color
            SplashKit.FillRectangle(_color, _x, _y, _width, _height);

            // If shape is selected, draw an outline around it
            if (_selected)
            {
                DrawOutline();
            }
        }

        // Checks if a given point lies inside this shape
        public bool IsAt(Point2D pt) // param name="pt": The point to check
        {
            return SplashKit.PointInRectangle(pt, SplashKit.RectangleFrom(X, Y, _width, _height));
            // Return 'True' if the point is inside the shape's bounds
        }

        // Draws a black rectangular outline around the shape.
        // The outline padding is based on student ID digit.
        private void DrawOutline()
        {
            const int studentID_lastDigit = 3;
            const int PADDING = 5 + studentID_lastDigit;

            Rectangle rect = SplashKit.RectangleFrom(
                X - PADDING / 2,
                Y - PADDING / 2,
                _width + PADDING,
                _height + PADDING
            );

            SplashKit.DrawRectangle(Color.Black, rect);
        }
    }
}