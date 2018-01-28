using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    public float secondsPerStage = 60;
    public bool stageCanEnd = false;

    public int currentStage = 1;

    void Awake() {
        switch (SceneManager.GetActiveScene().name)
        {
            case "Tutorial":
                currentStage = 0;
                Reset_Body_Player_Prefs();
                break;
            case "Scene1":
                currentStage = 1;
                Reset_Body_Player_Prefs();
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
        if (Input.GetKeyDown(KeyCode.Escape)) {
            SceneManager.LoadScene("Menu");
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
            if (stageNum == 5)
                SceneManager.LoadScene("WinGame");
            StartCoroutine(LoadLevel("Scene" + (currentStage + 1), 1f));
        }
        yield return null;
    }

    public IEnumerator LoadNextStage() {
        GameObject.Find("Mating Ritual").GetComponent<MatingRitualManager>().UpdateStats();
        yield return new WaitForSeconds(5f);
//        if (SceneManager.GetActiveScene().name == "Tutorial")
//            StartCoroutine(LoadLevel("Scene1", 1f));
        if (currentStage == 5)
            SceneManager.LoadScene("WinGame");
        StartCoroutine(LoadLevel("Scene" + (currentStage + 1), 1f));
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

    public void Play() {
        Fading fader = GameObject.Find("SceneTransition").GetComponent<Fading>();
        if (fader != null)
            fader.BeginFade(1);
        StartCoroutine(LoadLevel("Scene1", 1f));
    }

    public void Tutorial() {
        Fading fader = GameObject.Find("SceneTransition").GetComponent<Fading>();
        if (fader != null)
            fader.BeginFade(1);
        StartCoroutine(LoadLevel("Tutorial", 1f));
    }

    public void Credits() {
        Fading fader = GameObject.Find("SceneTransition").GetComponent<Fading>();
        if (fader != null)
            fader.BeginFade(1);
        StartCoroutine(LoadLevel("Credits", 1f));
    }

    private IEnumerator LoadLevel(string name, float seconds) {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(name);
    }
}
