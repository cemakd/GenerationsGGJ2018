using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttributeDisplayer : MonoBehaviour {

	public AttributeCollection bpc;
	public GameObject draw_on_UI;

	List<GameObject> displayed_items; //images

	// Use this for initialization
	void Start () {
		displayed_items = new List<GameObject> ();
	    GameObject player = GameObject.Find("Player");
	    if (player != null)
	        bpc = player.GetComponent<AttributeCollection>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Add_Part_Display(GameObject part) {
		//create child UI image
		GameObject display = Instantiate (draw_on_UI, transform);
		displayed_items.Add (display);

		//set display's position based on number already collected and add it to the internal list
		int num_collected = displayed_items.Count - 1;
		display.transform.position = new Vector2 (display.transform.position.x + (num_collected - 1) * 50, display.transform.position.y);

		//set image component image to collected
		display.GetComponent<Image> ().sprite = part.GetComponent<SpriteRenderer>().sprite;
		display.GetComponent<Image> ().color = part.GetComponent<SpriteRenderer> ().color;
	}

	public void Reset_Displayed_Items() {
		foreach (var disp in displayed_items) {
			Destroy (disp);
		}

		displayed_items.Clear ();
//        Debug.Log(bpc.attribute_collection);
		foreach (var collected_attribute in bpc.attribute_collection) {
            Debug.Log(collected_attribute.gameObject.name);
			Add_Part_Display (collected_attribute);
		}
	}

	public void Collection_Disappear() {
		foreach (var collected in displayed_items) {
			collected.SetActive (false);
			Destroy (collected);
		}
	}
}
