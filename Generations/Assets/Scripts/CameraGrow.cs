using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraGrow : MonoBehaviour {

    public float growDuration = 3f;
    private Camera camera;

	// Use this for initialization
	void Start () {
	    camera = GetComponent<Camera>();
	}

    public void Grow() {
        StartCoroutine(ExpandToSize(camera.orthographicSize + 2, growDuration));
    }

    private IEnumerator ExpandToSize(float targetSize, float time) {
        float startingSize = camera.orthographicSize;
        float elapsedTime = 0f;
        while (elapsedTime < time) {
            camera.orthographicSize = Mathf.Lerp(startingSize, targetSize, elapsedTime / time);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
}
