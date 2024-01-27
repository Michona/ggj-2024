using Godot;
using System;

public partial class MoveState : BaseState
{
	[Export]
	public int MoveSpeed = 200;

	[Export]
	public StatsComponent statsComponent;

	public override void Enter()
	{
		statsComponent.Stats.Speed = MoveSpeed;
	}
}
