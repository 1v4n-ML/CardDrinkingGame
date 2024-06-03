using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Interfaces;
using UnityEngine;

[CreateAssetMenu(fileName = "New Deck", menuName = "ScriptableObject/Deck", order = 1)]
public class Deck : ScriptableObject
{
    public List<Card> AllCards;
    public Queue<Card> PlayableDeck;
    public bool Selected;
    public Sprite icon;

    public void Shuffle<Card>(Queue<Card> queue)
    {
        // Dequeue all elements into a list
        List<Card> tempList = new List<Card>(queue);
        queue.Clear();

        // Shuffle the list using Fisher-Yates algorithm
        System.Random rng = new System.Random();
        int n = tempList.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            Card value = tempList[k];
            tempList[k] = tempList[n];
            tempList[n] = value;
        }

        // Enqueue the shuffled elements back into the queue
        foreach (Card item in tempList)
        {
            queue.Enqueue(item);
        }
    }
    private void ReadyToPlay(){
        if (PlayableDeck == null)
        {
            PlayableDeck = new Queue<Card>();
        }
        PlayableDeck.Clear();
        foreach (Card item in AllCards)
        {
            if (item.isActivated)
            {
                for (int i = 0; i < item.Copies; i++)
                {
                    PlayableDeck.Enqueue(item);
                }
            }
        }
        Shuffle(PlayableDeck);
    }
    public Card Draw(){
        if (PlayableDeck == null || PlayableDeck.TryDequeue(out Card result)) 
        { 
            ReadyToPlay();
            result = PlayableDeck.Dequeue();
        }
        return result;

    }
    public void GenerateDeck(Card[] cards){  //this is meant to be used by the load from file function
        foreach (Card item in cards)
        {
            AllCards.Add(item);
        }
    }
}
