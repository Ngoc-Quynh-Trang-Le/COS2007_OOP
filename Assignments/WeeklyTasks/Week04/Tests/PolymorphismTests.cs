using System.Collections.Generic;
using NUnit.Framework;
using DrawingProgram;
using SplashKitSDK;

namespace Tests;

public class PolymorphismTests
{
    [Test]
    public void IsAtPolymorphicCall()
    {
        List<Shape> shapes = new()
        {
            new MyRectangle(Color.Black, 0, 0, 10, 10),
            new MyCircle(Color.Black, 10) { X = 0, Y = 0 },
            new MyLine { X = 0, Y = 0, EndX = 10, EndY = 0 }
        };
        Point2D pt = new Point2D { X = 5, Y = 0 };
        int hits = 0;
        foreach (Shape s in shapes)
        {
            if (s.IsAt(pt)) hits++;
        }
        Assert.That(hits, Is.EqualTo(3));
    }
}
