using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributeCollection : MonoBehaviour {

	public List<GameObject> attribute_collection;
	public AttributeDisplayer displayer;

	PlayerUpgrades pu;

	// Use this for initialization
	void Start () {
		attribute_collection = new List<GameObject> ();
		pu = GetComponent<PlayerUpgrades> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Add_Part(GameObject attribute) {
		attribute_collection.Add (attribute);

		if (displayer != null)
			displayer.Add_Part_Display (attribute);

		attribute.SetActive (false);

		//check if you have enough attributes for a body part
		PlayerUpgrades.BodyPart part = Has_Enough_For_Upgrade();
		pu.Upgrade(part);
	}

	bool Satisfies_Upgrade_Set(int index) {
		List<bool> was_checked = new List<bool>();
		int size = attribute_collection.Count;
		for (int i = 0; i < size; i++) {
			was_checked.Add (false);
		}

		foreach (var attr in upgrade_sets[index]) { //loop through attributes in 'recipe'
			bool found = false;
			for (int i = 0; i < size; i++) { //loop through player's collected attributes
				if (attribute_collection [i].GetComponent<Collectible> ().type == attr && !was_checked [i]) {
					was_checked [i] = true;
					found = true;
					break;
				}
			}
			if (!found) {
				return false;
			}
		}

		Debug.Log ("size before removal " + attribute_collection.Count);
		//Remove the attributes used in the recipe from the UI and attribute collection
		//it is important that this list is looped through backwards so the indices don't change
		for (int i = size - 1; i >= 0; i--) {
			if (was_checked [i]) {
				attribute_collection.RemoveAt (i);
			}
		}
		Debug.Log ("size after removal " + attribute_collection.Count);
		//call Reset Display
		displayer.Reset_Displayed_Items();

		return true;
	}

	//checks if the player has enough attributes collected to upgrade a body part
	PlayerUpgrades.BodyPart Has_Enough_For_Upgrade() {
		int BodyPartIndex = 0;

		foreach (var upgrade_set in upgrade_sets) { //loop through upgrade 'recipes'
			if (Satisfies_Upgrade_Set (BodyPartIndex)) {
				break;
			}
			BodyPartIndex++;
		}
		if (BodyPartIndex == upgrade_sets.Count) {
			return PlayerUpgrades.BodyPart.None;
		} else {
			switch (BodyPartIndex) {
			case 0:
				return PlayerUpgrades.BodyPart.Feet;
			case 1:
				return PlayerUpgrades.BodyPart.Eyes;
			case 2:
				return PlayerUpgrades.BodyPart.Wings;
			case 3:
				return PlayerUpgrades.BodyPart.Claws;
            case 4:
			    return PlayerUpgrades.BodyPart.Legs;
            case 5:
			    return PlayerUpgrades.BodyPart.WingSpan;
			default:
				Debug.Log ("wrong index in AttributeCollection, Has_Enough_For_Upgrades " + BodyPartIndex.ToString());
				return PlayerUpgrades.BodyPart.None;
			}
		}
	}


	//massive set of upgrade lists
	static List<List<Collectible.CollectibleType>> upgrade_sets = new List<List<Collectible.CollectibleType>>() {

		new List<Collectible.CollectibleType>() { //feet
			Collectible.CollectibleType.Agility,
			Collectible.CollectibleType.Agility,
			Collectible.CollectibleType.Agility,
			Collectible.CollectibleType.Agility,
			Collectible.CollectibleType.Agility},

        new List<Collectible.CollectibleType>() { //eyes
			Collectible.CollectibleType.Vision,
			Collectible.CollectibleType.Vision,
			Collectible.CollectibleType.Vision,
			Collectible.CollectibleType.Vision,
			Collectible.CollectibleType.Vision},

		new List<Collectible.CollectibleType>() { //wings
			Collectible.CollectibleType.Flight,
			Collectible.CollectibleType.Flight,
			Collectible.CollectibleType.Flight,
			Collectible.CollectibleType.Strenght,
			Collectible.CollectibleType.Strenght},

		new List<Collectible.CollectibleType>() { //claws
			Collectible.CollectibleType.Strenght,
			Collectible.CollectibleType.Strenght,
			Collectible.CollectibleType.Strenght,
			Collectible.CollectibleType.Agility,
			Collectible.CollectibleType.Agility,
			Collectible.CollectibleType.Agility},

        new List<Collectible.CollectibleType>() { //legs
			Collectible.CollectibleType.Agility,
            Collectible.CollectibleType.Agility,
            Collectible.CollectibleType.Agility,
            Collectible.CollectibleType.Flight,
            Collectible.CollectibleType.Flight},

        new List<Collectible.CollectibleType>() { //wingspan
			Collectible.CollectibleType.Flight,
            Collectible.CollectibleType.Flight,
            Collectible.CollectibleType.Flight,
            Collectible.CollectibleType.Flight,
            Collectible.CollectibleType.Flight},
    };
}
