using Godot;
using System;

public partial class BaseState : Node
{
	public FSM fsm;

	public virtual void Enter() { }
	public virtual void Exit() { }

	public virtual void Ready() { }
	public virtual void Update(double delta) { }
	public virtual void PhysicsUpdate(double delta) { }
	public virtual void HandleInput(InputEvent @event) { }
}
