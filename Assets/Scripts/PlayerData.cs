using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int totalXP;
    public int coins;
    public int apples;

    public PlayerData (Player player)
    {
        coins += Player.coins;
        totalXP += Player.totalXP;
        apples += Player.apples;
    }

}
