using UnityEngine;
using System.Collections;

public class PlayerAttack_party : MonoBehaviour {
	static public int AttackWay = 0;
	public GameObject Attack;
	public GameObject Weapon;
	public Transform target;
	public float AttackSpeed = 1.0f;
	bool shotOK = false;
	public float speed = 3f;
	public int Race = 0;
	// Use this for initialization
	void Start () {	
		Race = PlayerControl.par;
		GetMinion (Race);
	}

	// Update is called once per frame
	void Update () {
		if (!UniversGod.GamePause) {
			if (!UniversGod.Boss_Display) {
				if (!UniversGod.StageShow) {
			
					if (!Drop.partnerHave [Race]) {
						Destroy (gameObject);
					}
					if (target == null) {
						GetMinion (PlayerControl.EatPartner);
					} else {
						transform.position = target.position;
					}
					AttackSpeed -= Time.deltaTime;
					if (AttackSpeed <= 0) {
						shotOK = true;
					}
				}
			}
		}
	}
	void OnTriggerStay2D(Collider2D col){
		if (col.gameObject.tag == "Monster"||col.gameObject.tag == "Monster_Clone") {
			if (Weapon.tag == "Weapon") {
				Weapon_Range.tar = col.gameObject.transform;
			}
			if (shotOK == true) {
				switch (AttackWay) {
				case 0:
					Instantiate (Weapon, new Vector3 (transform.position.x, transform.position.y + 0.8f, 0.0f), transform.rotation);
					break;
				case 1:
					Instantiate (Weapon, new Vector3 (transform.position.x, transform.position.y - 0.8f, 0.0f), transform.rotation);
					break;
				case 2:
					Instantiate (Weapon, new Vector3 (transform.position.x - 0.8f, transform.position.y, 0.0f), transform.rotation);
					break;
				case 3:
					Instantiate (Weapon, new Vector3 (transform.position.x + 0.8f, transform.position.y, 0.0f), transform.rotation);
					break;
				}
				shotOK = false;
				AttackSpeed = 1.0f;
			}
		}
	}
	void GetMinion(int Num){
		switch (Num) {
		case 0:
			if (GameObject.FindWithTag ("partner_mouse") == null) {
				Destroy (gameObject);
			}
			target = GameObject.FindWithTag ("partner_mouse").transform;
			break;
		case 1:
			if (GameObject.FindWithTag ("partner_ox") == null) {
				Destroy (gameObject);
			}
			target = GameObject.FindWithTag ("partner_ox").transform;
			break;
		case 2:
			if (GameObject.FindWithTag ("partner_tiger") == null) {
				Destroy (gameObject);
			}
			target = GameObject.FindWithTag ("partner_tiger").transform;
			break;
		case 3:
			if (GameObject.FindWithTag ("partner_dragon") == null) {
				Destroy (gameObject);
			}
			target = GameObject.FindWithTag ("partner_dragon").transform;
			break;
		case 4:
			if (GameObject.FindWithTag ("partner_snake") == null) {
				Destroy (gameObject);
			}
			target = GameObject.FindWithTag ("partner_snake").transform;
			break;
		case 5:
			if (GameObject.FindWithTag ("partner_cock") == null) {
				Destroy (gameObject);
			}
			target = GameObject.FindWithTag ("partner_cock").transform;
			break;
		case 6:	
			if (GameObject.FindWithTag ("partner_dog") == null) {
				Destroy (gameObject);
			}
			target = GameObject.FindWithTag ("partner_dog").transform;
			break;
		case 7:	
			if (GameObject.FindWithTag ("partner_pig") == null) {
				Destroy (gameObject);
			}
			target = GameObject.FindWithTag ("partner_pig").transform;
			break;
		}
	}
}
