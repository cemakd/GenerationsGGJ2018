using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class PlayerUpgrades : MonoBehaviour {

	public enum BodyPart {None, Claws, Wings, Legs, Feet, Arms, Gills, Eyes, WingSpan};

	public GameObject claws;
	public GameObject wings;
	public GameObject legs;
	public GameObject arms;
	public GameObject gills;
	public GameObject eyes;


    private bool isPlayer = false;
    private int clawLevel = 0;
    private List<GameObject> clawList = new List<GameObject>();
    private int legsLevel = 0;
    private int feetLevel = 0;
    private List<GameObject> feetList = new List<GameObject>();
    private int wingsLevel = 0;
    private int wingSpanLevel = 0;
    private List<GameObject> wingList = new List<GameObject>();
    private int eyesLevel = 0;
    private List<GameObject> eyeList = new List<GameObject>();
    private int armsLevel = 0;
    private List<GameObject> armList = new List<GameObject>();
    private int gillsLevel = 0;
    private List<GameObject> gillsList = new List<GameObject>();

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
			    Debug.Log ("Legs");
                if (feetList.Count > 0)
                    EnlargeScale(feetList);
                if (isPlayer) {
                    GetComponent<PlatformerCharacter2D>().UpgradeJumpHeight();
                }
                break;
            case BodyPart.Feet:
                Debug.Log("Feet upgraded");
                feetLevel++;
                Add_Body_Part_To_Character(BodyPart.Feet);
                if (feetLevel == 1) {
                    for (int i = 0; i < legsLevel; ++i) {
                        EnlargeScale(feetList);
                    }
                }
                if (isPlayer) {
                    GetComponent<PlatformerCharacter2D>().UpgradeMovementSpeed();
                }
                break;
            case BodyPart.Wings:
                Debug.Log("Wings");
                Add_Body_Part_To_Character (BodyPart.Wings);
                if (isPlayer) {
                    GetComponent<PlatformerCharacter2D>().UpgradeDoubleJump();
                }
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
            case BodyPart.Gills:
    //            Add_Body_Part_To_Character(BodyPart.Gills);
                Debug.Log("Gills upgraded");
                gillsLevel++;
                break;
            case BodyPart.WingSpan:
                Debug.Log("Wing Span upgraded");
                wingSpanLevel++;
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
		case BodyPart.Feet:
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
	    new_part.transform.localScale = Vector3.one;
		new_part.transform.parent = transform;

        switch (part) {
            case BodyPart.Arms:
                armList.Add(new_part);
                break;
            case BodyPart.Feet:
                feetList.Add(new_part);
                break;
            case BodyPart.Wings:
                wingList.Add(new_part);
                break;
            case BodyPart.Eyes:
                eyeList.Add(new_part);
                break;
            case BodyPart.Claws:
                clawList.Add(new_part);
                break;
            case BodyPart.Gills:
                part_to_add = gills;
                break;
            default: //just to appease compiler
                part_to_add = wings;
                break;
        }
    }

    private void EnlargeScale(List<GameObject> list) {
//        Debug.Log(list + " enlarged");
        foreach (GameObject obj in list) {
            obj.transform.localScale *= 1.2f;
        }
    }
}
