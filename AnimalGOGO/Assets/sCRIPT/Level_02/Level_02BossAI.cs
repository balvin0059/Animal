using UnityEngine;
using System.Collections;

public class Level_02BossAI : MonoBehaviour {
	public GameObject Knife;
	public GameObject Bone;
	static public float Boss02_health = 40.0f;
	public int Way = 0;
	public int BeforeWay = 0;
	public float speed = 0.03f;
	public Animator anim;
	public Transform target;
	public float delta_x = 0.0f;
	public float delta_y = 0.0f;

	public bool attacking;

	public int Boss_state = 0;

	bool Walking = false;
	bool OneWay = false;
	public float Rx = 0.0f;
	public float Ry = 0.0f;
	public float tarX = 0.0f;
	public float tarY = 0.0f;

	static public bool boneAlive = false;
	static public bool boneDead = false;

	float brx = 0.0f;
	float bry = 0.0f;
	public float bdcd = 10.0f;

	public bool attackspeed = false;
	float aspd = 3.0f;
	float ait = 1.5f;
	bool battacking = false;

	bool passthrough = false;
	float reset_Soul = 10.0f;
	void Start () {

		gameObject.tag = "Untagged";
		target = GameObject.FindWithTag ("Player").transform;

	}

	void Update () {
		///////////////////////boss dead///////////////////////
		if (Boss02_health <= 0.0f) {
			anim.SetBool("attack",false);
			anim.SetBool ("dead", true);
			speed = 0.0f;
			Destroy (gameObject.GetComponent<Collider2D> ());
			gameObject.tag = "Untagged";
			if (this.anim.GetCurrentAnimatorStateInfo (0).IsName ("end")) {
				UniversGod.KillNum += 1;
				playerComputer.killmonster ();
				God_.LevelComplete = true;
				UniversGod.NowLevelNum += 1;
				Destroy (gameObject);
			}
		}

		if (!UniversGod.GamePause) {			
			///////////////////////////////////////////////////////
			if (boneDead) {
				if (bdcd <= 0) {
					boneDead = false;
					bdcd = 10.0f;
				} else {
					bdcd -= Time.deltaTime;
				}
			}
			if (Boss02_health <= 20.0f) {
				if (!boneAlive) {
					if (!boneDead) {
						brx = Random.Range (-5.0f, 5.0f);
						bry = Random.Range (-5.0f, 5.0f);
						Boss_state = 1;
						Instantiate (Bone, new Vector3 (brx, bry, 0.0f), Quaternion.identity);
						boneAlive = true;
					}
				}
			} else {
				if (boneAlive) {
					Boss_state = 0;
					boneAlive = false;
				}
			}
			///////////////////////reset///////////////////////
			if (battacking) {
				aspd -= Time.deltaTime;
				if (aspd <= 0.0f) {
					battacking = false;
					aspd = 1.5f;
				}
			}
			///////////////////////boss state1///////////////////////
			anim.speed = 1;
			switch (Boss_state) {
			case 0://狀態一
				state_01();
				break;
			case 1://狀態二
				state_02();
				break;
			}
			////////////////////////////////////////////////////////
		} else {
			anim.speed = 0;
		}

	}
	void ApplyDamage(float damage){
		Boss02_health -= damage;
	}
	////////////////觸碰碰撞/////////////////////
	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Wall") {
			WallAndChangeWay (1);
		}
		if (col.gameObject.tag == "Player") {
			if (!passthrough) {
				col.gameObject.SendMessage ("ApplyDamage", 2);
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
	////////////////自動行走函示/////////////////////
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
	////////////////攻擊函示/////////////////////
	void AttackActive(){
		if (!battacking) {			
			Instantiate (Knife, new Vector3 (transform.position.x, transform.position.y, 0.0f), Quaternion.identity);
			battacking = true;
		}
		anim.SetBool ("attack", false);
	}
	////////////////行走函式/////////////////////
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

	/////////////////state_02////////////////////休憩模式
	void state_02(){
		if (this.anim.GetCurrentAnimatorStateInfo (0).IsName ("knightappear")) {
			if (gameObject.tag == "Untagged") {
				gameObject.tag = "Monster";
				UniversGod.Boss_Display = false;
			}
			RandomWalk ();
			Moving ();
		}
		if (this.anim.GetCurrentAnimatorStateInfo (0).IsName ("attack")) {
			ait -= Time.deltaTime;
			if (ait <= 0) {	
				AttackActive ();
				ait = 1.2f;
			}
		}
	}
	//////////////////state_01///////////////////追擊模式
	void state_01(){
		if (this.anim.GetCurrentAnimatorStateInfo (0).IsName ("knightappear")) {
			if (gameObject.tag == "Untagged") {
				gameObject.tag = "Monster";
				UniversGod.Boss_Display = false;
			}
			tarX = target.position.x - transform.position.x;
			tarY = target.position.y - transform.position.y;
			if (Mathf.Abs (tarX) > Mathf.Abs (tarY)) {
				if (tarX < 0) {
					Way = 2;
				} else {
					Way = 3;
				}
			} else {
				if (tarY < 0) {
					Way = 1;
				} else {
					Way = 0;
				}
			}
			Moving ();
		}
		if (this.anim.GetCurrentAnimatorStateInfo (0).IsName ("attack")) {	
			ait -= Time.deltaTime;
			if (ait <= 0) {	
				AttackActive ();
				ait = 1.2f;
			}
		}
	}
	/////////////////state_02////////////////////休憩模式
	/////////////////取得骨頭////////////////////
	void eat_bone(float i){
		
		Boss02_health += i;	

	}
	//get messesge
	void getattackmessge(int i){
		if (i == 0) {
			anim.SetBool ("attack", true);
		} else if (i == 1) {
			anim.SetBool ("attack", false);
		}
	}
	/////////////////////////////////////////////////
	void WallAndChangeWay(int b){
		delta_x = 0.0f;
		delta_y = 0.0f;
		Walking = false;
		OneWay = false;
	}
}