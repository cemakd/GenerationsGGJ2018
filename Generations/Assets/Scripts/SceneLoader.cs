using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    public float secondsPerStage = 60;

    private int currentStage = 1;

	// Use this for initialization
	void Start () {
	    if (SceneManager.GetActiveScene().name == "Stage1")
	        currentStage = 1;
        else if (SceneManager.GetActiveScene().name == "Stage2")
            currentStage = 2;
        else if (SceneManager.GetActiveScene().name == "Stage3")
            currentStage = 3;
        else if (SceneManager.GetActiveScene().name == "Stage4")
            currentStage = 4;
        else if (SceneManager.GetActiveScene().name == "Stage5")
            currentStage = 5;

        StartCoroutine(LoadStage(currentStage + 1));
	}

    IEnumerator LoadStage(int stageNum) {
        yield return new WaitForSeconds(secondsPerStage);
        if (stageNum == 6)
            SceneManager.LoadScene("EndGame");
        SceneManager.LoadScene("Stage" + stageNum);
        yield return null;
    }

}
