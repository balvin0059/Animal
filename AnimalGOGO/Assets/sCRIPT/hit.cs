using UnityEngine;
using System.Collections;

public class hit : MonoBehaviour {
	public Animator anim;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (this.anim.GetCurrentAnimatorStateInfo (0).IsName ("destroy")) {
			Destroy (gameObject);
				}
	}
}
