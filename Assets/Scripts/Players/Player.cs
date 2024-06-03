using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player", menuName = "ScriptableObject/Player", order = 1)]
public class Player : ScriptableObject
{
    public String playerName;
    public bool playing;
    //public int orderIndex;
    public PlayerData GetPlayerData()
    {
        PlayerData data = new PlayerData(this.playerName, this.playing);
        return data;
    }
    public void SetPlayerData(PlayerData data) {
        this.playerName = data.PlayerName;
        this.playing = data.IsPlaying;
    }
}

[Serializable]
public class PlayerData
{
    public string PlayerName;
    public bool IsPlaying;
    public int OrderIndex;

    public PlayerData(string name, bool active) {
        PlayerName = name;
        IsPlaying = active;
    }
}
