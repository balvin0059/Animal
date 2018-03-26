using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {
	public GameObject[] DisplayPartner;
	public GameObject[] PlayerShower;
	//word
	public GameObject[] Caption_ChooseLeader;
	// bottom set
	public GUIStyle ChangeL;
	public GUIStyle ChangeR;
	public GUIStyle Play;
	public GUIStyle Back;
	public GUIStyle PlayerState;

	
	public float ChangeLX;
	public float ChangeLY;
	public float ChangeRX;
	public float ChangeRY;
	public float PlayX;
	public float PlayY;
	public float BackX;
	public float BackY;
	public float PlayerStateX;
	public float PlayerStateY;

	public bool InShow = false;

	public static int LevelChos = 0;

	public static bool showOn = false;
	void Start(){
		Instantiate (Caption_ChooseLeader [0], new Vector3 (0.0f, 3.45f, 0.0f), Quaternion.identity);
	}
	void Update(){
		
		if (Input.GetKeyDown(KeyCode.Escape)) {
			GameSL.AutoSave = true;
			Application.Quit(); 
		}
	}
	void OnGUI(){
		
		switch(LevelChos){
		case 0:
			CHARInfo.InfoNum = 0;
			if (InShow == false) {				
				Instantiate (DisplayPartner [0], new Vector3 (0.0f, 2.5f, 0.0f), Quaternion.identity);
				InShow = true;
			}
			break;
		case 1:
			CHARInfo.InfoNum = 1;
			if (InShow == false) {
				Instantiate (DisplayPartner [1], new Vector3 (0.0f, 2.5f, 0.0f), Quaternion.identity);
				InShow = true;
			}
			break;
		case 2:
			CHARInfo.InfoNum = 2;
			if (InShow == false) {
				Instantiate (DisplayPartner [2], new Vector3 (0.0f, 2.5f, 0.0f), Quaternion.identity);
				InShow = true;
			}
			break;
		case 3:
			CHARInfo.InfoNum = 3;
			if (InShow == false) {
				Instantiate (DisplayPartner [3], new Vector3 (0.0f, 2.5f, 0.0f), Quaternion.identity);
				InShow = true;
			}
			break;
		case 4:
			CHARInfo.InfoNum = 4;
			if (InShow == false) {
				Instantiate (DisplayPartner [4], new Vector3 (0.0f, 2.5f, 0.0f), Quaternion.identity);
				InShow = true;
			}
			break;
		case 5:
			CHARInfo.InfoNum = 5;
			if (InShow == false) {
				Instantiate (DisplayPartner [5], new Vector3 (0.0f, 2.5f, 0.0f), Quaternion.identity);
				InShow = true;
			}
			break;
		case 6:
			CHARInfo.InfoNum = 6;
			if (InShow == false) {
				Instantiate (DisplayPartner [6], new Vector3 (0.0f, 2.5f, 0.0f), Quaternion.identity);
				InShow = true;
			}
			break;
		case 7:
			CHARInfo.InfoNum = 7;
			if (InShow == false) {
				Instantiate (DisplayPartner [7], new Vector3 (0.0f, 2.5f, 0.0f), Quaternion.identity);
				InShow = true;
			}
			break;
		}
		if (GUI.Button (new Rect (Screen.width * ChangeLX, Screen.height * ChangeLY, Screen.width * .20f,Screen.height * .12f), "", ChangeL)) {
			if (!showOn) {
				if (LevelChos == 0) {
					LevelChos = 7;
				} else {
					LevelChos -= 1;
				}
				InShow = false;
			}
		}
		if (GUI.Button (new Rect (Screen.width * ChangeRX, Screen.height * ChangeRY, Screen.width * .20f,Screen.height * .12f), "", ChangeR)) {
			if (!showOn) {
				if (LevelChos == 7) {
					LevelChos = 0;
				} else {
					LevelChos += 1;
				}
				InShow = false;
			}
		}
		if (GUI.Button (new Rect (Screen.width * PlayX, Screen.height * PlayY, Screen.width * .4f,Screen.height * .08f), "", Play)) {
			if (!showOn) {
				BackGroundMusic.acount += 1;
				Application.LoadLevel (6);
			}
		}
		if (GUI.Button (new Rect (Screen.width * BackX, Screen.height * BackY, Screen.width * .4f,Screen.height * .08f), "", Back)) {
			if (!showOn) {
				Application.LoadLevel (1);
				LevelChos = 0;
			}
		}
		if (GUI.Button (new Rect (Screen.width * PlayerStateX, Screen.height * PlayerStateY, Screen.width * .18f,Screen.height * .12f), "", PlayerState)) {
			if (!showOn) {
			Instantiate (PlayerShower [LevelChos], new Vector3 (0.0f, 0.75f, 0.0f), Quaternion.identity);
			}
			showOn = true;
		}
		
	}
}
