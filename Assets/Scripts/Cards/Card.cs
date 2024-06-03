using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "ScriptableObject/Card", order = 1)]
public class Card : ScriptableObject
{
    private int _id {get;}
    public int GetId() => _id;
    public Sprite Image;
    public string Title;
    [TextArea(3,10)]
    public string Description;
    public bool isActivated = true;
    public int Copies = 1;
    public void UpdateValues(string newTitle, string newDescription){
        Title = newTitle;
        Description = newDescription; 
    }
    public void ToggleActivation(){
        isActivated = !isActivated;
    }
}