using UnityEngine;
using System.Collections;

public class DisplayModel : MonoBehaviour {
	int a = 0;
	// Use this for initialization
	void Start () {
		a = CHARInfo.InfoNum;
	}
	
	// Update is called once per frame
	void Update () {
		if(a != CHARInfo.InfoNum){
			Destroy (gameObject);
		}
	}
}
