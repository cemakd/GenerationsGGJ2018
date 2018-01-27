using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class Collectible : MonoBehaviour {

    public enum CollectibleType {
        Strenght,
        Agility,
        Flight,
        Vision
    }

    public CollectibleType type;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.GetComponent<PlatformerCharacter2D>() != null) {
            PlayerUpgrades pu = other.gameObject.GetComponent<PlayerUpgrades>();
            pu.Upgrade(type);
            Destroy(gameObject);
        }
    }
}
