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

    public Sprite strImg;
    public Sprite agiImg;
    public Sprite fliImg;
    public Sprite visImg;

    public CollectibleType type;

    void Start() {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.color = new Color(255, 255, 255, 1);
        switch (type) {
            case CollectibleType.Strenght:
                sr.sprite = strImg;
                break;
            case CollectibleType.Agility:
                sr.sprite = agiImg;
                break;
            case CollectibleType.Flight:
                sr.sprite = fliImg;
                break;
            case CollectibleType.Vision:
                sr.sprite = visImg;
                break;
        }
    }

	void OnTriggerEnter2D (Collider2D other) {
		AttributeCollection bpc = other.GetComponent<AttributeCollection> ();
		if (bpc != null) {
			bpc.Add_Part (gameObject);
		}
	}
}
