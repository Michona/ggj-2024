using Godot;
using System;

public partial class PStats : Resource
{
    public int Speed { get; set; }

    public Vector2 Direction { get; set; }

    public PStats() : this(0, Vector2.Zero) { }

    public PStats(int speed, Vector2 direction)
    {
        Speed = speed;
        Direction = direction;
    }
}

