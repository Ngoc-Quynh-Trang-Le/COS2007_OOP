using NUnit.Framework;
using DrawingProgram;
using SplashKitSDK;

namespace Tests;

public class MyLineTests
{
    [Test]
    public void IsAtPointOnLine()
    {
        var line = new MyLine
        {
            X = 0,
            Y = 0,
            EndX = 10,
            EndY = 0
        };
        Point2D pt = new Point2D { X = 5, Y = 0 };
        Assert.IsTrue(line.IsAt(pt));
    }
}
