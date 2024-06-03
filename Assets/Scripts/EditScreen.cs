using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class EditScreen : MonoBehaviour
{
    [Header("Referencecs")]
    [SerializeField]
    private CardSlot[] Slots;
    private CardSlot SelectedSlot;
    public Deck SelectedDeck;
    public Deck[] availableDecks;

    [Header("Scroll View")]
    public GameObject customizationPanel;
    public TMP_Dropdown deckSelector;
    public Image selectedDeckIcon;

    [Header("Focused Window")]
    public GameObject focusedModal;
    public  Image cardFace;
    public TextMeshProUGUI title;
    public TextMeshProUGUI description;
    public TextMeshProToggleButton toggleButton;

    [Header("Input Overlay")]
    public GameObject InputOverlay;
    public TextMeshProUGUI InputTitle;
    public TextMeshProUGUI InputDescription;
    void Start()
    {
        Slots = GetComponentsInChildren<CardSlot>();
        deckSelector.onValueChanged.AddListener(new UnityAction<int>(SwapDeck));
        FillSlots();
    }

    public void FillSlots(){
        for (int i = 0; i < SelectedDeck.AllCards.Count; i++)
        {
            Slots[i].card = SelectedDeck.AllCards[i];
            Debug.Log(Slots[i]);
            Slots[i].LoadCard();
        }
    }
    public void SwapDeck(int index){
        availableDecks[index].Selected = true;
        SelectedDeck = availableDecks[index];
        selectedDeckIcon.sprite = availableDecks[index].icon;
        FillSlots();
    }
    public void ShowEditWindow(CardSlot slot){
        SelectedSlot = slot;
        focusedModal.SetActive(true);
        customizationPanel.SetActive(false);
        cardFace.sprite = slot.card.Image;
        title.text = slot.card.Title;
        description.text = slot.card.Description;
        toggleButton.isToggled = slot.card.isActivated;
    }
    public void InputOverlayOn(){
        title.gameObject.SetActive(false);
        description.gameObject.SetActive(false);
        InputOverlay.SetActive(true);
        InputTitle.text = SelectedSlot.card.Title;
        InputDescription.text = SelectedSlot.card.Description;
    }
    public void SaveNewCard(){
        title.gameObject.SetActive(true);
        description.gameObject.SetActive(true);
        InputOverlay.SetActive(false);
        SelectedSlot.card.Title = InputTitle.text;
        SelectedSlot.card.Description = InputDescription.text;
        ShowEditWindow(SelectedSlot);
    }
    public void ApplyToDeck(){
        SelectedSlot.card.ToggleActivation();
    }

}
