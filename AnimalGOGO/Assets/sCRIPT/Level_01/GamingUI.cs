using UnityEngine;
using System.Collections;

public class GamingUI : MonoBehaviour {
	public GameObject bomb;
	// bottom set
	public GUIStyle LiveButtom;
	public bool bLiveButtom = true;
	public bool cLiveButtom = false;
	public float LiveButtomX;
	public float LiveButtomY;
	public GUIStyle Bomb;
	public bool bBomb = true;
	public bool cBomb = false;
	public float BombX;
	public float BombY;
	public GUIStyle SuperStar;
	public bool bSuperStar = true;
	public bool cSuperStar = false;
	public float SuperStarX;
	public float SuperStarY;
	public GUIStyle TimeStop;
	public bool bTimeStop = true;
	public bool cTimeStop = false;
	public float TimeStopX;
	public float TimeStopY;
	public GUIStyle pause;
	public GUIStyle pause2;
	public bool bpause = true;
	public bool cpause = false;
	public float pauseX;
	public float pauseY;

	public AudioClip drink;
	AudioSource audio;
	//public GameObject bgbk;
	void Start(){
		audio = GetComponent<AudioSource>();
	}
	void Update(){




		if (UniversGod.ItemLiveButtom > 0) {	cLiveButtom = true;	} else {	cLiveButtom = false;	}
		if (UniversGod.ItemBomb > 0) {	cBomb = true;	} else {	cBomb = false;	}
		if (UniversGod.ItemSuperStar > 0) {	cSuperStar = true;	} else {	cSuperStar = false;	}
		if (UniversGod.ItemTimeStop > 0) {	cTimeStop = true;	} else {	cTimeStop = false;	}


		if (Input.GetKeyDown(KeyCode.Escape)) {
			Application.Quit(); 
		}
	}
	void OnGUI(){		
		//
		if (!cLiveButtom) {
			if (GUI.Toggle (new Rect (Screen.width * LiveButtomX, Screen.height * LiveButtomY, Screen.width * 0.16f, Screen.height * 0.095f),bLiveButtom, "", LiveButtom)) {
			}
		} else {
			if (GUI.Button (new Rect (Screen.width * LiveButtomX, Screen.height * LiveButtomY, Screen.width * 0.16f, Screen.height * 0.095f), "", LiveButtom)) {	
				if (UniversGod.Player_Health+UniversGod.ItemLiveButtomLv+1 < UniversGod.NowMaxHp) {
					audio.PlayOneShot (drink, 1.0f);
					UniversGod.Player_Health += 1 + UniversGod.ItemLiveButtomLv;
					UniversGod.ItemLiveButtom -= 1;
				} else {
					UniversGod.Player_Health = UniversGod.NowMaxHp;
					UniversGod.ItemLiveButtom -= 1;
				}

			}
		}
		//
		if (!cBomb) {
			if (GUI.Toggle (new Rect (Screen.width * BombX, Screen.height * BombY, Screen.width * 0.16f, Screen.height * 0.095f), bBomb, "", Bomb)) {
			}
		} else {
			if (GUI.Button (new Rect (Screen.width * BombX, Screen.height * BombY, Screen.width * 0.16f, Screen.height * 0.095f), "", Bomb)) {
				Instantiate (bomb, new Vector3 (transform.position.x, transform.position.y, 0.0f), Quaternion.identity);
				UniversGod.ItemBomb -= 1;

			}
		}
		//
		if (!cSuperStar) {
			if (GUI.Toggle (new Rect (Screen.width * SuperStarX, Screen.height * SuperStarY, Screen.width * 0.16f, Screen.height * 0.095f), bSuperStar, "", SuperStar)) {
			}
		} else {
			if (GUI.Button (new Rect (Screen.width * SuperStarX, Screen.height * SuperStarY, Screen.width * 0.16f, Screen.height * 0.095f), "", SuperStar)) {
				if (!UniversGod.SuperStarActive) {
					UniversGod.SuperStarActive = true;
					UniversGod.SuperStarEvent ();
					UniversGod.ItemSuperStar -= 1;
				}
			}
		}
		//
		if (!cTimeStop) {
			if (GUI.Toggle (new Rect (Screen.width * TimeStopX, Screen.height * TimeStopY, Screen.width * 0.16f, Screen.height * 0.095f), bTimeStop, "", TimeStop)) {
			}
		} else {
			if (GUI.Button (new Rect (Screen.width * TimeStopX, Screen.height * TimeStopY, Screen.width * 0.16f, Screen.height * 0.095f), "", TimeStop)) {
				if (!UniversGod.TimeStopActive) {
					UniversGod.TimeStopActive = true;
					UniversGod.TimeStopEvent ();
					UniversGod.ItemTimeStop -= 1;
				}
			}
		}
		//
		if (!cpause) {
			if (GUI.Button (new Rect (Screen.width * pauseX, Screen.height * pauseY, Screen.width * 0.16f, Screen.height * 0.095f), "", pause)) {					
					UniversGod.GamePause = true;					
					cpause = true;
			}
		} else {
			if (GUI.Button (new Rect (Screen.width * pauseX, Screen.height * pauseY, Screen.width * 0.16f, Screen.height * 0.095f), "", pause2)) {
					UniversGod.GamePause = false;
					cpause = false;
			}
		}
	}
}
