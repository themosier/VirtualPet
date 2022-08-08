using Godot;
using System;


public class StartScreen : Node2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        GD.Print("Ready");
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }


    public void OnClick()
    {
        GD.Print("Click!");
        GetTree().ChangeScene("res://Scenes/HomeScene.tscn");
    }
}
