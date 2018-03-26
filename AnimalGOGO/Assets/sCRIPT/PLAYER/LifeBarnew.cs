using UnityEngine;
using System.Collections;

public class LifeBarnew : MonoBehaviour {
	SpriteRenderer sr;
	public Sprite[] Sn;
	// Use this for initialization
	void Start () {
		sr = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		sr.sprite = Sn[UniversGod.Player_Health];
	}
}
