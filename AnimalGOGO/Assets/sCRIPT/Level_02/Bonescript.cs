using UnityEngine;
using System.Collections;

public class Bonescript : MonoBehaviour {
	float hp = 1.0f;
	float addhp = 3.0f;
	// Use this for initialization
	void Start () {	
	}	
	// Update is called once per frame
	void Update () {	
		if (hp <= 0.0f) {
			Destroy (gameObject);
			Level_02BossAI.boneAlive = false;
			Level_02BossAI.boneDead = true;
		}
	}
	void ApplyDamage(float damage){
		hp -= damage;
	}
	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Monster") {
			col.gameObject.SendMessage("eat_bone", addhp);
			Destroy (gameObject);
		}
	}
}
