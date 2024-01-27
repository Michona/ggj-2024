using Godot;
using System;

public partial class InputComponent : Node
{
	#region COMPONENTS
	[Export]
	public FSM fsm;

	[Export]
	public StatsComponent statsComponent;
	#endregion

	public override void _PhysicsProcess(double delta)
	{
		Vector2 direction = Input.GetVector("move_left", "move_right", "move_up", "move_down");
		statsComponent.Stats.Direction = direction;

		if (direction != Vector2.Zero)
		{
			fsm.TransitionTo("Move");
		} else {
			fsm.TransitionTo("Idle");
		}

		if (Input.IsActionJustPressed("jump"))
		{
			// TODO: ?? 
			// EmitSignal(SignalName.Shoot);
		}
	}
}
