using Godot;
using System;
using System.ComponentModel.DataAnnotations;

public partial class AnimatedComponent : AnimatedSprite2D
{
	#region COMPONENTS
	[Export]
	public FSM fsm;

	[Export]
	public StatsComponent statsComponent;
	#endregion

	public override void _Ready()
	{
		fsm.OnTransition += OnTransition;
	}

	public override void _Process(double delta)
	{
		if (fsm.State is MoveState)
		{
			var moveDirection = statsComponent.Stats.MoveDirection;
			var angle = moveDirection.Angle();
			angle = angle * 180 / MathF.PI;
			if (angle > 0)
			{
				if (angle > 45 && angle < 90 + 45)
				{
					Play("move_down");
				}
				else if (angle < 45)
				{
					Play("move_right");
				}
				else
				{
					Play("move_left");
				}
			}
			else
			{
				angle = Mathf.Abs(angle);
				if (angle > 45 && angle < 90 + 45)
				{
					Play("move_up");
				}
				else if (angle < 45)
				{
					Play("move_right");
				}
				else
				{
					Play("move_left");
				}
			}
		}
	}

	private void OnTransition(BaseState state)
	{
		if (state is ChargeState)
		{
			Play("charge_up");
		}
		else
		{

		}
	}
}
