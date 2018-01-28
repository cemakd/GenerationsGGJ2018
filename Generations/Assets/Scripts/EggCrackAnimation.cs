using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggCrackAnimation : MonoBehaviour {

	public Sprite[] eggSprites;
	private SpriteRenderer sr;
	public GameObject p;
	// Use this for initialization
	void Start()
	{
		sr = GetComponent<SpriteRenderer>();
		StartCoroutine("CrackAnimation");
	}

	// Update is called once per frame
	void Update()
	{
	}

	public IEnumerator CrackAnimation()
	{
		yield return new WaitForSeconds(0.4f);
		sr.sprite = eggSprites[0];
		yield return new WaitForSeconds(0.4f);
		sr.sprite = eggSprites[1];
		yield return new WaitForSeconds(0.4f);
		sr.sprite = eggSprites[2];
		yield return new WaitForSeconds(0.4f);
		Destroy(this.gameObject);
		Instantiate(p, transform.position, Quaternion.identity);
		yield return null;
	}
}
