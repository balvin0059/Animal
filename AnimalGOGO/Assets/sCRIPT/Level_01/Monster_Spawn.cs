using UnityEngine;
using System.Collections;

public class Monster_Spawn : MonoBehaviour {
	public	GameObject[] Monster;
	public GameObject boss;
	public GameObject BossHPBar;
	public float time =0.0f;
	public int legth;
	public float alarm = 2.0f;
	static public int maxNum = 5;
	public Transform target;
	static public int NextLevel = 10;
	bool BossAlive = false;

	// Use this for initialization
	void Start () {
		
		Invoke ("SpawnMonster", 1);
		Invoke ("SpawnMonster", 1);
		Invoke ("SpawnMonster", 1);

	}
	
	// Update is called once per frame
	void Update () {
		if (!UniversGod.GamePause) {
			if (!UniversGod.Boss_Display) {
				if (!UniversGod.StageShow) {
					if (!God_.LevelComplete) {
						if (God_.level == 1) {
							if (BossAlive == false) {
								SpawnBoss ();
								BossAlive = true;
								Instantiate (BossHPBar, new Vector3 (0, 0, 0), Quaternion.identity);
							}
						} else {
							alarm -= Time.deltaTime;
							if (alarm <= 0) {
								if (maxNum >= 0) {
									Invoke ("SpawnMonster", 0);
									Invoke ("SpawnMonster", 0);
									alarm = 2.0f;
								}
							}
						}
					}
				}
			}
		}


	}
	void SpawnMonster(){
		target = GameObject.FindWithTag ("Player").transform;

		int a = Random.Range (0, Monster.Length);
		float x = Random.Range (-5.0f, 5.0f); 
		float y = Random.Range (-5.0f, 5.0f);

		Instantiate (Monster [a], new Vector3 (x, y, 0), Quaternion.identity);
		maxNum -= 1;
	}
	void SpawnBoss(){
		target = GameObject.FindWithTag ("Player").transform;
		Instantiate (boss, new Vector3 (0, 0, 0), Quaternion.identity);
		UniversGod.Boss_Display = true;
	}
}
