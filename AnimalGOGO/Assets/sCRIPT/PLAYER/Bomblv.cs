using UnityEngine;
using System.Collections;

public class Bomblv : MonoBehaviour {
	public Transform target;
	public GameObject hit;
	public Animator anim;
	public AudioClip bom;
	AudioSource audio;
	int i = 0;
	bool ied = false;
	bool boming = false;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		audio = GetComponent<AudioSource>();
		audio.PlayOneShot (bom, 1.0f);
	}
	
	// Update is called once per frame
	void Update () {
		if (this.anim.GetCurrentAnimatorStateInfo (0).IsName ("end")) {
			Destroy (gameObject.GetComponent<Collider2D>());
			Destroy (gameObject);
		}
	}
	void OnTriggerStay2D(Collider2D col2){//碰撞
		if (col2.gameObject.tag == "Monster"||col2.gameObject.tag == "Monster_Clone") {
			target = col2.gameObject.transform;
			Instantiate (hit, new Vector3 (target.position.x, target.position.y-0.1f, 0.0f), Quaternion.identity);
			col2.gameObject.SendMessage("ApplyDamage", 2);
		}
	}
}
