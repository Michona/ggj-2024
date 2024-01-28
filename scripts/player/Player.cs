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
		GetNode<AnimatedSprite2D>("AnimatedComponent_" + ID).Visible = true;
		stats = GetNode<StatsComponent>("StatsComponent").Stats;
		fsm = GetNode<FSM>("FSMComponent");
	}

	public override void _PhysicsProcess(double delta)
	{
		// Update stats position
		stats.Position = Position;
		// stats.SetLookDirection(GetGlobalMousePosition());

		// TODO: Check
		// Rotation = Mathf.LerpAngle(Rotation, stats.LookDirection.Angle(), 0.9f);
		// var currentDirection = new Vector2((float)Math.Cos(Rotation), (float)Math.Sin(Rotation));
		Rotation = 0;
		// LookAt(Position + stats.LookDirection);
	}

	public override void _IntegrateForces(PhysicsDirectBodyState2D state)
	{
		Vector2 velocity = state.LinearVelocity;

		// TODO: check this again!
		if (stats.MoveDirection.X == 0 && stats.MoveDirection.Y == 0)
		{
			velocity.X = Mathf.Lerp(velocity.X, 0, stats.Deceleration);
			velocity.Y = Mathf.Lerp(velocity.Y, 0, stats.Deceleration);
		}
		else
		{
			velocity.X = Mathf.Lerp(velocity.X, stats.MoveDirection.X * stats.Speed, stats.Acceleration);
			velocity.Y = Mathf.Lerp(velocity.Y, stats.MoveDirection.Y * stats.Speed, stats.Acceleration);
		}

		state.LinearVelocity = velocity;

		ApplyImpulse(stats.Impulse);

		// TODO: have to do bounce here!
		// for (int i = 0; i < state.GetContactCount(); i++)
		// {
		// 	var normal = state.GetContactLocalNormal(i);
		// 	var contactVelocity = state.GetContactLocalVelocityAtPosition(i);
		// 	GD.Print("NORMAL" + normal);
		// 	GD.Print("VElo" + contactVelocity);
		// }
	}
}
