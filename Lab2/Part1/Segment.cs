using System;

namespace Algorithms.lab2;

readonly struct Point2(int x, int y) {
    public readonly int X { get; } = x;
    public readonly int Y { get; } = y;
    
    public float DistanceTo(Point2 other) {
        return MathF.Sqrt(MathF.Pow(other.X - this.X, 2) + MathF.Pow(other.Y - this.Y, 2));
    }
    
    public override string ToString() => $"[{this.X}, {this.Y}]";
}

class Segment {
    public Point2 Start { get; }
    public Point2 End { get; }

    // Ключ для хешування (Довжина)
    public float GetLength() => this.Start.DistanceTo(this.End);

    // Метод обчислення кута з віссю ОХ
    public float GetAngleWithXAxis() {
        float angleRadians = MathF.Atan2(this.End.Y - this.Start.Y, this.End.X - this.Start.X);
        float angleDegrees = angleRadians * (180f / MathF.PI);
        return angleDegrees < 0 ? angleDegrees + 360f : angleDegrees;
    }

    public override string ToString() {
        return $"Segment: {this.Start} -> {this.End} | length = {this.GetLength():F2} | angle = {this.GetAngleWithXAxis():F2}°";
    }

    public Segment(Point2 start, Point2 end) {
        this.Start = start;
        this.End = end;
    }

    public Segment(int startX, int startY, int endX, int endY) 
        : this(new Point2(startX, startY), new Point2(endX, endY)) {}
}