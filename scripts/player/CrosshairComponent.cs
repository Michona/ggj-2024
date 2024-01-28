using Godot;
using System;

public partial class CrosshairComponent : Node
{
	[Export]
	public int Range = 250;

	[Export]
	public StatsComponent statsComponent;

	private Sprite2D aim;
	public override void _Ready()
	{
		aim = GetNode<Sprite2D>("Aim");
	}

	public override void _Process(double delta)
	{
		if (statsComponent.Stats.LookDirection != Vector2.Zero)
		{
			aim.Visible = true;
			aim.Position = statsComponent.Stats.Position + statsComponent.Stats.LookDirection * Range;
		}
		else
		{
			aim.Visible = false;
		}
	}
}
