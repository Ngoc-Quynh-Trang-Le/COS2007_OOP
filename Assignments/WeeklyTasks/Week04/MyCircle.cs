using SplashKitSDK;

namespace DrawingProgram;

/// <summary>
/// Circle shape implementation.
/// </summary>
public class MyCircle : Shape
{
    private int _radius;

    /// <summary>
    /// Radius of the circle.
    /// </summary>
    public int Radius
    {
        get => _radius;
        set => _radius = value;
    }

    /// <summary>
    /// Create circle with specified colour and radius.
    /// </summary>
    public MyCircle(Color color, int radius) : base(color)
    {
        _radius = radius;
    }

    /// <summary>
    /// Create default circle.
    /// </summary>
    public MyCircle() : this(Color.Blue, 113)
    {
    }

    /// <inheritdoc />
    public override void Draw()
    {
        SplashKit.FillCircle(Color, X, Y, _radius);
        if (Selected)
        {
            DrawOutline();
        }
    }

    /// <inheritdoc />
    public override void DrawOutline()
    {
        SplashKit.DrawCircle(Color.Black, X, Y, _radius + 2);
    }

    /// <inheritdoc />
    public override bool IsAt(Point2D pt)
    {
        return SplashKit.PointInCircle(pt, SplashKit.CircleAt(X, Y, _radius));
    }
}
