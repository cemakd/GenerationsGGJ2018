using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    public float secondsPerStage = 60;
    public bool stageCanEnd = false;

    public int currentStage = 1;

    void Awake() {
        DontDestroyOnLoad(this);
    }

	// Use this for initialization
	void Start () {
	    switch (SceneManager.GetActiveScene().name) {
	        case "Stage1":
	            currentStage = 1;
	            break;
	        case "Stage2":
	            currentStage = 2;
	            break;
	        case "Stage3":
	            currentStage = 3;
	            break;
	        case "Stage4":
	            currentStage = 4;
	            break;
	        case "Stage5":
	            currentStage = 5;
	            break;
	    }
	    StartCoroutine(LoadStage(currentStage + 1));
	}

    IEnumerator LoadStage(int stageNum) {
        yield return new WaitForSeconds(secondsPerStage);
        if (!stageCanEnd) {
            SceneManager.LoadScene("GameOver");
        }
        else {
            GameObject.Find("Mating Ritual").GetComponent<MatingRitualManager>().UpdateStats();
            yield return new WaitForSeconds(5f);
            if (stageNum == 6)
                SceneManager.LoadScene("WinGame");
            SceneManager.LoadScene("Stage" + stageNum);
        }
        yield return null;
    }

}
