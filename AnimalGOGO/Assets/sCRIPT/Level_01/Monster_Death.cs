using UnityEngine;
using System.Collections;

public class Monster_Death : MonoBehaviour {
	public int health = 10;
	public int Way = 0;
	public float speed = 0.01f;
	public Animator anim;
	public Transform target;
	float delta_x = 0.0f;
	float delta_y = 0.0f;
	// Use this for initialization
	void Start () {
		target = GameObject.FindWithTag ("Player").transform;

	}
	// Update is called once per frame
	void Update () {

		if (health <= 0) {		
			anim.SetBool("attack",false);
			anim.SetBool ("dead", true);
			speed = 0.0f;
			Destroy (gameObject.GetComponent<Collider2D> ());
			gameObject.tag = "Untagged";
			if (this.anim.GetCurrentAnimatorStateInfo (0).IsName ("end")) {
				UniversGod.KillNum += 1;
				playerComputer.killmonster ();
				God_.LevelComplete = true;
				UniversGod.NowLevelNum = 0;
				Destroy (gameObject);
			}
		}	

		if (!UniversGod.GamePause) {
			anim.speed = 1;
			if (this.anim.GetCurrentAnimatorStateInfo (0).IsName ("Down")) {
				if (health <= 0) {
					God_.LevelComplete = true;
					UniversGod.NowLevelNum += 1;
					Destroy (gameObject);
				}
				delta_x = target.position.x - transform.position.x;
				delta_y = target.position.y - transform.position.y;
				if (Mathf.Abs (delta_x) > Mathf.Abs (delta_y)) {
					if (delta_x < 0) {
						Way = 2;
					} else {
						Way = 3;
					}
				} else {
					if (delta_y < 0) {
						Way = 1;
					} else {
						Way = 0;
					}
				}
				Moving ();
			}
		} else {
			anim.speed = 0;	
		}
	}
	void ApplyDamage(int damage){
		health -= damage;
	}
	void Moving(){//自動行走
		switch (Way) {
		case 0://Up
			anim.SetFloat("SpeedX",-0.5f);
			anim.SetFloat("SpeedY",0.5f);
			transform.position += new Vector3 (0.0f, speed, 0.0f);
			break;
		case 1://Down
			anim.SetFloat("SpeedX",-0.5f);
			anim.SetFloat("SpeedY",-0.5f);
			transform.position -= new Vector3 (0.0f, speed, 0.0f);
			break;
		case 2://Left
			anim.SetFloat("SpeedX",-1.0f);
			anim.SetFloat("SpeedY",0.0f);
			transform.position -= new Vector3 (speed, 0.0f, 0.0f);
			break;
		case 3://Right
			anim.SetFloat("SpeedX",0.0f);
			anim.SetFloat("SpeedY",0.0f);
			transform.position += new Vector3 (speed, 0.0f, 0.0f);
			break;
		}
	}
	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Player") {
			col.gameObject.SendMessage("ApplyDamage", 1);
			anim.SetBool("attack",true);
		}
	}
	void OnTriggerExit2D(Collider2D col){
		anim.SetBool("attack",false);
	}
}