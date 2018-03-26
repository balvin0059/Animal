using UnityEngine;
using System.Collections;

public class MapChange : MonoBehaviour {
	int a = 1;
	// Use this for initialization
	void Start () {
		a = God_.level;
	}
	
	// Update is called once per frame
	void Update () {
		if (God_.level != a) {
			Destroy (gameObject);
		}
	}
}
