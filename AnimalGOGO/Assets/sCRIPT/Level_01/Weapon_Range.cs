using UnityEngine;
using System.Collections;

public class Weapon_Range : MonoBehaviour {
	public float angleBetween = 0.0F;
	public Transform target;
	public float targetX;
	public float targetY;
	public float speed = 0.05f;
	//public new Vector3 a;
	//public new Vector3 direction;
	public float dir;
	public float time;
	// Use this for initialization
	public Animator anim;
	public GameObject hit;
	public static Transform tar;


	void Start () {
		target = tar;
		gameObject.tag = "Untagged";
		Quaternion rot = transform.rotation;
		dir = Vector3.Angle (transform.position, tar.position);
		rot = Quaternion.Euler (0, 0, dir);
		transform.rotation = rot;

	}
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		/*if (!target) {
			Destroy (gameObject);
			return;
		}*/
		if (!UniversGod.GamePause) {
			if (!UniversGod.Boss_Display) {
				if (!UniversGod.StageShow) {
					anim.speed = 1;
					if (time >= 2) {
						Destroy (gameObject);
					}
					if (transform.position == target.position) {
						Destroy (gameObject);
					} else {
						float step = speed * Time.deltaTime;
						transform.position = Vector3.MoveTowards (transform.position, target.position, step);
					}
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
	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Monster"||col.gameObject.tag == "Monster_Clone") {
			target = col.gameObject.transform;
			Instantiate (hit, new Vector3 (target.position.x, target.position.y-0.1f, 0.0f), Quaternion.identity);
			Destroy (gameObject);
			col.gameObject.SendMessage("ApplyDamage", UniversGod.Player_AttackDmg);
		}
		if (col.gameObject.tag == "Wall") {
			Destroy (gameObject);
		}
	}

}
