using Godot;
using System;

public partial class Main : Node2D
{

    private Player _player1;

    private Player _player2;

    public override void _Ready()
    {
        _player1 = GetNode<Player>("Player_1");
        _player1.BodyEntered += (Node body) =>
        {
            OnPlayerProjectileCollision(_player1, body);
        };

        _player2 = GetNode<Player>("Player_2");
        _player2.BodyEntered += (Node body) =>
        {
            OnPlayerProjectileCollision(_player2, body);
        };
    }

    private void OnPlayerProjectileCollision(Player player, Node body)
    {
        if (body is JellyProjectile projectile)
        {
            player.GetNode<KnockbackComponent>("KnockbackComponent").OnKnockback((player.Position - projectile.Position).Normalized(), 1);
        }

        // if (body.IsInGroup("BounceOff")) {
        //     CollisionPolygon2D smth = body.GetNode<CollisionPolygon2D>("");
        //     smth.Polygon
        // }
    }
}
