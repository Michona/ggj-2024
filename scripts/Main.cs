using Godot;
using System;

public partial class Main : Node2D
{
    [Export]
    public int MaxHolesterol = 10;

    [Export]
    public int[] Holesterol;

    private Player _player1;

    private Player _player2;


    private ProgressBar _healthBar1;
    private ProgressBar _healthBar2;

    private PackedScene _blob;

    public override void _Ready()
    {
        _blob = GD.Load<PackedScene>("res://scenes/blob.tscn");

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

        _healthBar1 = GetNode<ProgressBar>("Health_1");
        _healthBar2 = GetNode<ProgressBar>("Health_2");
    }

    public override void _Process(double delta)
    {
        GD.Print("");
        foreach (int item in Holesterol)
        {
            GD.Print(item);
        }
                _healthBar1.Value = MathF.Min(MaxHolesterol, Holesterol[0]);
                _healthBar2.Value = MathF.Min(MaxHolesterol, Holesterol[1]);
    }

    private void OnPlayerProjectileCollision(Player player, Node body)
    {
        if (body is JellyProjectile projectile)
        {
            float coef;
            if (projectile.Type == ProjectileType.STRONG)
            {
                coef = 1.5f;
            }
            else
            {
                coef = 1f;
            }
            player.GetNode<KnockbackComponent>("KnockbackComponent").OnKnockback((player.Position - projectile.Position).Normalized(), coef);
            Holesterol[player.ID.ToInt() - 1]--;
            SpawnBlob(player);
        }
    }

    private void SpawnBlob(Player player)
    {
        var blobInstance = _blob.Instantiate() as Blob;
        blobInstance.Position = player.Position;
        blobInstance.OwnerID = player.ID;
        blobInstance.GetNode<Area2D>("Area2D").BodyEntered += (Node2D body) =>
        {
            OnBlobStepped(blobInstance, body);
        };
        AddChild(blobInstance);
    }

    private void OnBlobStepped(Blob blob, Node2D body)
    {
        if (body is Player player)
        {
            if (blob.OwnerID != player.ID)
            {
                Holesterol[player.ID.ToInt() - 1]++;
                blob.QueueFree();

            }
        }
    }
}
