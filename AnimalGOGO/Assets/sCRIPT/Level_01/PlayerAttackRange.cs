using UnityEngine;
using System.Collections;

public class PlayerAttackRange : MonoBehaviour {
	static public int AttackWay = 0;
	public GameObject Attack;
	public GameObject Weapon;
	public Transform target;
	public float AttackSpeed = 1.0f;
	bool shotOK = false;
	public float speed = 3f;
	// Use this for initialization
	void Start () {
		target = GameObject.FindWithTag ("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (!UniversGod.GamePause) {
			if (!UniversGod.Boss_Display) {
				if (!UniversGod.StageShow) {
					transform.position = target.position;
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
}
