using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int totalXP;
    public int coins;

    public PlayerData (Player player)
    {
        coins = Player.coins;
        totalXP = Player.totalXP;
    }
}
