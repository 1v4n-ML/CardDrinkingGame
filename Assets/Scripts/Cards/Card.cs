using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Unity.VisualScripting;

[CreateAssetMenu(fileName = "New Card", menuName = "ScriptableObject/Card", order = 1)]
public class Card : ScriptableObject
{
    public Sprite Image;
    public string Title;
    [TextArea(3,10)]
    public string Details;
    public bool isActivated = true;
    public int Copies = 1;
    public void UpdateValues(string newTitle, string newDescription)
    {
        Title = newTitle;
        Details = newDescription; 
    }
    public void ToggleActivation()
    {
        isActivated = !isActivated;
    }
    public CardData GetCardData()
    {
        CardData data = new CardData(this.Title, this.isActivated, this.Copies, this.Details);
        return data;
    }
    public void SetCardData(CardData data)
    {
        Title = data.Title;
        Details = data.Details;
        Copies = data.Copies;
        isActivated = data.isActivated;
    }
}

[Serializable]
public class CardData
{
    public string Title;
    public bool isActivated;
    public int Copies;
    public string Details;

    public CardData(string title, bool active, int copies, string description)
    {
        Title = title;
        isActivated = active;
        Copies = copies;
        Details = description;
    }
}