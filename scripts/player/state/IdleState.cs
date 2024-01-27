using Godot;
using System;

public partial class IdleState : BaseState
{

	[Export]
	public StatsComponent statsComponent;

    public override void Enter()
    {
		statsComponent.Stats.Speed = 0;
    }
}
