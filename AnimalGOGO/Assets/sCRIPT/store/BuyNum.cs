using UnityEngine;
using System.Collections;

public class BuyNum : MonoBehaviour {
	
	SpriteRenderer sr;
	public Sprite[] Sl;
	public int getNum = 0;

	// Use this for initialization
	void Start () {
		sr = GetComponent<SpriteRenderer>();
	}

	// Update is called once per frame
	void Update ()
	{
		
		getNum = Buy.BuyItemLevel;
		sr.sprite = Sl [getNum];
	}
}
