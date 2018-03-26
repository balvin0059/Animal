using UnityEngine;
using System.Collections;

public class stageone : MonoBehaviour {
	public Animator anim;
	// Use this for initialization
	void Start () {
		UniversGod.StageShow = true;
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (this.anim.GetCurrentAnimatorStateInfo (0).IsName ("end")) {
			UniversGod.StageShow = false;
			Destroy (gameObject);
		}
	}
}
