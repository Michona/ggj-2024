using Godot;
using System;

public partial class JellyProjectile : RigidBody2D
{
	// TODO: improve stats here!

	[Export]
	public int Speed = 800;

	private Vector2 _direction = Vector2.Up;

    public void Shoot(Vector2 from, Vector2 direction)
	{
		Position = from + direction * 200;
		_direction = direction;
	}

	public override void _IntegrateForces(PhysicsDirectBodyState2D state)
	{
		LinearVelocity = Speed * _direction;
	}
}
