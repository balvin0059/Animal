using UnityEngine;
using System.Collections;


public class PlayerContrl_party : MonoBehaviour {
	public GameObject[] Partner_AttacK;
	public bool changeway = false; 
	public bool changing = false;
	int a = 0;
	//set
	public float speed = 0.04f;
	public int Way = 0;
	private int MyWay = 0;
	public int Player_Health = 10;

	public Transform target;

	public float delta_x = 0.0f;
	public float delta_y = 0.0f;
	public float RoundX = 0.0f;
	public float RoundY = 0.0f;

	public float MemoryX = 0.0f;
	public float MemoryY = 0.0f;

	public bool OnMoving = false;
	public bool Turn = false;

	public int AID = 0;
	public int Race = 0;
	public float distance = 0.0f;

	public Animator anim;

	void Start () {
		
		target = GameObject.FindWithTag ("Player").transform;
		AID = PlayerControl.Partner_Num;
		Race = PlayerControl.par;
		Way = PlayerControl.PartnerWay;
		Instantiate (Partner_AttacK [Race], transform.position, Quaternion.identity);

	}
	// Update is called once per frame
	void Update () {		
		
		speed = 0.04f;
		if (Player_Health <= 0) {
			anim.SetBool ("dead", true);
			speed = 0.0f;
			Destroy (gameObject.GetComponent<Collider2D>());
			gameObject.tag = "Untagged";
			if (this.anim.GetCurrentAnimatorStateInfo (0).IsName ("end")) {
				Drop.partnerHave [Race] = false;
				PlayerControl.Partner_Num -= 1;
				Destroy (gameObject);
			}
		}
		if (!UniversGod.GamePause) {
			if (!UniversGod.Boss_Display) {
				if (!UniversGod.StageShow) {
					anim.speed = 1;

					MyWay = PlayerControl.PartnerWay;

					MemoryX = (float)System.Math.Round (target.position.x, 2);
					MemoryY = (float)System.Math.Round (target.position.y, 2);
					RoundX = (float)System.Math.Round (transform.position.x, 2);
					RoundY = (float)System.Math.Round (transform.position.y, 2);
					transform.position = new Vector3 (RoundX, RoundY, 0.0f);

					delta_x = (float)System.Math.Abs (MemoryX - RoundX);
					delta_y = (float)System.Math.Abs (MemoryY - RoundY);

					distance = (float)(AID * 0.6f);

					//check way
					if (PlayerControl.cornorTime > 0) {
						changing = true;
					} else if (PlayerControl.cornorTime < 0) {
						PlayerControl.cornorTime = 0;
					}
					if (changing) {
						changeWay ();
					}

					//
					Moving ();
				}else {
					anim.speed = 0;
				}
			}else {
				anim.speed = 0;
			}
		} else {
			anim.speed = 0;
		}
	}

	void Moving(){//自動行走
		switch (Way) {
		case 0://Up
			anim.SetFloat("SpeedX",-0.5f);
			anim.SetFloat("SpeedY",0.5f);
			PlayerAttack_party.AttackWay = 0;
			transform.position += new Vector3 (0.0f, speed, 0.0f);
			break;
		case 1://Down
			anim.SetFloat("SpeedX",-0.5f);
			anim.SetFloat("SpeedY",-0.5f);
			PlayerAttack_party.AttackWay = 1;
			transform.position -= new Vector3 (0.0f, speed, 0.0f);
			break;
		case 2://Left
			anim.SetFloat("SpeedX",-1.0f);
			anim.SetFloat("SpeedY",0.0f);
			PlayerAttack_party.AttackWay = 2;
			transform.position -= new Vector3 (speed, 0.0f, 0.0f);
			break;
		case 3://Right
			anim.SetFloat("SpeedX",0.0f);
			anim.SetFloat("SpeedY",0.0f);
			PlayerAttack_party.AttackWay = 3;
			transform.position += new Vector3 (speed, 0.0f, 0.0f);
			break;
		}
	}

	void OnTriggerEnter2D(Collider2D col){//碰撞
		if (col.gameObject.tag == "Area_Poison") {
			Player_Health -= 1;
		}
		if (col.gameObject.tag == "Wall") {
			Player_Health = 0;
		}
		if (col.gameObject.tag == "Monster") {
			Player_Health -= 1;
		}
		if (col.gameObject.tag == "Player") {
			speed = 0.0f;
		}
	}
	void OnTriggerExit2D(Collider2D col){
		if (col.gameObject.tag == "Player") {
			speed = 0.04f;
		}
	}
	void changeWay (){
		if (!changeway) {			
			for (int i = 0; i < 4; i++) {
				if (PlayerControl.cornor [i]) {
					a = i;
					changeway = true;
					break;
				}
			}
		}
		switch (PlayerControl.cornorWay [a]) {

		case 0:
			if (PlayerControl.cornorWayAfter [a] == 2) {
				if (gameObject.transform.position.x <= PlayerControl.cornorTar [a].position.x) {
					Way = PlayerControl.cornorWay [a];
					PlayerControl.cornor [a] = false;
					PlayerControl.cornorTime -= 1;
					changing = false;
					changeway = false;
					break;
				}
			} else {
				if (gameObject.transform.position.x >= PlayerControl.cornorTar [a].position.x) {
					Way = PlayerControl.cornorWay [a];
					PlayerControl.cornor [a] = false;
					PlayerControl.cornorTime -= 1;
					changing = false;
					changeway = false;
					break;
				}
			}break;
		case 1:
			if (PlayerControl.cornorWayAfter [a] == 2) {
				if (gameObject.transform.position.x <= PlayerControl.cornorTar [a].position.x) {
					Way = PlayerControl.cornorWay [a];
					PlayerControl.cornor [a] = false;
					PlayerControl.cornorTime -= 1;
					changing = false;
					changeway = false;
					break;
				}
			} else {
				if (gameObject.transform.position.x >= PlayerControl.cornorTar [a].position.x) {
					Way = PlayerControl.cornorWay [a];
					PlayerControl.cornor [a] = false;
					PlayerControl.cornorTime -= 1;
					changeway = false;
					break;
				}
			}break;
		case 2:
			if (PlayerControl.cornorWayAfter [a] == 1) {
				if (gameObject.transform.position.y <= PlayerControl.cornorTar [a].position.y) {
					Way = PlayerControl.cornorWay [a];
					PlayerControl.cornor [a] = false;
					PlayerControl.cornorTime -= 1;
					changing = false;
					changeway = false;
					break;
				}
			} else {
				if (gameObject.transform.position.y >= PlayerControl.cornorTar [a].position.y) {
					Way = PlayerControl.cornorWay [a];
					PlayerControl.cornor [a] = false;
					PlayerControl.cornorTime -= 1;
					changing = false;
					changeway = false;
					break;
				}
			}break;
		case 3:
			if (PlayerControl.cornorWayAfter [a] == 1) {
				if (gameObject.transform.position.y <= PlayerControl.cornorTar [a].position.y) {
					Way = PlayerControl.cornorWay [a];
					PlayerControl.cornor [a] = false;
					PlayerControl.cornorTime -= 1;
					changing = false;
					changeway = false;
					break;
				}
			} else {
				if (gameObject.transform.position.y >= PlayerControl.cornorTar [a].position.y) {
					Way = PlayerControl.cornorWay [a];
					PlayerControl.cornor [a] = false;
					PlayerControl.cornorTime -= 1;
					changing = false;
					changeway = false;
					break;
				}
			}break;
		default:
			break;
		}
	}
}
