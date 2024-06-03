using UnityEngine.UI;
using TMPro;
using UnityEngine;
using System;

public class Slot : MonoBehaviour
{
    [Header("References")]
    public Player playerSO;

    [SerializeField]
    private TextMeshProUGUI playerName;
    private GameObject playerData;
    private GameObject addPlayerBtn;
    public PlayerManager manager;

    [Header("Input Overlay")]
    public GameObject inputOverlay;
    private void Start()
    {
        GetReferences();
    }

    private void GetReferences()
    {
        foreach (Transform child in this.transform)
        {
            if (child.gameObject.CompareTag("Player"))
            {
                playerData = child.gameObject; 
            }else if (child.gameObject.CompareTag("AddBtn"))
            {
                addPlayerBtn = child.gameObject;
            }
        }
    }

    public void UpdateData(string newName = null)
    {
        playerData.SetActive(true);
        if (newName != null)
        {
            playerSO.playerName = newName;
        }
        playerName.text = playerSO.playerName;
        addPlayerBtn.SetActive(false);
    }
    public void Remove()
    {
        playerSO.playing = false;
    }
    public void ShowAddBtn()
    {
        addPlayerBtn.SetActive(true);
        playerData.SetActive(false);
    }
    public void ShowInputOverlay()
    {
        manager.SetSelectedSlot(this);
        inputOverlay.SetActive(true);
    }
}
