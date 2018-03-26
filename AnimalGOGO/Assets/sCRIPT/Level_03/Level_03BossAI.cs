using UnityEngine;
using System.Collections;

public class Level_03BossAI : MonoBehaviour {
	public GameObject[] Fire;

	static public float Boss03_health = 50.0f;
	public int Way = 0;
	public int BeforeWay = 0;
	public float speed = 0.01f;
	public Animator anim;
	public Transform target;
	public float delta_x = 0.0f;
	public float delta_y = 0.0f;

	bool Walking = false;
	bool OneWay = false;
	public float Rx = 0.0f;
	public float Ry = 0.0f;
	public float tarX = 0.0f;
	public float tarY = 0.0f;
	public int attackWay = 0;

	float ait = 0.8f;
	float attacking = 1.0f;
	bool battacking = false;
	bool passthrough = false;
	// Use this for initialization
	void Start () {

		gameObject.tag = "Untagged";
		target = GameObject.FindWithTag ("Player").transform;

	}
	// Update is called once per frame
	void Update () {		
		//getdir ();
		//Debug.Log (dir);
		//boss dead
		if (Boss03_health <= 0.0f) {
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
		//boss active
		if (!UniversGod.GamePause) {

			if (battacking) {
				attacking -= Time.deltaTime;
				if (attacking <= 0.0f) {
					battacking = false;
					attacking = 1.0f;
				}
			}
			anim.speed = 1;

			if (this.anim.GetCurrentAnimatorStateInfo (0).IsName ("Down")) {
				if (gameObject.tag == "Untagged") {
					gameObject.tag = "Monster";
					UniversGod.Boss_Display = false;
				}
				RandomWalk ();
				Moving ();
			}
			if (this.anim.GetCurrentAnimatorStateInfo (0).IsName ("Attack")) {
				ait -= Time.deltaTime;
				if (ait <= 0) {	
					getdir (0);
					AttackActive ();
					ait = 0.8f;
				}
			}
		} else {
			anim.speed = 0;
		}
	}
	void ApplyDamage(float damage){
			Boss03_health -= damage;
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
	//////////////////////////////////////////////////
	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Wall") {
			WallAndChangeWay (1);
		}
		if (col.gameObject.tag == "Player") {
			getdir (0);
			if (!passthrough) {
				//col.gameObject.SendMessage ("ApplyDamage", 2);
				anim.SetBool ("attack", true);
				passthrough = true;
			}
		}
	}
	void OnTriggerExit2D(Collider2D col){
		if (col.gameObject.tag == "Wall") {
			WallAndChangeWay (1);
		}
		if (col.gameObject.tag == "Player") {
			passthrough = false;
			anim.SetBool("attack",false);
			Way = BeforeWay;
		}
	}
	void OnTriggerStay2D(Collider2D col){
		if (col.gameObject.tag == "Wall") {
			WallAndChangeWay (1);
		}
		if (col.gameObject.tag == "Player") {
			anim.SetBool("attack",true);
		}
	}
	//////////////////////////////////////////////////
	void RandomWalk(){
		if (Mathf.Abs (delta_x) < 0.3f && Mathf.Abs (delta_y) < 0.3f ) {
			Walking = false;
		}
		if (!Walking) {
			Rx = Random.Range (-5.0f, 5.0f);
			Ry = Random.Range (-5.0f, 5.0f);
			Walking = true;
		}
		delta_x = Rx - transform.position.x;
		delta_y = Ry - transform.position.y;
		if (Mathf.Abs (delta_x) < 0.3f || Mathf.Abs (delta_y) < 0.3f) {
			OneWay = false;
		}
		if (!OneWay) {
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
			OneWay = true;
		}
	}
	void getdir(int a){	
		target = GameObject.FindWithTag ("Player").transform;
		BeforeWay = Way;
		tarX = target.position.x - transform.position.x;
		tarY = target.position.y - transform.position.y;
		if (Mathf.Abs (tarX) > Mathf.Abs (tarY)) {
			if (tarX < 0) {				
				attackWay = 2;
				Way = 2;
			} else {
				attackWay = 3;
				Way = 3;
			}
		} else {
			if (tarY < 0) {
				attackWay = 1;
				Way = 1;
			} else {
				attackWay = 0;
				Way = 0;
			}
		}
		anim.SetBool("attack",true);
	}
	void AttackActive(){
		if (!battacking) {
			switch (attackWay) {
			case 0:
				Instantiate (Fire [attackWay], new Vector3 (transform.position.x, transform.position.y + 2.5f, 0.0f), Quaternion.identity);
				break;
			case 1:
				Instantiate (Fire [attackWay], new Vector3 (transform.position.x, transform.position.y - 2.5f, 0.0f), Quaternion.identity);
				break;
			case 2:
				Instantiate (Fire [attackWay], new Vector3 (transform.position.x - 2.5f, transform.position.y, 0.0f), Quaternion.identity);
				break;
			case 3:
				Instantiate (Fire [attackWay], new Vector3 (transform.position.x + 2.5f, transform.position.y, 0.0f), Quaternion.identity);
				break;
			}
			battacking = true;
		}
		anim.SetBool("attack",false);
	}
	void WallAndChangeWay(int b){
		delta_x = 0.0f;
		delta_y = 0.0f;
		Walking = false;
		OneWay = false;
	}
}