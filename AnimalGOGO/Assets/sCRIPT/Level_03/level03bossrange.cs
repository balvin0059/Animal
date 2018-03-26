using UnityEngine;
using System.Collections;

public class level03bossrange : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {	
	}
	void OnTriggerEnter2D(Collider2D col){		
		if (col.gameObject.tag == "Wall") {
			if (col.gameObject.tag == "Monster") {
				col.gameObject.SendMessage ("WallAndChangeWay",1);
			}
		}
	}
	void OnTriggerStay2D(Collider2D col){
		if (col.gameObject.tag == "Wall") {
			if (col.gameObject.tag == "Monster") {
				col.gameObject.SendMessage ("WallAndChangeWay",1);
			}
		}
	}
}
