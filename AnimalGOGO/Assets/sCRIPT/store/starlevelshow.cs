using UnityEngine;
using System.Collections;

public class starlevelshow : MonoBehaviour {
	SpriteRenderer sr;
	public Sprite[] star;
	// Use this for initialization
	void Start () {
		sr = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		switch (itemInfo.ItemIDInfo) {
		case 0:
			sr.sprite = star[itemInfo.treasureLv];
			break;
		case 1:
			
			sr.sprite = star[itemInfo.livebuttonLv];
			break;
		case 2:
			sr.sprite = star[itemInfo.bombLv];
			break;
		case 3:
			sr.sprite = star[itemInfo.magnetLv];
			break;
		case 4:
			sr.sprite = star[itemInfo.superstarLv];
			break;
		case 5:
			sr.sprite = star[itemInfo.energyLv];
			break;
		case 6:
			sr.sprite = star[itemInfo.timestopLv];
			break;
		case 7:
			sr.sprite = star[4];
			break;
		}
	}
}
