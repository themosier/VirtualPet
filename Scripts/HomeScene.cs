using Godot;
using System;

public class HomeScene : Node2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    private ProgressBar hungerBar;
    private ProgressBar boredomBar;
    public Timer hungerTimer;
    public Timer boredomTimer;

    private RichTextLabel statusLabel;
    private bool statusActive = false;
    private float statusActiveTime = 0.0f;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        hungerBar = GetNode<ProgressBar>("HungerBar");
        hungerBar.Value = 10;
        boredomBar = GetNode<ProgressBar>("BoredomBar");
        boredomBar.Value = 10;

        hungerTimer = hungerBar.GetNode<Timer>("Timer");
        boredomTimer = boredomBar.GetNode<Timer>("Timer");

        statusLabel = GetNode<RichTextLabel>("StatusLabel");
        statusLabel.PushAlign(RichTextLabel.Align.Center);
        statusLabel.Text = "";

    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        if (statusActive)
        {
            statusActiveTime += delta;
            if (statusActiveTime > 1.5f)
            {
                statusLabel.BbcodeText = "";
                statusActiveTime = 0.0f;
                statusActive = false;
            }
        }
    }

    public void OnHungerTimerTimeout()
    {
        hungerBar.Value -= 1;
        if (hungerBar.Value <= 0)
        {
            //hungerBar.Value = 10;
            boredomTimer.Stop();
            hungerTimer.Stop();
            GD.Print("DEAD");
            statusLabel.BbcodeText = "[center]dead[/center]";
        }
    }
    public void OnBoredomTimerTimeout()
    {
        boredomBar.Value -= 1;
        if (boredomBar.Value <= 0)
        {
            //boredomBar.Value = 10;
            boredomTimer.Stop();
            GD.Print("BORED");
            statusLabel.BbcodeText = "[center]bored[/center]";
        }
    }

    public void OnFoodButtonButtonUp()
    {
        hungerBar.Value += 5;

        if (hungerBar.Value > 10)
        {
            hungerBar.Value = 10;
        }

        hungerTimer.Start();
        statusLabel.BbcodeText = "[center]eating[/center]";
        statusActive = true;
    }

    public void OnGameButtonButtonUp()
    {
        boredomBar.Value += 5;
        if (boredomBar.Value > 10)
        {
            boredomBar.Value = 10;
        }

        boredomTimer.Start();



        GetTree().ChangeScene("res://Scenes/MinigameMemoryScene.tscn");
        statusLabel.BbcodeText = "[center]playing[/center]";
        statusActive = true;
    }
}

public class GDArray<T> : Godot.Collections.Array<T> { }