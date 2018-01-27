using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class PlayerUpgrades : MonoBehaviour {

	public enum BodyPart {None, Claws, Wings, Legs, Arms, Gills, Eyes};

	public GameObject claws;
	public GameObject wings;
	public GameObject legs;
	public GameObject arms;
	public GameObject gills;
	public GameObject eyes;


    private bool isPlayer = false;
    private int clawLevel = 0;
    private int legsLevel = 0;
    private int wingsLevel = 0;
    private int eyesLevel = 0;
	private int armsLevel = 0;

    void Start() {
        if (GetComponent<PlatformerCharacter2D>() != null)
            isPlayer = true;
    }

	public void Upgrade(BodyPart type) {
        switch (type) {
		case BodyPart.Arms:
			armsLevel++;
			Add_Body_Part_To_Character (BodyPart.Arms);
			Debug.Log ("Arms");
            break;
		case BodyPart.Legs:
            legsLevel++;
			Add_Body_Part_To_Character (BodyPart.Legs);
			Debug.Log ("Legs");
            if (isPlayer) {
                GetComponent<PlatformerCharacter2D>().UpgradeJumpHeight();
            }
            break;
		case BodyPart.Wings:
			Add_Body_Part_To_Character (BodyPart.Wings);
			Debug.Log ("Wings");
            wingsLevel++;
            break;
		case BodyPart.Eyes:
			Add_Body_Part_To_Character (BodyPart.Eyes);
			Debug.Log ("Eyes");
            eyesLevel++;
            break;
		case BodyPart.Claws:
			Add_Body_Part_To_Character (BodyPart.Claws);
			Debug.Log ("Claws");
			clawLevel++;
			break;
		case BodyPart.None:
			Debug.Log ("None");
			//do nothing
			break;
		default:
			Debug.Log ("Something else passed to Upgrade");
			break;
        }
    }

	void Add_Body_Part_To_Character(BodyPart part) {
		GameObject part_to_add;

		switch (part) {
		case BodyPart.Arms:
			part_to_add = arms;
			break;
		case BodyPart.Legs:
			part_to_add = legs;
			break;
		case BodyPart.Wings:
			part_to_add = wings;
			break;
		case BodyPart.Eyes:
			part_to_add = eyes;
			break;
		case BodyPart.Claws:
			part_to_add = claws;
			break;
		case BodyPart.Gills:
			part_to_add = gills;
			break;
		default: //just to appease compiler
			part_to_add = wings;
			break;
		}

		GameObject new_part = Instantiate (part_to_add, new Vector2(
			transform.position.x + Random.Range(-0.1f, 0.1f),
			transform.position.y + Random.Range(-0.1f, 0.1f)), Quaternion.identity);

		new_part.transform.parent = transform;
	}
}
