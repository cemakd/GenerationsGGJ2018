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
	        case "Scene2":
	            currentStage = 2;
	            break;
	        case "Scene3":
	            currentStage = 3;
	            break;
	        case "Scene4":
	            currentStage = 4;
	            break;
	        case "Scene5":
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
			Reset_Body_Player_Prefs ();
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

    public IEnumerator LoadNextStage() {
        GameObject.Find("Mating Ritual").GetComponent<MatingRitualManager>().UpdateStats();
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("Scene" + (currentStage + 1));
        yield return null;
    }

	public void Reset_Body_Player_Prefs() {
		PlayerPrefs.SetInt("feet", 0);
		PlayerPrefs.SetInt("legs", 0);
		PlayerPrefs.SetInt("claws", 0);
		PlayerPrefs.SetInt("eyes", 0);
		PlayerPrefs.SetInt("wings", 0);
		PlayerPrefs.SetInt("wingspan", 0);
	}
}
