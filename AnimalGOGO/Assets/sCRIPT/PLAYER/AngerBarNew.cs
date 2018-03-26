using UnityEngine;
using System.Collections;

public class AngerBarNew : MonoBehaviour {
	SpriteRenderer sr2;
	public Sprite[] Sn2;
	// Use this for initialization
	void Start () {
		sr2 = GetComponent<SpriteRenderer>();
	}

	// Update is called once per frame
	void Update () {
		sr2.sprite = Sn2[UniversGod.Player_Anger];
	}
}