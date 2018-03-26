using UnityEngine;
using System.Collections;

public class CHARInfo : MonoBehaviour {
	SpriteRenderer sr;
	public Sprite Sn1;
	public Sprite Sn2;
	public Sprite Sn3;
	public Sprite Sn4;
	public Sprite Sn5;
	public Sprite Sn6;
	public Sprite Sn7;
	public Sprite Sn8;
	public static int InfoNum = 0;
	
	// Use this for initialization
	void Start () {
		sr = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		switch (InfoNum) {
		case 0:
			sr.sprite = Sn1;
			break;
		case 1:
			sr.sprite = Sn2;
			break;
		case 2:
			sr.sprite = Sn3;
			break;
		case 3:
			sr.sprite = Sn4;
			break;
		case 4:
			sr.sprite = Sn5;
			break;
		case 5:
			sr.sprite = Sn6;
			break;
		case 6:
			sr.sprite = Sn7;
			break;
		case 7:
			sr.sprite = Sn8;
			break;
		}
	}
}
