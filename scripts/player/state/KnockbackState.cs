using Godot;
using System;

public partial class KnockbackState : BaseState
{
	[Export]
	public StatsComponent statsComponent;

	public override void Exit()
	{
		statsComponent.Stats.Impulse = Vector2.Zero;
	}
}
