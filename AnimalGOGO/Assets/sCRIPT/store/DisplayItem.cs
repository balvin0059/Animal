using UnityEngine;
using System.Collections;

public class DisplayItem : MonoBehaviour {
	int a = 0;
	// Use this for initialization
	void Start () {
		a = itemInfo.ItemIDInfo;
	}

	// Update is called once per frame
	void Update () {
		if(a != itemInfo.ItemIDInfo){
			Destroy (gameObject);
		}
	}
}
