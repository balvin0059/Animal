using UnityEngine;
using System.Collections;

public class bkaphla : MonoBehaviour {
	SpriteRenderer sr;
	public Transform target;
	// Use this for initialization
	void Start () {
		sr = GetComponent<SpriteRenderer>();
		sr.color = new Color (1f, 1f, 1f, 0f);
	}
	
	// Update is called once per frame
	void Update () {
		target = GameObject.FindWithTag ("Player").transform;
		transform.position = target.position;
		if (UniversGod.GamePause == true) {
			sr.color = new Color (1f, 1f, 1f, 0.5f);
		} else {
			sr.color = new Color (1f, 1f, 1f, 0f);
		}
		if (!target) {
			return;	
		}
	}
}
