using UnityEngine;
using System.Collections;

public class nomoney : MonoBehaviour {
	float i = 1.5f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		i -= Time.deltaTime;
		if (i <= 0) {			
			Destroy (gameObject);
		}
	}
}
