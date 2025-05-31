using SplashKitSDK;

namespace DrawingProgram;

/// <summary>
/// Base class for drawable shapes.
/// Holds common location and colour information.
/// </summary>
public abstract class Shape
{
    private float _x;
    private float _y;
    private Color _color;
    private bool _selected;

    /// <summary>
    /// Creates a shape at (0,0) with the default yellow colour.
    /// </summary>
    protected Shape() : this(Color.Yellow)
    {
    }

    /// <summary>
    /// Creates a shape at (0,0) with the given colour.
    /// </summary>
    /// <param name="color">Initial colour.</param>
    protected Shape(Color color)
    {
        _color = color;
        _x = 0.0f;
        _y = 0.0f;
    }

    /// <summary>
    /// X coordinate of the shape.
    /// </summary>
    public float X
    {
        get => _x;
        set => _x = value;
    }

    /// <summary>
    /// Y coordinate of the shape.
    /// </summary>
    public float Y
    {
        get => _y;
        set => _y = value;
    }

    /// <summary>
    /// Shape colour.
    /// </summary>
    public Color Color
    {
        get => _color;
        set => _color = value;
    }

    /// <summary>
    /// Indicates whether the shape is selected.
    /// </summary>
    public bool Selected
    {
        get => _selected;
        set => _selected = value;
    }

    /// <summary>
    /// Draw the shape.
    /// </summary>
    public abstract void Draw();

    /// <summary>
    /// Draw an outline highlighting the shape.
    /// </summary>
    public abstract void DrawOutline();

    /// <summary>
    /// Determine if the provided point lies on the shape.
    /// </summary>
    /// <param name="pt">Point to test.</param>
    public abstract bool IsAt(Point2D pt);
}
