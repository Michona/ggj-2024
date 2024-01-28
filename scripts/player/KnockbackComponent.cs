using Godot;
using System;

public partial class KnockbackComponent : Node
{
	#region COMPONENTS
	[Export]
	public FSM fsm;

	[Export]
	public StatsComponent statsComponent;
	#endregion

	private Timer lifecycle;

	public override void _Ready()
	{
		lifecycle = GetNode<Timer>("LifecycleTimer");
		lifecycle.Timeout += OnTimeout;
	}

	public void OnKnockback(Vector2 direction, float extraStrength)
	{
		fsm.TransitionTo("Knockback");
		statsComponent.Stats.Impulse = direction * statsComponent.Stats.PushStrength * extraStrength;
		lifecycle.Start();
	}

	private void OnTimeout()
	{
		lifecycle.Stop();
		fsm.TransitionTo("Move");
	}
}
