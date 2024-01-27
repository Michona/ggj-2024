using Godot;
using System;
using System.Collections.Generic;

public partial class FSM : Node
{
	[Signal]
	public delegate void OnTransitionEventHandler(BaseState state);

	[Export] public NodePath initialState;

	private Dictionary<string, BaseState> _states;
	private BaseState _currentState;
	public BaseState State { get { return _currentState; } }

	public override void _Ready()
	{
		_states = new Dictionary<string, BaseState>();
		foreach (Node node in GetChildren())
		{
			if (node is BaseState s)
			{
				_states[node.Name] = s;
				s.fsm = this;
				s.Ready();
				s.Exit(); // reset
			}
		}

		_currentState = GetNode<BaseState>(initialState);
		_currentState.Enter();
	}

	public override void _Process(double delta)
	{
		_currentState.Update(delta);
	}

	public override void _PhysicsProcess(double delta)
	{
		_currentState.PhysicsUpdate(delta);
	}

	public override void _UnhandledInput(InputEvent @event)
	{
		_currentState.HandleInput(@event);
		@event.Dispose();
	}

	public void TransitionTo(string key)
	{
		if (!_states.ContainsKey(key) || _states[key] == _currentState)
			return;
		_currentState.Exit();
		GD.Print("FSM: Exited ");
		GD.Print(_currentState.Name);

		_currentState = _states[key];

		_currentState.Enter();
		EmitSignal(SignalName.OnTransition, _currentState);

		GD.Print("FSM: Entered ");
		GD.Print(_currentState.Name);
	}
}