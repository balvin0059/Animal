using UnityEngine;
using System.Collections;

public class Item_Script : MonoBehaviour {
	public int itemID;
	float alarm;
	public Transform target;
	public GameObject[] ItemCoin;
	public float speed = 1.8f;
	public float step = 0;
	// Use this for initialization
	void Start () {
		target = GameObject.FindWithTag ("Player").transform;
		itemID = Drop.GetitemID (gameObject);
		if (itemID >= 14) {
			Destroy (gameObject);
		}
	}

	// Update is called once per frame
	void Update () {

		if (!UniversGod.GamePause) {
			if (!UniversGod.Boss_Display) {
				if (!UniversGod.StageShow) {
					alarm += Time.deltaTime;
					if (alarm > 8.0f) {
						Destroy (gameObject);
					}
					if (UniversGod.ItemContrl_Magnet) {
						step = speed * Time.deltaTime;
						transform.position = Vector3.MoveTowards (transform.position, target.position, step);
					}
				}
			}
		}


	}

	void OnTriggerEnter2D(Collider2D col){

		if (col.gameObject.tag == "Player") {
			if (itemID == 3) {
				BoxCreat ();
				Destroy (gameObject);
			}
			col.gameObject.SendMessage("GetItemID", itemID);
			Destroy (gameObject);
		}
	}
	void BoxCreat (){
		float r_3 = Random.Range (-4.85f, 4.85f);
		float r_4 = Random.Range (-4.85f, 4.85f);
		Instantiate (ItemCoin [2], new Vector3 (r_3, r_4, 0.0f), Quaternion.identity);
		r_3 = Random.Range (-4.85f, 4.85f);
		r_4 = Random.Range (-4.85f, 4.85f);
		Instantiate (ItemCoin [1], new Vector3 (r_3, r_4, 0.0f), Quaternion.identity);
		r_3 = Random.Range (-4.85f, 4.85f);
		r_4 = Random.Range (-4.85f, 4.85f);
		Instantiate (ItemCoin [0], new Vector3 (r_3, r_4, 0.0f), Quaternion.identity);
		r_3 = Random.Range (-4.85f, 4.85f);
		r_4 = Random.Range (-4.85f, 4.85f);
		Instantiate (ItemCoin [2], new Vector3 (r_3, r_4, 0.0f), Quaternion.identity);
		r_3 = Random.Range (-4.85f, 4.85f);
		r_4 = Random.Range (-4.85f, 4.85f);
		Instantiate (ItemCoin [1], new Vector3 (r_3, r_4, 0.0f), Quaternion.identity);
		r_3 = Random.Range (-4.85f, 4.85f);
		r_4 = Random.Range (-4.85f, 4.85f);
		Instantiate (ItemCoin [0], new Vector3 (r_3, r_4, 0.0f), Quaternion.identity);
	}
}
