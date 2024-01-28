using Godot;
using System;

public partial class PStats : Resource
{
    #region TWEAK
    [Export]
    public int PushStrength = 200;

    [Export]
    public float Acceleration = 0.4f;

    [Export]
    public float Deceleration = 0.4f;
    #endregion


    public int Speed { get; set; }

    public Vector2 Position { get; set; }

    public Vector2 MoveDirection { get; set; }

    // Normalized
    public Vector2 LookDirection { get; private set; }

    public Vector2 Impulse { get; set; }

    // public PStats() : this(0, Vector2.Zero) { }

    // public PStats()
    // {
    // }

    public void SetLookDirection(Vector2 mousePosition)
    {
        LookDirection = (mousePosition - Position).Normalized();
    }
}

