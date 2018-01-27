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

	void OnTriggerEnter2D (Collider2D other) {
		AttributeCollection bpc = other.GetComponent<AttributeCollection> ();
		if (bpc != null) {
			bpc.Add_Part (gameObject);
		}
	}
}
