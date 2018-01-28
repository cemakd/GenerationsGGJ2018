using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    public float secondsPerStage = 60;
    public bool stageCanEnd = false;

    public int currentStage = 1;

    void Awake() {
//        DontDestroyOnLoad(this);
    }

	// Use this for initialization
	void Start () {
	    switch (SceneManager.GetActiveScene().name) {
	        case "Scene1":
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
            case "GameOver":
	            break;
	    }
	    StartCoroutine(LoadStage(currentStage + 1));
	}

    void Update() {
        if (Input.GetKeyDown(KeyCode.R)) {
            SceneManager.LoadScene("Scene1");
            PlayerPrefs.SetInt("feet", 0);
            PlayerPrefs.SetInt("legs", 0);
            PlayerPrefs.SetInt("arms", 0);
            PlayerPrefs.SetInt("claws", 0);
            PlayerPrefs.SetInt("eyes", 0);
            PlayerPrefs.SetInt("wings", 0);
            PlayerPrefs.SetInt("wingspan", 0);
            PlayerPrefs.SetInt("gills", 0);
        }
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
            SceneManager.LoadScene("Scene" + stageNum);
        }
        yield return null;
    }

}
