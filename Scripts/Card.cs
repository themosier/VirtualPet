using Godot;
using System;

public class Card : Area2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    private AnimatedSprite anim;
    private string color = "";
    private bool isSelected = false;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        anim = GetNode<AnimatedSprite>("AnimatedSprite");
        anim.Animation = "default";
    }

    //  // Called every frame. 'delta' is the elapsed time since the previous frame.
    //  public override void _Process(float delta)
    //  {
    //      
    //  }
    public void SetColor(string name)
    {
        color = name;
    }
    public string GetColor()
    {
        return color;
    }
    public void SetAnimation(string name)
    {
        anim.Animation = name;
        anim.Play();
    }
    public AnimatedSprite GetAnimation()
    {
        return anim;
    }
    public bool IsSelected()
    {
        return isSelected;
    }

    public void OnInputEvent(Godot.Object viewport, InputEvent e, int shape_idx)
    {
        if (e is InputEventMouseButton && GetOwner<MinigameMemoryScene>().selectedCards.Count < 2)
        {
            InputEventMouseButton mouse = (InputEventMouseButton)e;
            if (mouse.ButtonIndex == 1 && mouse.IsPressed())
            {
                GD.Print("CLICK");
                if (!isSelected)
                {
                    anim.Animation = color;
                    anim.Play();
                    //isSelected = true;
                    GetOwner<MinigameMemoryScene>().SelectCard(this);
                }
                else
                {
                    anim.Animation = "default";
                    anim.Play();
                    //isSelected = false;
                }
            }
        }
    }

    public void OnAnimationFinished()
    {
        if (!isSelected && anim.Animation != "default")
        {
            isSelected = true;
        }
        else
        {
            isSelected = false;
        }
    }
}
