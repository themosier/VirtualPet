using Godot;
using System;

public class MinigameMemoryScene : Node2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    private Node cardsParent;
    private Godot.Collections.Array cards;
    private GDArray<string> colors = new GDArray<string>();
    public GDArray<Card> selectedCards = new GDArray<Card>();
   

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        colors.Add("blue");
        colors.Add("orange");
        colors.Add("pink");
        colors.Add("yellow");

        cardsParent = GetNode<Node>("Cards");

        //for (int i = 0; i < 8; i++)
        //{
        //    cards[i] = GetNode<AnimatedSprite>("Card" + i);
        //    cards[i].Animation = colors[i / 2];
        //    cards[i].Play();
        //}

        cards = cardsParent.GetChildren();
        int i = 0;
        foreach (Card child in cards)
        {
            child.SetColor(colors[i++ / 2]);
        }
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        if (selectedCards.Count >= 2)
        {
            //if (selectedCards[0].selTimer.TimeLeft == 0 && selectedCards[1].selTimer.TimeLeft == 0)
            //{
            //    CheckMatch(selectedCards[0], selectedCards[1]);
            //    selectedCards.Clear();
            //}
            if (selectedCards[0].IsSelected() && selectedCards[1].IsSelected())
            {
                CheckMatch(selectedCards[0], selectedCards[1]);
                selectedCards.Clear();
            }
        }

       if (cards.Count == 0)
        {
            Global glob = GetNode<Global>("/root/Global");
            //glob.homeScene.boredomTimer.Start();
            //glob.GotoScene("res://Scenes/HomeScene.tscn");

            GetTree().ChangeSceneTo(glob.homeScene);
        }
    }


    public void SelectCard(Card c)
    {
        selectedCards.Add(c);

        if (selectedCards.Count >= 2)
        {
            //CheckMatch(selectedCards[0], selectedCards[1]);
            //selectedCards.Clear();
        }
    }

    public void CheckMatch(Card c1, Card c2)
    {
        if (c1.GetColor() == c2.GetColor())
        {
            cards.Remove(c1);
            cards.Remove(c2);
            c1.QueueFree();
            c2.QueueFree();
        }
        else
        {
            c1.SetAnimation("default");
            c2.SetAnimation("default");
            GD.Print("No match");
        }
    }
}