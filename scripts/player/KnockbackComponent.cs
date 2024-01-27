using Godot;
using System;

public partial class KnockbackComponent : Node
{
	[Export]
	public int PushStrength = 300;

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

	public void OnKnockback(Vector2 direction, double chargedTime)
	{
		fsm.TransitionTo("Knockback");
		statsComponent.Stats.Impulse = direction * PushStrength * MathF.Max(1, (float)chargedTime);
		lifecycle.Start();
	}


	private void OnTimeout()
	{
		lifecycle.Stop();
		fsm.TransitionTo("Move");
	}
}
