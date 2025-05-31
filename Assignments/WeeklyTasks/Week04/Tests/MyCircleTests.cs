using NUnit.Framework;
using DrawingProgram;
using SplashKitSDK;

namespace Tests;

public class MyCircleTests
{
    [Test]
    public void DefaultRadius()
    {
        var c = new MyCircle();
        Assert.That(c.Radius, Is.EqualTo(113));
    }

    [Test]
    public void IsAtInsidePoint()
    {
        var c = new MyCircle(Color.Green, 10);
        c.X = 0;
        c.Y = 0;
        Point2D pt = new Point2D { X = 0, Y = 0 };
        Assert.IsTrue(c.IsAt(pt));
    }
}
