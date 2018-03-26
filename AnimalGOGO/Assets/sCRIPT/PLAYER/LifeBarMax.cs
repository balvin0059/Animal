using UnityEngine;
using System.Collections;

public class LifeBarMax : MonoBehaviour {
	SpriteRenderer sr1;
	public Sprite[] Sn1;
	// Use this for initialization
	void Start () {
		sr1 = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		sr1.sprite = Sn1[UniversGod.Player_HealthMax];
	}
}
