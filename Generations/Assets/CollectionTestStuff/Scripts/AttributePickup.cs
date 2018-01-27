using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributePickup : MonoBehaviour {


	void OnTriggerEnter2D (Collider2D other) {
		AttributeCollection bpc = other.GetComponent<AttributeCollection> ();
		if (bpc != null) {
			bpc.Add_Part (gameObject);
		}
	}
}
