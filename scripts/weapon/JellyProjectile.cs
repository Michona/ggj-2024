using Godot;
using System;

public partial class JellyProjectile : RigidBody2D
{
	[Export]
	public int SpawnDistance = 400;

	[Export]
	public float ScaleOnStrong = 1.8f;

	private Vector2 _direction = Vector2.Up;
	private float _speed = 0;

	public ProjectileType Type;

	public string AnimationPath = "AnimatedGarlic";

	public override void _Ready()
	{
		// GetNode<AnimatedSprite2D>("AnimatedGarlic").Play("default");
		// GetNode<AnimatedSprite2D>("AnimatedBroccoli").Play("default");
	}

	public void Shoot(Vector2 from, Vector2 direction, float speed, ProjectileType type)
	{
		GetNode<AnimatedSprite2D>(AnimationPath).Visible = true;
		GetNode<AnimatedSprite2D>(AnimationPath).Play("default");

		Position = from + direction * SpawnDistance;
		_direction = direction;
		_speed = speed;
		Type = type;

		if (type == ProjectileType.STRONG)
		{
			GetNode<AnimatedSprite2D>(AnimationPath).Scale *= ScaleOnStrong;
			GetNode<CollisionShape2D>("CollisionShape2D").Scale *= ScaleOnStrong;
		}
	}

	public override void _IntegrateForces(PhysicsDirectBodyState2D state)
	{
		LinearVelocity = _speed * _direction;
	}
}
