using Godot;
using System;

public partial class Global : Node
{
	public Node CurrentScene { get; set; }

	public override void _Ready()
	{
		Viewport root = GetTree().Root;
        CurrentScene = root.GetChild(root.GetChildCount() - 1);

		// CurrentScene.GetNode<Player>("Player").Shoot += () => GD.Print("GOT IT");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
