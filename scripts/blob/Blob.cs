using Godot;
using System;

public partial class Blob : Node2D
{
	[Signal]
	public delegate void OnBodyEnteredEventHandler(Node2D body);

	private Path2D _path;

	private Polygon2D _poly;

	private Timer _timer;

	private CollisionPolygon2D _collisionPoly;

	private Random random = new Random();

	public string OwnerID;

	public override void _Ready()
	{
		_path = GetNode<Path2D>("Path_" + random.Next(1, 3));
		_poly = GetNode<Polygon2D>("MainPoly");
		_timer = GetNode<Timer>("Timer");
		_collisionPoly = GetNode<CollisionPolygon2D>("Area2D/CollisionPolygon2D");
		_timer.Timeout += OnTimeout;

		var points = _path.Curve.GetBakedPoints();
		_poly.Polygon = points;
		_collisionPoly.SetDeferred("polygon", points);
	}

	private void OnTimeout()
	{
		QueueFree();
	}
}
