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
		if (ID != null)
		{
			direction = Input.GetVector("move_left_" + ID, "move_right_" + ID, "move_up_" + ID, "move_down_" + ID);
		}
		else
		{
			direction = Vector2.Zero;
		}

		statsComponent.Stats.MoveDirection = direction;

		Vector2 mousePosition = GetViewport().GetMousePosition();
		statsComponent.Stats.SetLookDirection(mousePosition);


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

	public override void _Input(InputEvent @event)
	{
		// // Mouse in viewport coordinates.
		// if (@event is InputEventMouseButton eventMouseButton)
		// 	GD.Print("Mouse Click/Unclick at: ", eventMouseButton.Position);
		// else if (@event is InputEventMouseMotion eventMouseMotion)
		// 	GD.Print("Mouse Motion at: ", eventMouseMotion.Position);

		// // Print the size of the viewport.
		// GD.Print("Viewport Resolution is: ", GetViewport().GetVisibleRect().Size);
	}
}
