using System.Collections.Generic;
using SplashKitSDK;

namespace DrawingProgram
{
    // Represents a drawing area containing multiple shapes.
    // Manages adding, removing, selecting, and drawing shapes.
    public class Drawing
    {
        private readonly List<Shape> _shapes; // Collection of shapes in the drawing

        private Color _background; // Background color of the canvas

        // Initializes a new Drawing with a specified background color
        public Drawing(Color background)
        {
            _shapes = new List<Shape>();
            _background = background;
        }

        // Initializes a new Drawing with a Default white background
        public Drawing() : this(Color.White) { }

        public int ShapeCount => _shapes.Count; // Gets the number of shapes currently in the drawing

        // Gets or sets the background color of the drawing
        public Color Background
        {
            get { return _background; }
            set { _background = value; }
        }

        // Adds a new shape to the drawing
        public void AddShape(Shape s) // param name="s": The shape 
        {
            _shapes.Add(s);
        }

        // Removes a specific shape from the drawing
        public void RemoveShape(Shape s)
        {
            _shapes.Remove(s);
        }

        // Toggles selection on any shape that contains the given point
        public void SelectShapesAt(Point2D pt) // param name="pt": The point to check (e.g., mouse click)
        {
            foreach (Shape shape in _shapes)
            {
                if (shape.IsAt(pt))
                {
                    shape.Selected = !shape.Selected; // Toggle selection
                }
            }
        }

        // Returns a list of all currently selected shapes
        public List<Shape> SelectedShapes
        {
            get
            {
                List<Shape> result = new List<Shape>();

                foreach (Shape shape in _shapes)
                {
                    if (shape.Selected)
                    {
                        result.Add(shape);
                    }
                }

                return result;
            }
        }

        // Draws the entire drawing: clears screen with background and draws each shape
        public void Draw()
        {
            // Clear screen with current background color
            SplashKit.ClearScreen(_background);

            // Draw each shape in the _shapes collection
            foreach (Shape shape in _shapes)
            {
                shape.Draw();
            }
        }
    }
}
