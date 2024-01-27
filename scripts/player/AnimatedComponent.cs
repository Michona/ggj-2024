using Godot;
using System;

public partial class AnimatedComponent : AnimatedSprite2D
{
	#region COMPONENTS
	[Export]
	public FSM fsm;
	#endregion

	public override void _Ready()
	{
		fsm.OnTransition += OnTransition;
	}

	private void OnTransition(BaseState state)
	{
		if (state is MoveState)
		{
			Play("default");
		} else {
			Stop();
		}
	}
}
