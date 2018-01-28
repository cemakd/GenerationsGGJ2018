using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maketransparent : MonoBehaviour
{

	private SpriteRenderer sr;
	// Use this for initialization
	void Start ()
	{
		sr = GetComponent<SpriteRenderer>();
		sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0.7f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
