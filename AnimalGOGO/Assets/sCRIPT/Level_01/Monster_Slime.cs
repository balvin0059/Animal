using UnityEngine;
using System.Collections;

public class Monster_Slime : MonoBehaviour {
	public float health = 1.0f;
	public int Way = 0;
	public float speed = 0.02f;
	public Animator anim;
	public Transform target;
	public int monster_dmg = 0;
	float delta_x = 0.0f;
	float delta_y = 0.0f;
	// Use this for initialization
	void Awake () {
		target = GameObject.FindWithTag ("Player").transform;
		if (gameObject.tag == "Monster_Clone") {
			Monster_SlimeKing.BossInvincible += 1;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (God_.level < 1 && Monster_Spawn.NextLevel <= 0) {
			Destroy (gameObject);
			if (gameObject.tag == "Monster_Clone") {
				if (Monster_SlimeKing.BossInvincible > 0) {
					Monster_SlimeKing.BossInvincible -= 1;
				} else {
					Monster_SlimeKing.BossInvincible = 0;
				}
			}

		}
			if (health <= 0.0f) {
				anim.SetBool ("dead", true);
				speed = 0.0f;
				Destroy (gameObject.GetComponent<Collider2D>());
				gameObject.tag = "Untagged";				
				if (this.anim.GetCurrentAnimatorStateInfo (0).IsName ("destroy")) {
					Monster_Spawn.maxNum += 1;
					if (God_.level != 1) {
						Monster_Spawn.NextLevel -= 1;
					}
					UniversGod.KillNum += 1;
					playerComputer.killmonster ();
					Drop.monsterDead (gameObject);
					Destroy (gameObject);
				if (gameObject.tag == "Monster_Clone") {
					if (Monster_SlimeKing.BossInvincible > 0) {
						Monster_SlimeKing.BossInvincible -= 1;
					} else {
						Monster_SlimeKing.BossInvincible = 0;
					}
				}
				}
			}
		if (!UniversGod.GamePause) {
			if (!UniversGod.StageShow) {
				if (!UniversGod.TimeStopActive) {
					anim.speed = 1;
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
				}else {
					anim.speed = 0;
				}
			} else {
				anim.speed = 0;
			}
		} else {
			anim.speed = 0;
		}
	}
	void ApplyDamage(float damage){
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
	void OnTriggerEnter2D(Collider2D col){//碰撞
		if (col.gameObject.tag == "Player") {
			col.gameObject.SendMessage("ApplyDamage", monster_dmg);
		}
	}
}
