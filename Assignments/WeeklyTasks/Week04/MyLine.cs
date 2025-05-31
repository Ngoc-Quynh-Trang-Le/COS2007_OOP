using SplashKitSDK;

namespace DrawingProgram;

/// <summary>
/// Simple line shape.
/// </summary>
public class MyLine : Shape
{
    /// <summary>
    /// X coordinate of the end point.
    /// </summary>
    public float EndX { get; set; } = 50;

    /// <summary>
    /// Y coordinate of the end point.
    /// </summary>
    public float EndY { get; set; } = 50;

    /// <summary>
    /// Creates a red line with a fixed end point.
    /// </summary>
    public MyLine() : base(Color.Red)
    {
    }

    /// <inheritdoc />
    public override void Draw()
    {
        SplashKit.DrawLine(Color, X, Y, EndX, EndY);
        if (Selected)
        {
            DrawOutline();
        }
    }

    /// <inheritdoc />
    public override void DrawOutline()
    {
        SplashKit.FillCircle(Color.Black, X, Y, 2);
        SplashKit.FillCircle(Color.Black, EndX, EndY, 2);
    }

    /// <inheritdoc />
    public override bool IsAt(Point2D pt)
    {
        return SplashKit.PointOnLine(pt, SplashKit.LineFrom(X, Y, EndX, EndY));
    }
}
