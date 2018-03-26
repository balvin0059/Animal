using UnityEngine;
using System.Collections;

public class Monster_SlimeKing : MonoBehaviour {
	public GameObject[] minion;

	static public int BossInvincible = 0;
	public int BeAttackedTime = 0;
	public int RandomA = 0;

	static public float Boss01_health = 10.0f;
	public int Way = 0;
	public float speed = 0.01f;
	public Animator anim;
	public float SkillCD = 0.0f;
	public float delta_x = 0.0f;
	public float delta_y = 0.0f;

	public bool cooldown = false;
	public int cd = 0;
	public float cdt = 5.0f;

	bool Walking = false;
	bool OneWay = false;
	public float Rx = 0.0f;
	public float Ry = 0.0f;
	bool passthrough = false;

	public bool FirstTimeSummon = false;
	public int cdmax = 0;

	public bool hitwal = false;
	// Use this for initialization
	void Start () {
		
		gameObject.tag = "Untagged";
		cdmax = Random.Range (2, 5);

	}
	// Update is called once per frame
	void Update () {
		Debug.Log (BossInvincible);
		//boss dead
		if (Boss01_health <= 0.0f) {
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
		//boss active
		if (!UniversGod.GamePause) {
			
			anim.speed = 1;

			if (this.anim.GetCurrentAnimatorStateInfo (0).IsName ("kingslime")) {
				if (gameObject.tag == "Untagged") {
					gameObject.tag = "Monster";
					UniversGod.Boss_Display = false;
				}
				//skill timing

				if(cd == cdmax){
					if (!FirstTimeSummon) {
						cooldown = true;
						cdt -= Time.deltaTime;
						if (cdt <= 0) {
							FirstTimeSummon = true;
						}
					} else {
						cooldown = true;
					}
				}

				if (!cooldown) {
					if (SkillCD > 0.0f) {
						SkillCD -= Time.deltaTime;
					} else {
						SkillCD = 0.0f;
					}
					if (SkillCD <= 0.0f) {
							Skill ();
							cd += 1;
					}
				}

				RandomWalk ();
				Moving ();

			} else {
				anim.SetBool("attack",false);
			}
		} else {
			anim.speed = 0;
		}
	}
	void ApplyDamage(float damage){
		Boss01_health -= damage;
		RandomA = Random.Range (0, 100);
		if (BeAttackedTime < 3) {
			BeAttackedTime += 1;
		}
		if (BossInvincible <= 0) {
			Boss01_health -= damage;
		}
		if (BossInvincible <= 2) {
			if (BeAttackedTime * 10 < RandomA) {
				cd = 0;
				cdmax = Random.Range (2, 5);
				cooldown = false;
				cdt = 5.0f;
			}
		}
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
		hitwal = true;
		if (col.gameObject.tag == "Wall") {
			WallAndChangeWay (1);
			hitwal = true;
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
		anim.SetBool("attack",false);
		passthrough = false;
		if (col.gameObject.tag == "Wall") {
			hitwal = false;
		}
	}

	void Skill(){		

		int a = Random.Range (0, minion.Length);
		float px = Random.Range (transform.position.x-2.0f, transform.position.x+2.0f); 
		float py = Random.Range (transform.position.y-2.0f, transform.position.y+2.0f);
		Instantiate (minion[a], new Vector3 (px, py, 0), Quaternion.identity);
		//a = Random.Range (0, minion.Length);
		//py = Random.Range (transform.position.y-2.0f, transform.position.y+2.0f);
		//px = Random.Range (transform.position.x-2.0f, transform.position.x+2.0f); 
		//Instantiate (minion[a], new Vector3 (px, py, 0), Quaternion.identity);
		anim.SetBool("attack",true);
		SkillCD = 1.0f;

	}

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
	void WallAndChangeWay(int b){
		delta_x = 0.0f;
		delta_y = 0.0f;
		Walking = false;
		OneWay = false;
	}
}