using Godot;
using System;

public class CreatureJump : KinematicBody2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    [Export]
    private int speed = 20;

    private Vector2 vel = Vector2.Zero;

    private const int JUMP_FORCE = 60;
    private const int GRAVITY = 80;
    private AnimatedSprite anim = new AnimatedSprite();


    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        //Position = new Vector2(34, 34);

        anim = GetNode<AnimatedSprite>("AnimatedSprite");
        anim.Animation = "walk";
        anim.Play();
        Show();
    }

    public void Start(Vector2 pos)
    {
        //Position = pos;
        //startPos = pos;
        //GD.Print("Position: ");

    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        vel.x = 0;
        // horizontal movement
        if (Input.IsActionPressed("move_right"))
        {
            vel.x += speed;
        }
        if (Input.IsActionPressed("move_left"))
        {
            vel.x -= speed;
        }

        vel = MoveAndSlide(vel, Vector2.Up);
        vel.y += GRAVITY * delta;

        if (Input.IsActionJustPressed("jump") && IsOnFloor())
        {
            vel.y -= JUMP_FORCE;
        }

        //vel.y += GRAVITY * delta;

        //Position += vel * delta;
        //var motion = MoveAndCollide(vel * delta);
        //if (motion is KinematicCollision2D)
        //{
        //    var n = motion.Normal;
        //    var r = motion.Remainder;
        //    vel = n.Slide(vel);
        //    MoveAndSlide(n.Slide(r));
        //}



        //Position += vel * delta;
        //if (Position.y > startPos.y)
        //{
        //    Position = startPos;
        //    vel.y = 0;
        //}

        //var anim = GetNode<AnimatedSprite>("AnimatedSprite");

        if (vel.y < 0 && !IsOnFloor())
        {
            anim.Animation = "jumpUp";
            
        }
        else if (vel.y > 0 && !IsOnFloor())
        {
            anim.Animation = "jumpDown";
            
        }
        if (IsOnFloor() && anim.Animation != "walk")
        {
            anim.Animation = "walk";
            
        }
        if (vel.x > 0)
        {
            anim.FlipH = false;
        }
        else if (vel.x < 0)
        {
            anim.FlipH = true;
        }
        if (vel.x != 0)
        {
            anim.Play();
        }
        else
        {
            anim.Stop();
        }
    }
}
