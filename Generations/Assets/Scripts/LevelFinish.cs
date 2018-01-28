using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;
using UnityEngine.UI;

public class LevelFinish : MonoBehaviour {

    private SceneLoader sl;
	public GameObject mate_instruction;
	private GameObject mate_text;

    void Start() {
		mate_text = Instantiate (mate_instruction, new Vector2 (1000, 100), Quaternion.identity);
		mate_text.SetActive (false);

        GameObject slObj = GameObject.Find("SceneLoader");
        if (slObj != null)
            sl = slObj.GetComponent<SceneLoader>();
    }

    void OnTriggerEnter2D(Collider2D other) {
        GameObject otherGO = other.gameObject;
        if (sl != null && otherGO.GetComponent<PlatformerCharacter2D>() != null) {
			mate_text.SetActive (true);

            GameObject matingPanel = GameObject.Find("Mating Ritual");
            MatingRitualManager mrm = matingPanel.GetComponent<MatingRitualManager>();
            mrm.mateUpgrades = GetComponent<PlayerUpgrades>();
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        GameObject otherGO = other.gameObject;
        if (sl != null && otherGO.GetComponent<PlatformerCharacter2D>() != null) {
			mate_text.SetActive (false);
            sl.stageCanEnd = false;
        }
    }

    void OnTriggerStay2D(Collider2D other) {
        GameObject otherGO = other.gameObject;
        if (sl != null && otherGO.GetComponent<PlatformerCharacter2D>() != null) {
            sl.stageCanEnd = true;
            if (Input.GetKeyDown(KeyCode.DownArrow))
                StartCoroutine(sl.LoadNextStage());
        }
    }
}
