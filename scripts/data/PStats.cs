using Godot;
using System;

public partial class PStats : Resource
{
    public int Speed { get; set; }

    public Vector2 Position { get; set; }

    public Vector2 MoveDirection { get; set; }

    // Normalized
    public Vector2 LookDirection { get; private set; }

    public Vector2 Impulse { get; set; }

    public PStats() : this(0, Vector2.Zero) { }

    public PStats(int speed, Vector2 direction)
    {
        Speed = speed;
        MoveDirection = direction;
    }

    public void SetLookDirection(Vector2 mousePosition)
    {
        LookDirection = (mousePosition - Position).Normalized();
    }
}

