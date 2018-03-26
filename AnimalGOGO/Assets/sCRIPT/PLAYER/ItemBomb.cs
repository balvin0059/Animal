using UnityEngine;
using System.Collections;

public class ItemBomb : MonoBehaviour {
	public CircleCollider2D col;
	public Transform target;
	public GameObject[] bomb;
	public Animator anim;
	public AudioClip bom;
	public AudioClip dida;
	AudioSource audio;
	int i = 0;
	bool ied = false;
	bool boming = false;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		col = GetComponent<CircleCollider2D>();
		audio = GetComponent<AudioSource>();
		audio.PlayOneShot (dida, 1.0f);
		col.radius = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (this.anim.GetCurrentAnimatorStateInfo (0).IsName ("end")) {
			Instantiate (bomb[UniversGod.ItemBombLv], new Vector3 (transform.position.x, transform.position.y, 0.0f), Quaternion.identity);
			Destroy (gameObject.GetComponent<Collider2D>());
			Destroy (gameObject);
		}
	}
	void OnTriggerStay2D(Collider2D col2){//碰撞
		if (col2.gameObject.tag == "Monster"||col2.gameObject.tag == "Monster_Clone") {
			target = col2.gameObject.transform;
			Instantiate (bomb[UniversGod.ItemBombLv], new Vector3 (transform.position.x, transform.position.y, 0.0f), Quaternion.identity);
			Destroy (gameObject.GetComponent<Collider2D>());
			Destroy (gameObject);
			col2.gameObject.SendMessage("ApplyDamage", 2);
		}
	}
}
