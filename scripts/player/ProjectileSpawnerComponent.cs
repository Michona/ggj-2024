using Godot;
using System;
using System.Linq;
using System.Runtime.Intrinsics.X86;

public partial class ProjectileSpawnerComponent : Node
{

	[Export]
	public double MaxChargeTime = 2;

	[Export]
	public int ProjectileSpeed = 800;

	[Export]
	public StatsComponent statsComponent;

	[Export]
	public FSM fsm;

	[Export]
	public KnockbackComponent knockbackComponent;

	private PackedScene projectile;

	private string ID = null;

	public override void _Ready()
	{
		ID = (GetParent() as Player).ID;
		projectile = GD.Load<PackedScene>("res://scenes/projectile_jelly.tscn");
	}

	public override void _Process(double delta)
	{
		if (Input.IsActionJustPressed("shoot_" + ID))
		{
			if (statsComponent.Stats.LookDirection != Vector2.Zero)
			{
				fsm.TransitionTo("Charge");
			}
		}
		if (Input.IsActionPressed("shoot_" + ID))
		{
			OnCharge(delta);
		}
		if (Input.IsActionJustReleased("shoot_" + ID))
		{
			OnChargeEnd();
		}
	}

	private double chargedTime = 0;

	private void OnCharge(double delta)
	{
		if (fsm.State is ChargeState)
		{
			chargedTime += delta;
			if (chargedTime > MaxChargeTime)
			{
				OnChargeEnd();
			}
		}
	}

	private void OnChargeEnd()
	{
		if (fsm.State is ChargeState)
		{
			// var direction = statsComponent.Stats.LookDirection;
			// if (direction == Vector2.Zero) {
			// 	direction = Vector2.Up;
			// }

			var chargedCoef = MathF.Max(1, (float)chargedTime);

			var projectileInstance = projectile.Instantiate() as JellyProjectile;
			ProjectileType projectileType;
			if (chargedTime >= 1)
			{
				projectileType = ProjectileType.STRONG;
			}
			else
			{
				projectileType = ProjectileType.MEDIUM;
			}
			projectileInstance.Shoot(
				statsComponent.Stats.Position,
				statsComponent.Stats.LookDirection,
				ProjectileSpeed * chargedCoef,
				projectileType
			);
			projectileInstance.BodyEntered += (Node body) =>
			{
				OnProjectileCollision(projectileInstance, body);
			};
			AddChild(projectileInstance);

			knockbackComponent.OnKnockback(statsComponent.Stats.LookDirection.Rotated(MathF.PI), chargedCoef);

			chargedTime = 0;
		}
	}

	private void OnProjectileCollision(JellyProjectile projectile, Node other)
	{
		if (other.IsInGroup("ProjectileDestroyer"))
		{
			projectile.QueueFree();
		}
	}
}
