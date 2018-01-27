using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttributeDisplayer : MonoBehaviour {

	public AttributeCollection bpc;
	public GameObject draw_on_UI;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Add_Part_Display(GameObject part) {
		//create child UI image
		GameObject display = Instantiate(draw_on_UI, transform);

		//set display's position based on number already collected
		int num_collected = bpc.attribute_collection.Count;
		display.transform.position = new Vector2 (display.transform.position.x + (num_collected-1) * 50, display.transform.position.y);

		//set image component image to collected
		display.GetComponent<Image> ().sprite = part.GetComponent<SpriteRenderer>().sprite;
	}
}
