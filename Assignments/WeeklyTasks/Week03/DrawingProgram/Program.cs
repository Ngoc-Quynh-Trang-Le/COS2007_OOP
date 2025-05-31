using System;
using System.Collections.Generic;
using SplashKitSDK;

namespace DrawingProgram
{
    public class Program
    {
        public static void Main()
        {
            Window window = new Window("Drawing Program", 800, 600); // Initialize SplashKit window
            Drawing myDrawing = new Drawing(); // Create drawing context with default white background

            // Main event loop
            do
            {
                SplashKit.ProcessEvents(); // Must be called every frame to process system events
                SplashKit.ClearScreen();

                // Handle user input
                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    Shape myShape = new Shape();
                    myShape.X = SplashKit.MouseX();
                    myShape.Y = SplashKit.MouseY();
                    myDrawing.AddShape(myShape);
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
