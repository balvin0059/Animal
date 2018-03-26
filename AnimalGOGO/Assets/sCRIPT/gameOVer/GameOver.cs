using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {
	SpriteRenderer sr;
	public Sprite GameOverTable;
	// bottom set
	public GUIStyle again;
	public GUIStyle leave;

	public Transform target;

	public float againX;
	public float againY;
	public float leaveX;
	public float leaveY;

	public static bool ggmsc = false;

	void Start(){
		UniversGod.Player_Health = 0;
		GameSL.AutoSave = true;
		sr = GetComponent<SpriteRenderer>();
		ggmsc = true;
	}

	void Update(){
		sr.sprite = GameOverTable;
		if (Input.GetKeyDown(KeyCode.Escape)) {
			GameSL.AutoSave = true;
			Application.Quit(); 
		}
	}
	void OnGUI(){

		// display background
		//display bottom (without GUI outline)
		if (GUI.Button (new Rect (Screen.width * againX, Screen.height * againY, Screen.width * .54f,Screen.height * .06f), "", again)) {
			if (UniversGod.AliveFeather > 0) {
				/*
				target = GameObject.FindWithTag ("Player").transform;
				UniversGod.AliveFeather -= 1;
				UniversGod.Player_Health = 10;
				UniversGod.GamePause = false;
				target.position = new Vector3 (0.0f, 0.0f, 0.0f);
				GameSL.AutoSave = true;
				*/
				UniversGod.Player_HealthMax = 0;
				God_.level = 0;
				God_.LevelComplete = false;
				GameSL.AutoSave = true;
				UniversGod.GamePause = false;
				UniversGod.DestroyGame = true;
				Application.LoadLevel(6);
				ggmsc = false;
				UniversGod.NowMaxHp = 10;
				UniversGod.Player_Health = 10;
				Destroy (gameObject);
			}
		}
		if (GUI.Button (new Rect (Screen.width * leaveX, Screen.height * leaveY, Screen.width * .3f,Screen.height * .06f), "", leave)) {
			UniversGod.Player_HealthMax = 0;
			God_.level = 0;
			God_.LevelComplete = false;
			GameSL.AutoSave = true;
			UniversGod.GamePause = false;
			UniversGod.DestroyGame = true;
			ggmsc = false;
			UniversGod.NowMaxHp = 10;
			UniversGod.Player_Health = 10;
			Application.LoadLevel(2);
		}
	}
}