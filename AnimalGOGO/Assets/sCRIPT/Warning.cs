using UnityEngine;
using System.Collections;

public class Warning : MonoBehaviour {
	//public Transform target;
	public Animator anim;
	public GameObject[] boss;
	int animtime;
	bool animing = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (this.anim.GetCurrentAnimatorStateInfo (0).IsName ("loop3")) {
			if (!animing) {
				animtime += 1;
				anim.SetInteger ("war3", animtime);
			}
			animing = true;
		} else {
			animing = false;
		}
		if (this.anim.GetCurrentAnimatorStateInfo (0).IsName ("end")) {
			Instantiate (boss[UniversGod.NowLevelNum], new Vector3 (0, 3, 0), Quaternion.identity);
			Destroy (gameObject);
		}
	}
}
