using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    public Card dummy;
    [Header("References")]
    public Deck[] availableDecks;
    public Deck playingDeck;
    public Player[] allPlayers;
    private Queue<Player> _playOrder;

    [Header("UI Elements")]
    public TextMeshProUGUI playerName;
    public TextMeshProUGUI cardTitle;
    public TextMeshProUGUI cardDescription;
    public GameObject cardUI;
    private Image _cardImage;
    public Sprite cardBack;
    private bool _facedUp;
    public Button drawBtn;
    public Button nextBtn;
    private RectTransform cardRectTransform;

    void Start()
    {
        _cardImage = cardUI.GetComponent<Image>();
        cardRectTransform = cardUI.GetComponent<RectTransform>();
        DisplayNextPlayer();
        playingDeck = FindSelectedDeck();
        cardBack = playingDeck.icon;
    }
    public void SetupQueue()
    {
        if (_playOrder == null)
        {
            _playOrder = new Queue<Player>();
        }
        _playOrder.Clear();

        foreach (Player item in allPlayers)
        {
            if (item.playing)
            {
                _playOrder.Enqueue(item);
            }
        }
    }
    private Deck FindSelectedDeck() //read from file?
    {
        foreach (Deck item in availableDecks)
        {
            if (item.Selected)
            {
                return item;
            }
        }
        return null;
    }
    // private Player FindPlayerByIndex(int i) //read from file?
    // {
    //     foreach (Player item in allPlayers)
    //     {
    //         if (item.orderIndex == i && item.playing)
    //         {
    //             return item;
    //         }
    //     }
    //     return null;
    // }
    public void DisplayNextCard()
    {
        Card currentCard = playingDeck.Draw();
        cardDescription.gameObject.SetActive(true);
        cardTitle.gameObject.SetActive(true);
        cardTitle.text = currentCard.Title;
        cardDescription.text = currentCard.Description;
        nextBtn.interactable = false;
        RotateCard(currentCard);
        nextBtn.interactable = true;
    }
    public void DisplayNextPlayer(){
        if (_playOrder == null || !_playOrder.TryDequeue(out Player nextPlayer))
        {
            SetupQueue();
            nextPlayer = _playOrder.Dequeue();
        }
        playerName.text = nextPlayer.playerName;
    }
    public void HideCard(){
        cardDescription.gameObject.SetActive(false);
        cardTitle.gameObject.SetActive(false);
        drawBtn.interactable = false;
        RotateCard(dummy);
        drawBtn.interactable = true;
    }
    private IEnumerator RotateCard(Card currentCard)
    {
        float targetAngle = _facedUp ? -90f : 0f;
        float _currentAngle = _facedUp ? 0f : -90f;

        for (float i = _currentAngle; i != targetAngle; i += 5f)
        {
            cardRectTransform.localEulerAngles = new Vector3(0, i, 0);
            if (i == -45f && !_facedUp) // Adjust as needed
            {
                _cardImage.sprite = currentCard.Image;
            }else
            {
                _cardImage.sprite = cardBack;
            }
            yield return new WaitForSeconds(0.1f); // Adjust for desired speed
        }
        _facedUp = !_facedUp;
    }

}