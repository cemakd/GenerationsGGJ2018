using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets._2D;

public class PlayerUpgrades : MonoBehaviour {

	public enum BodyPart {None, Claws, Wings, Legs, Feet, Arms, Gills, Eyes, WingSpan};

    public Text upgradeText;
    public float textDuration = 5f;

	public GameObject claws;
	public GameObject wings;
	public GameObject legs;
	public GameObject eyes;

	private WallClimb wc;

    private bool isPlayer = false;
    public int clawLevel = 0;
    private List<GameObject> clawList = new List<GameObject>();
    public int legsLevel = 0;
    public int feetLevel = 0;
    private List<GameObject> feetList = new List<GameObject>();
    public int wingsLevel = 0;
    public int wingSpanLevel = 0;
    private List<GameObject> wingList = new List<GameObject>();
    public int eyesLevel = 0;
    private List<GameObject> eyeList = new List<GameObject>();

    void Start() {
		wc = GetComponent<WallClimb> ();

        if (GetComponent<PlatformerCharacter2D>() != null) {
            isPlayer = true;
			Debug.Log ("Setting up player for to gain things");
            for (int i = 0; i < PlayerPrefs.GetInt("claws"); ++i)
                Upgrade(BodyPart.Claws);
            for (int i = 0; i < PlayerPrefs.GetInt("feet"); ++i)
                Upgrade(BodyPart.Feet);
            for (int i = 0; i < PlayerPrefs.GetInt("legs"); ++i)
                Upgrade(BodyPart.Legs);
            for (int i = 0; i < PlayerPrefs.GetInt("wings"); ++i)
                Upgrade(BodyPart.Wings);
            for (int i = 0; i < PlayerPrefs.GetInt("wingspan"); ++i)
                Upgrade(BodyPart.WingSpan);
            for (int i = 0; i < 1; ++i)
                Upgrade(BodyPart.Eyes);
			Debug.Log ("Done setting up player");
        }
    }

	public void Upgrade(BodyPart type) {
        switch (type) {
		    case BodyPart.Legs:
                legsLevel++;
			    Debug.Log ("Legs");
                if (feetLevel > 0)
                    EnlargeScale(feetList);
                if (isPlayer) {
                    GetComponent<PlatformerCharacter2D>().UpgradeJumpHeight();
                    SetUpgradeText("Legs upgraded to lvl " + legsLevel + "!\nJump height increased");
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
                    SetUpgradeText("Feet upgraded to lvl " + feetLevel + "!\nMovement speed increased");
                }
                break;
            case BodyPart.Wings:
                Debug.Log("Wings");
                wingsLevel++;
                Add_Body_Part_To_Character (BodyPart.Wings);
                if (wingsLevel == 1) {
                    for (int i = 0; i < wingSpanLevel; ++i) {
                        EnlargeScale(wingList);
                    }
                }
                if (isPlayer) {
                    GetComponent<PlatformerCharacter2D>().UpgradeDoubleJump();
                    SetUpgradeText("Wings upgraded to lvl " + wingsLevel + "!\nDouble jump limit increased");
                }
                break;
		    case BodyPart.Eyes:
                Debug.Log("Eyes upgraded");
                eyesLevel++;
                Add_Body_Part_To_Character (BodyPart.Eyes);
                if (isPlayer) {
                    Debug.Log("Vision upgrade");
                    CameraGrow cg = Camera.main.gameObject.GetComponent<CameraGrow>();
                    cg.Grow();
                    SetUpgradeText("Eyes upgraded to lvl " + eyesLevel + "!\nVision increased");
                }
                break;
			case BodyPart.Claws:
				Add_Body_Part_To_Character (BodyPart.Claws);
				Debug.Log ("Claws");
                clawLevel++;
                if (isPlayer) {
                    wc.UpgradeWallClimb(1);
                    SetUpgradeText("Claws upgraded to lvl " + clawLevel + "!\nClimb walls higher by pressing up");
                }
			    
			    break;
            case BodyPart.WingSpan:
                Debug.Log("Wing Span upgraded");
                wingSpanLevel++;
                if (wingsLevel > 0)
                    EnlargeScale(wingList);
                if (isPlayer) {
                    GetComponent<PlatformerCharacter2D>().UpgradeGlideAbility();
                    SetUpgradeText("Wingspan upgraded to lvl " + wingSpanLevel + "!\nGlide longer by holding space");
                }
                break;
            case BodyPart.None:
			    Debug.Log ("None");
			    //do nothing
			    break;
		    default:
			    Debug.Log (type + " passed to Upgrade");
			    break;
        }
    }

	void Add_Body_Part_To_Character(BodyPart part) {
		GameObject part_to_add;

		switch (part) {
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

    private void SetUpgradeText(string txt) {
        upgradeText.gameObject.SetActive(true);
        upgradeText.text = txt;
        Invoke("DeactivateUpgradeText", textDuration);
    }

    private void DeactivateUpgradeText() {
        upgradeText.gameObject.SetActive(false);
    }
}
