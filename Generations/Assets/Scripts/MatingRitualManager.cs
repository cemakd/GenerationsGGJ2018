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

	double LevelRandomizer(float a, float b)
	{
		return UnityEngine.Random.Range(0, 1) > 0.5f ? Math.Ceiling((a + b) * UnityEngine.Random.Range(1, 1.3f)) : 
			Math.Ceiling((a + b) * UnityEngine.Random.Range(0.7f, 1f));
	}
    private void UpdateOffspringStats() {
        string statText = "";
	    double totalLevel = LevelRandomizer(playerUpgrades.feetLevel, mateUpgrades.feetLevel);
	    if (totalLevel > 0)
	    {
		    statText += "Feet: Lvl " + totalLevel + "\n";
		}
		totalLevel = LevelRandomizer(playerUpgrades.legsLevel , mateUpgrades.legsLevel);
		if (totalLevel > 0)
		{
			statText += "Legs: Lvl " + totalLevel + "\n";
		}
		totalLevel = LevelRandomizer(playerUpgrades.armsLevel, mateUpgrades.armsLevel);
		if (totalLevel > 0)
		{
			statText += "Arms: Lvl " + totalLevel + "\n";
		}
		totalLevel = LevelRandomizer(playerUpgrades.clawLevel, mateUpgrades.clawLevel);
		if (totalLevel > 0)
		{
			statText += "Claws: Lvl " + totalLevel + "\n";
		}
		totalLevel = LevelRandomizer(playerUpgrades.eyesLevel, mateUpgrades.eyesLevel);
		if (totalLevel > 0)
		{
			statText += "Eyes: Lvl " + totalLevel + "\n";
		}
		totalLevel = LevelRandomizer(playerUpgrades.wingsLevel, mateUpgrades.wingsLevel);
		if (totalLevel > 0)
		{
			statText += "Wings: Lvl " + totalLevel + "\n";
		}
		totalLevel = LevelRandomizer(playerUpgrades.wingSpanLevel, mateUpgrades.wingSpanLevel);
		if (totalLevel > 0)
		{
			statText += "Wingspan: Lvl " + totalLevel + "\n";
		}
		totalLevel = LevelRandomizer(playerUpgrades.gillsLevel, mateUpgrades.gillsLevel);
		if (totalLevel > 0)
		{
			statText += "Gills: Lvl " + totalLevel + "\n";
		}
		offspringStats.text = statText;
    }

    private void UpdatePlayerStats(PlayerUpgrades pu, Text txt) {
        string statText = "";
        if (pu.feetLevel > 0)
            statText += "Feet: Lvl " + pu.feetLevel + "\n";
        if (pu.legsLevel > 0)
            statText += "Legs: Lvl " + pu.legsLevel + "\n";
        if (pu.armsLevel > 0)
            statText += "Arms: Lvl " + pu.armsLevel + "\n";
        if (pu.clawLevel > 0)
            statText += "Claws: Lvl " + pu.clawLevel + "\n";
        if (pu.eyesLevel > 0)
            statText += "Eyes: Lvl " + pu.eyesLevel + "\n";
        if (pu.wingsLevel > 0)
            statText += "Wings: Lvl " + pu.wingsLevel + "\n";
        if (pu.wingSpanLevel > 0)
            statText += "Wingspan: Lvl " + pu.wingSpanLevel + "\n";
        if (pu.gillsLevel > 0)
            statText += "Gills: Lvl " + pu.gillsLevel + "\n";
        txt.text = statText;
    }
}
