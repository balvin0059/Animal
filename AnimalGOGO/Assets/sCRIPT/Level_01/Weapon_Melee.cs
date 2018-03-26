using UnityEngine;
using System.Collections;

public class Weapon_Melee : MonoBehaviour {
	float Timer = 0.0f;
	public Transform target;
	public float targetX;
	public float targetY;
	public Animator anim;
	public GameObject hit;
	// Use this for initialization
	void Start () {
		target = Weapon_Range.tar;
		targetX = target.transform.position.x;
		targetY = target.transform.position.y;
		transform.position = new Vector3(targetX, targetY, 0);
	}
	
	// Update is called once per frame
	void Update () {
		if (Timer > 0.6f) {
			Destroy (gameObject);
		} else {
			Timer += Time.deltaTime;
		}

	}
	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Monster") {
			target = col.gameObject.transform;
			col.gameObject.SendMessage("ApplyDamage", 1);
			if (this.anim.GetCurrentAnimatorStateInfo (0).IsName ("destroy")) {
				Instantiate (hit, new Vector3 (target.position.x, target.position.y-0.1f, 0.0f), Quaternion.identity);
			Destroy (gameObject);
			}
		}
	}
}
