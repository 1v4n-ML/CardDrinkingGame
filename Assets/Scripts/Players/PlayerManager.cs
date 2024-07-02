using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public Player[] playerPool;
    public Slot[] slots;
    private List<Player> activePlayers;
    private Slot SelectedSlot;
    public TextMeshProUGUI availableText;

    [Header("Input Overlay")]
    public TextMeshProUGUI inputText;

    private void Start()
    {
        LoadPlayers();
        UpdateSlots();
    }
    public void UpdateSlotData()
    {
        SelectedSlot.UpdateData(inputText.text);
        SelectedSlot.playerSO.playing = true;
    }
    public void UpdateSlots()
    {
        activePlayers = new List<Player>();

        for (int i = 0; i < playerPool.Length; i++)
        {
            if (playerPool[i].playing == true)
            {
                activePlayers.Add(playerPool[i]);
            }
        }
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < activePlayers.Count)
            {
                slots[i].gameObject.SetActive(true);
                slots[i].playerSO = activePlayers[i];
                slots[i].UpdateData();
            }else{
                slots[i].gameObject.SetActive(false);
            }
        }
        if (activePlayers.Count < slots.Length)
        {
            int index = activePlayers.Count;
            slots[index].gameObject.SetActive(true);
            slots[index].ShowAddBtn();
        }
        availableText.text = $"Using {activePlayers.Count} out of {slots.Length}";
        SavePlayers();
    }
    public void SetSelectedSlot(Slot slot)
    {
        if (slot != null)
        {
            SelectedSlot = slot;
        }
    }
    private void SavePlayers(){
        List<PlayerData> _gamerData = new List<PlayerData>();
        foreach (Player gamer in activePlayers)
        {
            _gamerData.Add(gamer.GetPlayerData());
        }
        FileHandler.SaveToJSON(_gamerData,"players.json");
    }
    private void LoadPlayers(){
        int index = 0;
        List<PlayerData> _loadedTeam = FileHandler.ReadListFromJSON<PlayerData>("players.json");
        foreach (PlayerData data in _loadedTeam)
        {
            if (index < playerPool.Length)
            {
                playerPool[index].SetPlayerData(data);
                index++;
            }
        }
    }    
}