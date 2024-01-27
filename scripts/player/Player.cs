using Godot;
using System;

public partial class Player : CharacterBody2D
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
		Vector2 velocity = Velocity;

		velocity.X = stats.Direction.X * stats.Speed;
		velocity.Y = stats.Direction.Y * stats.Speed;

		Velocity = velocity;
		MoveAndSlide();
	}
}
