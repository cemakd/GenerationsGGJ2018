using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSpan : MonoBehaviour
{

	private SpriteRenderer sr;
	private Color currentColor;
	[SerializeField] public float timeToDeath;
	private float t ;
	// Use this for initialization
	void Start ()
	{
		sr = GetComponentInChildren<SpriteRenderer>();
		currentColor = sr.color;

	}

	// Update is called once per frame
	void Update () {
		Color updateColor = Color.Lerp(currentColor, Color.black, t);
		updateColor.a = Mathf.Lerp(1, 0.7f, t);
		sr.color = updateColor;
		if (t < 1)
		{
			t += Time.deltaTime / timeToDeath;
		}
		
	}
}
