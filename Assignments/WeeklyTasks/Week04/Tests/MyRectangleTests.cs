using NUnit.Framework;
using DrawingProgram;
using SplashKitSDK;

namespace Tests;

public class MyRectangleTests
{
    [Test]
    public void DefaultSize()
    {
        var rect = new MyRectangle();
        Assert.That(rect.Width, Is.EqualTo(163));
        Assert.That(rect.Height, Is.EqualTo(163));
    }

    [Test]
    public void IsAtInsidePoint()
    {
        var rect = new MyRectangle(Color.Red, 0, 0, 10, 10);
        Point2D pt = new Point2D { X = 5, Y = 5 };
        Assert.IsTrue(rect.IsAt(pt));
    }
}
