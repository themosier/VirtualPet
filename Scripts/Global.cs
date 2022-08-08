using Godot;
using System;

public class Global : Node
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    private Node savedScene;

    public override void _Ready()
    {

    }

    //  // Called every frame. 'delta' is the elapsed time since the previous frame.
    //  public override void _Process(float delta)
    //  {
    //      
    //  }

    // Change to a temporary scene (such as minigames) from the main scene
    public void SwitchScene(string temp_scene)
    {
        savedScene = GetTree().CurrentScene;
        GetTree().Root.RemoveChild(savedScene);
        // instance and add temp scene as curr scene
        var newScene = GD.Load<PackedScene>(temp_scene).Instance();
        GetTree().Root.AddChild(newScene);
        GetTree().CurrentScene = newScene;
    }
    // Return to saved state of the main scene
    public void LoadHomeScene()
    {
        if (savedScene != null)
        {
            GetTree().CurrentScene.QueueFree();
            GetTree().Root.AddChild(savedScene);
            GetTree().CurrentScene = savedScene;
            savedScene = null;
        }
    }
}
public class GDArray<T> : Godot.Collections.Array<T> { }