using Godot;
using System;

public partial class Audience : Node2D
{
	[Export]
	public int ProjectileSpeed = 600;

	private PackedScene projectile;

	private Marker2D target;
	private Timer timer;

	private Random random = new Random();

	public override void _Ready()
	{
		// TODO: other scene
		projectile = GD.Load<PackedScene>("res://scenes/projectile_jelly.tscn");

		target = GetNode<Marker2D>("Marker2D");

		timer = GetNode<Timer>("Timer");
		timer.WaitTime = random.Next(1, 3);
		timer.Timeout += OnTimeout;
		timer.Start();
	}

	private void OnTimeout()
	{
		var projectileInstance = projectile.Instantiate() as JellyProjectile;
		projectileInstance.AnimationPath = "AnimatedBrocolli";
		projectileInstance.Shoot(Position, target.Position.Normalized(), ProjectileSpeed, ProjectileType.MEDIUM);
		projectileInstance.BodyEntered += (Node body) =>
		{
			OnProjectileCollision(projectileInstance, body);
		};
		GetParent().AddChild(projectileInstance);

		timer.WaitTime = random.Next(1, 3);
		timer.Start();
	}

	private void OnProjectileCollision(JellyProjectile projectile, Node other)
	{
		if (other.IsInGroup("ProjectileDestroyer"))
		{
			projectile.QueueFree();
		}
	}
}
