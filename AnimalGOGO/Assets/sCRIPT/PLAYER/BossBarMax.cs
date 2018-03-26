using UnityEngine;
using System.Collections;

public class BossBarMax : MonoBehaviour {
	SpriteRenderer sr;
	public Sprite[] Sn;
	public Transform target;
	// Use this for initialization
	void Start () {
		sr = GetComponent<SpriteRenderer>();
		target = GameObject.FindWithTag ("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (God_.LevelComplete) {
			Destroy (gameObject);
		}
		sr.sprite = Sn[UniversGod.NowLevelNum];
		transform.position = new Vector3(target.position.x + 0.2f,target.position.y + 4.4f, 0.0f);
	}
}
