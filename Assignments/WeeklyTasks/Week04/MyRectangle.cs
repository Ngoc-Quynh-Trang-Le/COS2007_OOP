using SplashKitSDK;

namespace DrawingProgram;

/// <summary>
/// Rectangle shape implementation.
/// </summary>
public class MyRectangle : Shape
{
    private int _width;
    private int _height;

    /// <summary>
    /// Width of the rectangle.
    /// </summary>
    public int Width
    {
        get => _width;
        set => _width = value;
    }

    /// <summary>
    /// Height of the rectangle.
    /// </summary>
    public int Height
    {
        get => _height;
        set => _height = value;
    }

    /// <summary>
    /// Create rectangle with specified parameters.
    /// </summary>
    public MyRectangle(Color color, float x, float y, int width, int height) : base(color)
    {
        X = x;
        Y = y;
        _width = width;
        _height = height;
    }

    /// <summary>
    /// Create default rectangle.
    /// </summary>
    public MyRectangle() : this(Color.Green, 0.0f, 0.0f, 163, 163)
    {
    }

    /// <inheritdoc />
    public override void Draw()
    {
        SplashKit.FillRectangle(Color, X, Y, _width, _height);
        if (Selected)
        {
            DrawOutline();
        }
    }

    /// <inheritdoc />
    public override void DrawOutline()
    {
        const int studentIDLastDigit = 3;
        const int padding = 5 + studentIDLastDigit;
        Rectangle rect = SplashKit.RectangleFrom(
            X - padding / 2,
            Y - padding / 2,
            _width + padding,
            _height + padding);
        SplashKit.DrawRectangle(Color.Black, rect);
    }

    /// <inheritdoc />
    public override bool IsAt(Point2D pt)
    {
        return SplashKit.PointInRectangle(pt, SplashKit.RectangleFrom(X, Y, _width, _height));
    }
}
