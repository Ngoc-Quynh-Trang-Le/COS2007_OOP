using System;
using System.Collections.Generic;
using SplashKitSDK;

namespace DrawingProgram
{
    public class Program
    {
        private enum ShapeKind
        {
            Circle,
            Rectangle,
            Line
        }

        public static void Main()
        {
            Window window = new Window("Drawing Program", 800, 600);
            Drawing myDrawing = new Drawing();
            ShapeKind kindToAdd = ShapeKind.Circle;
            int linesDrawn = 0;

            // Main event loop
            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();

                if (SplashKit.KeyTyped(KeyCode.RKey))
                {
                    kindToAdd = ShapeKind.Rectangle;
                }
                if (SplashKit.KeyTyped(KeyCode.CKey))
                {
                    kindToAdd = ShapeKind.Circle;
                }
                if (SplashKit.KeyTyped(KeyCode.LKey))
                {
                    kindToAdd = ShapeKind.Line;
                }

                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    Shape? myShape = null;
                    switch (kindToAdd)
                    {
                        case ShapeKind.Rectangle:
                            myShape = new MyRectangle();
                            break;
                        case ShapeKind.Circle:
                            myShape = new MyCircle();
                            break;
                        case ShapeKind.Line:
                            if (linesDrawn < 3)
                            {
                                myShape = new MyLine();
                                linesDrawn++;
                            }
                            break;
                    }

                    if (myShape != null)
                    {
                        myShape.X = SplashKit.MouseX();
                        myShape.Y = SplashKit.MouseY();
                        myDrawing.AddShape(myShape);
                    }
                }

                if (SplashKit.KeyTyped(KeyCode.SpaceKey))
                {
                    myDrawing.Background = SplashKit.RandomRGBColor(255);
                }

                if (SplashKit.MouseClicked(MouseButton.RightButton))
                {
                    Point2D pt = new Point2D();
                    pt.X = SplashKit.MouseX();
                    pt.Y = SplashKit.MouseY();

                    myDrawing.SelectShapesAt(pt);
                }

                // Change background to a new random color
                if (SplashKit.KeyTyped(KeyCode.DeleteKey) || SplashKit.KeyTyped(KeyCode.BackspaceKey))
                {
                    // Get list of selected shapes
                    List<Shape> selectedShapes = myDrawing.SelectedShapes;

                    // Remove each selected shape
                    foreach (Shape shape in selectedShapes)
                    {
                        myDrawing.RemoveShape(shape);
                    }
                }

                myDrawing.Draw(); // Draw everything
                SplashKit.RefreshScreen(60); // Refresh the screen at 60 FPS
            } while (!window.CloseRequested);
        }
    }
}
