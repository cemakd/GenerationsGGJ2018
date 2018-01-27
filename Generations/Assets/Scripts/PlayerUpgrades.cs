using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class PlayerUpgrades : MonoBehaviour {

    private int clawLevel = 0;
    private int legsLevel = 0;
    private int wingsLevel = 0;
    private int eyesLevel = 0;

    public void Upgrade(Collectible.CollectibleType type) {
        switch (type) {
            case Collectible.CollectibleType.Strenght:
                clawLevel++;
                break;
            case Collectible.CollectibleType.Agility:
                legsLevel++;
                GetComponent<PlatformerCharacter2D>().UpgradeJumpHeight();
                break;
            case Collectible.CollectibleType.Flight:
                wingsLevel++;
                break;
            case Collectible.CollectibleType.Vision:
                eyesLevel++;
                break;
        }
    }
}
