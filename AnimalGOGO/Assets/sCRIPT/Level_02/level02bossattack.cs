using UnityEngine;
using System.Collections;

public class level02bossattack : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {	
	}
	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Player") {
			if (col.gameObject.tag == "Monster") {
				col.gameObject.SendMessage ("getattackmessge",0);
			}
		}
		if (col.gameObject.tag == "Wall") {
			if (col.gameObject.tag == "Monster") {
				col.gameObject.SendMessage ("WallAndChangeWay",1);
			}
		}
	}
	void OnTriggerStay2D(Collider2D col){
		if (col.gameObject.tag == "Player") {
			if (col.gameObject.tag == "Monster") {
				col.gameObject.SendMessage ("getattackmessge",0);
			}
		}
		if (col.gameObject.tag == "Wall") {
			if (col.gameObject.tag == "Monster") {
				col.gameObject.SendMessage ("WallAndChangeWay",1);
			}
		}
	}
	void OnTriggerExit2D(Collider2D col){
		if (col.gameObject.tag == "Player") {
			if (col.gameObject.tag == "Monster") {
				col.gameObject.SendMessage ("getattackmessge",1);
			}
		}
	}
}
