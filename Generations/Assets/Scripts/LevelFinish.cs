using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class LevelFinish : MonoBehaviour {

    private SceneLoader sl;

    void Start() {
        GameObject slObj = GameObject.Find("SceneLoader");
        if (slObj != null)
            sl = slObj.GetComponent<SceneLoader>();
    }

    void OnTriggerEnter2D(Collider2D other) {
        GameObject otherGO = other.gameObject;
        if (sl != null && otherGO.GetComponent<PlatformerCharacter2D>() != null) {
            GameObject matingPanel = GameObject.Find("Mating Ritual");
            MatingRitualManager mrm = matingPanel.GetComponent<MatingRitualManager>();
            mrm.mateUpgrades = GetComponent<PlayerUpgrades>();
        }
    }

    void OnTriggerStay2D(Collider2D other) {
        GameObject otherGO = other.gameObject;
        if (sl != null && otherGO.GetComponent<PlatformerCharacter2D>() != null) {
            sl.stageCanEnd = true;
        }
        else {
            sl.stageCanEnd = false;
        }
    }
}
