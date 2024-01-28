using Godot;
using System;

public partial class Barrel : RigidBody2D
{
	public override void _Process(double delta)
	{
		Rotation = 0f;
	}
}
