using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPartCollection : MonoBehaviour {

	public List<GameObject> body_collection;
	public BodyPartDisplayer displayer;

	// Use this for initialization
	void Start () {
		body_collection = new List<GameObject> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Add_Part(GameObject part) {
		body_collection.Add (part);
		displayer.Add_Part_Display (part);

		part.transform.position = new Vector2 (transform.position.x + Random.Range(-1f, 1f), transform.position.y + Random.Range(0f, 1f));
		part.transform.parent = transform;
	}
}
