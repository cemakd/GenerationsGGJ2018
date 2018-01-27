using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MatingRitualManager : MonoBehaviour {

    public Text playerStats;
    public Text gfStats;
    public Text offspringStats;

    private PlayerUpgrades playerUpgrades;
    public PlayerUpgrades mateUpgrades;

    // Use this for initialization
    void Start () {
        playerUpgrades = GameObject.Find("Player").GetComponent<PlayerUpgrades>();
    }

    public void UpdateStats() {
        UpdatePlayerStats(playerUpgrades, playerStats);
        UpdatePlayerStats(mateUpgrades, gfStats);
        UpdateOffspringStats();
    }

    private void UpdatePlayerStats(PlayerUpgrades pu, Text txt) {
        string statText = "";
        if (pu.feetLevel > 0)
            statText += "Feet: Lvl " + pu.feetLevel;
        if (pu.legsLevel > 0)
            statText += "Legs: Lvl " + pu.legsLevel;
        if (pu.armsLevel > 0)
            statText += "Arms: Lvl " + pu.armsLevel;
        if (pu.clawLevel > 0)
            statText += "Claws: Lvl " + pu.clawLevel;
        if (pu.eyesLevel > 0)
            statText += "Eyes: Lvl " + pu.eyesLevel;
        if (pu.wingsLevel > 0)
            statText += "Wings: Lvl " + pu.wingsLevel;
        if (pu.wingSpanLevel > 0)
            statText += "Wingspan: Lvl " + pu.wingSpanLevel;
        if (pu.gillsLevel > 0)
            statText += "Gills: Lvl " + pu.gillsLevel;
        txt.text = statText;
    }
}
