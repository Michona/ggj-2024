using Godot;
using System;

public partial class ChargeState : BaseState
{
	[Export]
	public int MoveSpeed = 10;

	[Export]
	public StatsComponent statsComponent;

	public override void Enter()
	{
		statsComponent.Stats.Speed = MoveSpeed;
	}
}
