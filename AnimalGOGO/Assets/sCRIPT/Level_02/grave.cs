using UnityEngine;
using System.Collections;

public class grave : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (God_.level == 1) {
			Destroy (gameObject);
		}
	}
}
