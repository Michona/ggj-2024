using Godot;
using System;

public partial class Global : Node
{
	public Node CurrentScene { get; set; }

	public override void _Ready()
	{
		Viewport root = GetTree().Root;
		CurrentScene = root.GetChild(root.GetChildCount() - 1);


		// var player1 = GD.Load<PackedScene>("res://scenes/player.tscn");
		// var player2 = GD.Load<PackedScene>("res://scenes/player.tscn");

		// var player1Instance = (player1.Instantiate() as Player);
		// player1Instance.ID = "1";
		// player1Instance.Position = new Vector2(100, 100);

		// var player2Instance = (player2.Instantiate() as Player);
		// player2Instance.ID = "2";
		// player2Instance.Position = new Vector2(0, 0);

		// CurrentScene.AddChild(player1Instance);
		// CurrentScene.AddChild(player2Instance);
		// CurrentScene.GetNode<Player>("Player").Shoot += () => GD.Print("GOT IT");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
