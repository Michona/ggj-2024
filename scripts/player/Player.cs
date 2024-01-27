using Godot;
using System;

public partial class Player : RigidBody2D
{
	[Export]
	public string ID;

	private FSM fsm;

	private PStats stats;

	public override void _Ready()
	{
		stats = GetNode<StatsComponent>("StatsComponent").Stats;
		fsm = GetNode<FSM>("FSMComponent");
	}

	public override void _PhysicsProcess(double delta)
	{
		// Update stats position
		stats.Position = Position;

		// // Set vector velocity
		// Vector2 velocity = Velocity;
		// velocity.X = stats.MoveDirection.X * stats.Speed;
		// velocity.Y = stats.MoveDirection.Y * stats.Speed;
		// Velocity = velocity;

		// Update rotation
		LookAt(Position + stats.LookDirection);

		// MoveAndSlide();
	}

	public override void _IntegrateForces(PhysicsDirectBodyState2D state)
	{
		Vector2 velocity = Vector2.Zero;
		velocity.X = stats.MoveDirection.X * stats.Speed;
		velocity.Y = stats.MoveDirection.Y * stats.Speed;

		LinearVelocity = velocity;

		ApplyImpulse(stats.Impulse);
	}
}
