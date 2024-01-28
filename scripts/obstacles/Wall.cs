using Godot;
using System;
using System.IO;

public partial class Wall : StaticBody2D
{
	public override void _Ready()
	{
		var points = GetNode<Polygon2D>("Polygon2D").Polygon;
		GetNode<CollisionPolygon2D>("CollisionPolygon2D").Polygon = points;

		var bakedPoints = GetNode<Path2D>("Path2D").Curve.GetBakedPoints();
		GetNode<Polygon2D>("Polygon2D").SetDeferred("polygon", bakedPoints);
	}
}
