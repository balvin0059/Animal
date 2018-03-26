using UnityEngine;
using System.Collections;

public class deathfire : MonoBehaviour {
	public int dmg = 1;
	public Animator anim;
	bool atkit = false;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}	
	// Update is called once per frame
	void Update () {	
		if (this.anim.GetCurrentAnimatorStateInfo (0).IsName ("end")) {
			Destroy (gameObject);
		}
	}
	void OnTriggerEnter2D(Collider2D col){//碰撞
		if (col.gameObject.tag == "Player") {
			if (!atkit) {
				col.gameObject.SendMessage("ApplyDamage", dmg);
				atkit = true;
			}				
			if (this.anim.GetCurrentAnimatorStateInfo (0).IsName ("end")) {				
				Destroy (gameObject);
			}
		}
	}
	void OnTriggerStay2D(Collider2D col){//碰撞
		if (col.gameObject.tag == "Player") {		
			if (!atkit) {
				col.gameObject.SendMessage("ApplyDamage", dmg);
				atkit = true;
			}		
			if (this.anim.GetCurrentAnimatorStateInfo (0).IsName ("end")) {
				Destroy (gameObject);
			}
		}
	}
}
