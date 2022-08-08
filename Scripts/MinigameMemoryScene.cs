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
        var file = new File();
        file.Open("res://Levels/Memory.txt", File.ModeFlags.Read);
        while (!file.EofReached())
        {
            string line = file.GetLine();
            colors.Add(line);
            colors.Add(line);
        }
        file.Close();

        GD.Randomize();
        colors.Shuffle();
        foreach (string c in colors)
        {
            GD.Print(c);
        }
        

        cardsParent = GetNode<Node>("Cards");

        cards = cardsParent.GetChildren();
        int i = 0;
        foreach (Card child in cards)
        {
            child.SetColor(colors[i++]);
        }
    }
    
    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        if (selectedCards.Count >= 2)
        {
            if (selectedCards[0].IsSelected() && selectedCards[1].IsSelected())
            {
                CheckMatch(selectedCards[0], selectedCards[1]);
                selectedCards.Clear();
            }
        }

       if (cards.Count == 0)
        {
            Global glob = GetNode<Global>("/root/Global");

            glob.LoadHomeScene();
        }
    }


    public void SelectCard(Card c)
    {
        selectedCards.Add(c);
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