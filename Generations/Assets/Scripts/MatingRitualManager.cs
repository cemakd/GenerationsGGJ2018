using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MatingRitualManager : MonoBehaviour {

    public List<GameObject> otherUI;
    public Text playerStats;
    public Text gfStats;
    public Text offspringStats;

    private PlayerUpgrades playerUpgrades;
    public PlayerUpgrades mateUpgrades;

    // Use this for initialization
    void Start () {
        playerUpgrades = GameObject.Find("Player").GetComponent<PlayerUpgrades>();
        playerStats.gameObject.SetActive(false);
        gfStats.gameObject.SetActive(false);
        offspringStats.gameObject.SetActive(false);
        foreach (var go in otherUI) {
            go.SetActive(false);
        }
    }

    public void UpdateStats() {
        UpdatePlayerStats(playerUpgrades, playerStats);
        UpdatePlayerStats(mateUpgrades, gfStats);
        UpdateOffspringStats();
        playerStats.gameObject.SetActive(true);
        gfStats.gameObject.SetActive(true);
        offspringStats.gameObject.SetActive(true);
        foreach (var go in otherUI) {
            go.SetActive(true);
        }
    }

    private void UpdateOffspringStats() {
        string statText = "";
        float totalLevel = playerUpgrades.feetLevel + mateUpgrades.feetLevel;
        if (totalLevel > 0) {
            statText += "Feet: Lvl " + Math.Ceiling(0.7f * totalLevel);
        }
        totalLevel = playerUpgrades.legsLevel + mateUpgrades.legsLevel;
        if (totalLevel > 0) {
            statText += "Legs: Lvl " + Math.Ceiling(0.7f * totalLevel);
        }
        totalLevel = playerUpgrades.armsLevel + mateUpgrades.armsLevel;
        if (totalLevel > 0) {
            statText += "Arms: Lvl " + Math.Ceiling(0.7f * totalLevel);
        }
        totalLevel = playerUpgrades.clawLevel + mateUpgrades.clawLevel;
        if (totalLevel > 0) {
            statText += "Claws: Lvl " + Math.Ceiling(0.7f * totalLevel);
        }
        totalLevel = playerUpgrades.eyesLevel + mateUpgrades.eyesLevel;
        if (totalLevel > 0) {
            statText += "Eyes: Lvl " + Math.Ceiling(0.7f * totalLevel);
        }
        totalLevel = playerUpgrades.wingsLevel + mateUpgrades.wingsLevel;
        if (totalLevel > 0) {
            statText += "Wings: Lvl " + Math.Ceiling(0.7f * totalLevel);
        }
        totalLevel = playerUpgrades.wingSpanLevel + mateUpgrades.wingSpanLevel;
        if (totalLevel > 0) {
            statText += "Wingspan: Lvl " + Math.Ceiling(0.7f * totalLevel);
        }
        totalLevel = playerUpgrades.gillsLevel + mateUpgrades.gillsLevel;
        if (totalLevel > 0) {
            statText += "Gills: Lvl " + Math.Ceiling(0.7f * totalLevel);
        }
        offspringStats.text = statText;
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
