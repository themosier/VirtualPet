using Godot;
using System;

public class MinigameJumpScene : Node2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    private Vector2 vel = Vector2.Zero;
    private const int JUMP_HEIGHT = 5;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        var player = GetNode<CreatureJump>("CreatureJump");
        player.Start(new Vector2(-2f, -7f));
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        // jump up if spacebar
        if (Input.IsActionJustPressed("jump"))
        {
            vel.y = JUMP_HEIGHT;
        }

    }
}
