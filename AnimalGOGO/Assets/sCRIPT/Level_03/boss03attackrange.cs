using UnityEngine;
using System.Collections;

public class boss03attackrange : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {	
	}
	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Player") {
			if (col.gameObject.tag == "Monster") {
				col.gameObject.SendMessage ("getdir",0);
			}
		}
	}
}
