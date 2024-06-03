using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class CardSlot : MonoBehaviour
{
    public Card card;
    private Image _icon;
    private TextMeshProUGUI _title;
    void Start()
    {
        GetReferences();
        //LoadCard();
    }
    void Update()
    {
        
    }
    public void LoadCard(){ //this is meant to be used by the load file method in the menu script
        if (!card)
        {
            Debug.LogWarning("Card Slot with no card associated");
            return;
        }
        _icon.sprite = card.Image;
        _title.text = card.Title;
    }
    private void GetReferences(){
        _title = GetComponentInChildren<TextMeshProUGUI>();
        foreach (Transform child in transform)
        {
            if (child.name == "Card Icon")
            {
                _icon = child.GetComponent<Image>();
            }
        }
    }
}
