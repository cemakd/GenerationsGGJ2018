using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class PlayerUpgrades : MonoBehaviour {

	public enum BodyPart {None, Claws, Wings, Legs, Arms, Gills, Eyes};

    private int clawLevel = 0;
    private int legsLevel = 0;
    private int wingsLevel = 0;
    private int eyesLevel = 0;
	private int armsLevel = 0;

	public void Upgrade(BodyPart type) {
        switch (type) {
		case BodyPart.Arms:
			armsLevel++;
			Debug.Log ("Arms");
            break;
		case BodyPart.Legs:
            legsLevel++;
			Debug.Log ("Legs");
            GetComponent<PlatformerCharacter2D>().UpgradeJumpHeight();
            break;
		case BodyPart.Wings:
			Debug.Log ("Wings");
            wingsLevel++;
            break;
		case BodyPart.Eyes:
			Debug.Log ("Eyes");
            eyesLevel++;
            break;
		case BodyPart.Claws:
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
}
