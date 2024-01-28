using Godot;
using System;
using System.ComponentModel.DataAnnotations.Schema;

public partial class InputComponent : Node
{
	private string ID = null;

	#region COMPONENTS
	[Export]
	public FSM fsm;

	[Export]
	public StatsComponent statsComponent;
	#endregion

	public override void _Ready()
	{
		ID = (GetParent() as Player).ID;
	}

	public override void _PhysicsProcess(double delta)
	{
		Vector2 direction;
		Vector2 lookAt;
		if (ID != null)
		{
			direction = Input.GetVector("move_left_" + ID, "move_right_" + ID, "move_up_" + ID, "move_down_" + ID);
			lookAt = Input.GetVector("look_left_" + ID, "look_right_" + ID, "look_up_" + ID, "look_down_" + ID);
		}
		else
		{
			direction = Vector2.Zero;
			lookAt = Vector2.Zero;
		}

		statsComponent.Stats.MoveDirection = direction;
		statsComponent.Stats.LookDirection = lookAt.Normalized();

		if (fsm.State is not KnockbackState && fsm.State is not ChargeState)
		{
			if (direction != Vector2.Zero)
			{
				fsm.TransitionTo("Move");
			}
			else
			{
				fsm.TransitionTo("Idle");
			}
		}
	}
}
