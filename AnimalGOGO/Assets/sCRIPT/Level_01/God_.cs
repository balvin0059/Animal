using UnityEngine;
using System.Collections;

public class God_ : MonoBehaviour {
	static public int level = 0;
	public GameObject stageshow;
	public GameObject[] PlayerCreate;
	public GameObject[] PlayerAttack;
	public GameObject[] Map;
	public int[] MonsterComplete;
	public GameObject LevelMusic;
	public GameObject DropBox;
	public GameObject textShower;
	public GameObject Coin;
	public GameObject Kill;
	static public bool LevelComplete = false;
	bool creat = false;
	bool NextMission = false;
	public Transform target;
	public Sprite[] fghfg;
	public bool startgaming = false; 
	float startalarm = 2.0f;

	public	GameObject[] PrepareCoin;
	bool preparing = false;
	static public bool preparingEnd = false;
	static public bool oknextlevel = false;
	int a = 0;
	// Use this for initialization
	void Start () {
		level = 0;
		LevelComplete = false;
		a = Character.LevelChos;
		Instantiate (LevelMusic, new Vector3 (0.0f, 0.0f, 0.0f), Quaternion.identity);
		Instantiate (DropBox, new Vector3 (0.0f, 0.0f, 0.0f), Quaternion.identity);
		Instantiate (Coin, new Vector3 (0.15f, 0.85f, 0.0f), Quaternion.identity);
		Instantiate (Kill, new Vector3 (0.15f, 0.78f, 0.0f), Quaternion.identity);
		Instantiate (stageshow, new Vector3 (0.0f, 0.0f, 0.0f), Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
		if (preparingEnd) {
			level += 1;
			NextMission = false;
			preparingEnd = false;
			preparing = false;
		}
		if (LevelComplete == true) {
			if (!preparing) {
				nextMissionPrepare ();
				preparing = true;
			}
			if (oknextlevel) {
				Finish ();
			}
		}
		if (NextMission == false) {	completemisson ();	}

		if (level < 1) {
			if (Monster_Spawn.NextLevel <= 0) {
				if (!preparing) {
					nextMissionPrepare ();
					preparing = true;
				}
			}
		}

		if (!startgaming) {
			if (startalarm >= 0.0f) {
				startalarm -= Time.deltaTime;
			} else {
				startgaming = true;
				UniversGod.GamePause = false;
			}
		}
		if (creat == false) {
			switch (a) {
			case 0:
				Instantiate (PlayerCreate [0], new Vector3 (0.0f, 0.0f, 0.0f), Quaternion.identity);
				Instantiate (PlayerAttack [0], new Vector3 (0.0f, 0.0f, 0.0f), Quaternion.identity);
				break;
			case 1:
				Instantiate (PlayerCreate [1], new Vector3 (0.0f, 0.0f, 0.0f), Quaternion.identity);
				Instantiate (PlayerAttack [1], new Vector3 (0.0f, 0.0f, 0.0f), Quaternion.identity);
				break;
			case 2:
				Instantiate (PlayerCreate [2], new Vector3 (0.0f, 0.0f, 0.0f), Quaternion.identity);
				Instantiate (PlayerAttack [2], new Vector3 (0.0f, 0.0f, 0.0f), Quaternion.identity);
				break;
			case 3:
				Instantiate (PlayerCreate [3], new Vector3 (0.0f, 0.0f, 0.0f), Quaternion.identity);
				Instantiate (PlayerAttack [3], new Vector3 (0.0f, 0.0f, 0.0f), Quaternion.identity);
				break;
			case 4:
				Instantiate (PlayerCreate [4], new Vector3 (0.0f, 0.0f, 0.0f), Quaternion.identity);
				Instantiate (PlayerAttack [4], new Vector3 (0.0f, 0.0f, 0.0f), Quaternion.identity);
				break;
			case 5:
				Instantiate (PlayerCreate [5], new Vector3 (0.0f, 0.0f, 0.0f), Quaternion.identity);
				Instantiate (PlayerAttack [5], new Vector3 (0.0f, 0.0f, 0.0f), Quaternion.identity);
				break;
			case 6:
				Instantiate (PlayerCreate [6], new Vector3 (0.0f, 0.0f, 0.0f), Quaternion.identity);
				Instantiate (PlayerAttack [6], new Vector3 (0.0f, 0.0f, 0.0f), Quaternion.identity);
				break;
			case 7:
				Instantiate (PlayerCreate [7], new Vector3 (0.0f, 0.0f, 0.0f), Quaternion.identity);
				Instantiate (PlayerAttack [7], new Vector3 (0.0f, 0.0f, 0.0f), Quaternion.identity);
				break;
			}
		}
		creat = true;
	}
	void nextMissionPrepare(){
		
		levelbar.nextmis = true;
		levelbar.prepare = true;

		int a = Random.Range (0, 3);
		float x = Random.Range (-6.0f, 6.0f); 
		float y = Random.Range (-6.0f, 6.0f);

		for(int i = 0;i < 15;i ++){
			a = Random.Range (0, 3);
			x = Random.Range (-5.0f, 5.0f);
			y = Random.Range (-5.0f, 5.0f);
			Instantiate (PrepareCoin [a], new Vector3 (x, y, 0), Quaternion.identity);
		}
	}
	void Finish(){
		Application.LoadLevel(6);
		level = 0;
		LevelComplete = false;
		levelbar.nextmis = false;
		levelbar.prepare = false;
		preparingEnd = false;
		Destroy(gameObject);
	}
	void completemisson(){
		switch (level) {
		case 0:
			Monster_Spawn.NextLevel = MonsterComplete [level];
			NextMission = true;
			//UniversGod.GamePause = true;
			startgaming = false;
			startalarm = 2.0f;
			levelbar.nextmis = true;

			break;
		case 1:				
			Monster_Spawn.NextLevel = MonsterComplete [level];
			target = GameObject.FindWithTag ("Player").transform;
			target.position = new Vector3 (0.0f, 0.0f, 0.0f);
			NextMission = true;
			//UniversGod.GamePause = true;
			startgaming = false;
			startalarm = 2.0f;
			levelbar.nextmis = true;
			levelbar.Check = true;
			preparingEnd = false;
			break;		
		}
	}
}
