using UnityEngine;
using System.Collections;

public class LevelC : MonoBehaviour {
	public GameObject[] DisplayPartner;
	public GameObject[] ShowLevelTitle;
	public GameObject[] ShowLevel;
	public GameObject[] Caption_Buff;
	public GameObject[] Caption_Item;
	//
	static public int NowLevel = 0;
	static public int Buff = 0;

	public int skillOpen = 0;
	//
	// bottom set
	public GUIStyle StartB;
	public float StartX;
	public float StartY;
	public GUIStyle Back;
	public float BackX;
	public float BackY;
	//
	public GUIStyle LiveUP;
	public bool bLiveUP = false;
	public bool cLiveUp = false;
	public float LiveUPX;
	public float LiveUPY;

	public GUIStyle DefendUP;
	public bool bDefendUP = false;
	public float DefendUPX;
	public float DefendUPY;
	public GUIStyle MoveSpeedUP;
	public bool bMoveSpeedUP = false;
	public float MoveSpeedUPX;
	public float MoveSpeedUPY;
	public GUIStyle AttackUP;
	public bool bAttackUP = false;
	public float AttackUPX;
	public float AttackUPY;
	//
	public GUIStyle LiveButtom;
	public float LiveButtomX;
	public float LiveButtomY;
	public bool bLiveButtom = true;
	public bool cLiveButtom = false;
	public GUIStyle Bomb;
	public float BombX;
	public float BombY;
	public bool bBomb = true;
	public bool cBomb = false;
	public GUIStyle SuperStar;
	public float SuperStarX;
	public float SuperStarY;
	public bool bSuperStar = true;
	public bool cSuperStar = false;
	public GUIStyle TimeStop;
	public float TimeStopX;
	public float TimeStopY;
	public bool bTimeStop = true;
	public bool cTimeStop = false;

	public GameObject BackMusic;
	void Start(){

		GameSL.AutoSave = true;

		if (UniversGod.ItemLiveButtom > 0) {	cLiveButtom = true;	} else {	cLiveButtom = false;	}
		if (UniversGod.ItemBomb > 0) {	cBomb = true;	} else {	cBomb = false;	}
		if (UniversGod.ItemSuperStar > 0) {	cSuperStar = true;	} else {	cSuperStar = false;	}
		if (UniversGod.ItemTimeStop > 0) {	cTimeStop = true;	} else {	cTimeStop = false;	}
		switch(Character.LevelChos){
		case 0:
			Instantiate (DisplayPartner [0], new Vector3 (0.0f, 0.8f, 0.0f), Quaternion.identity);
			break;
		case 1:
			Instantiate (DisplayPartner [1], new Vector3 (0.0f, 0.8f, 0.0f), Quaternion.identity);
			break;
		case 2:
			Instantiate (DisplayPartner [2], new Vector3 (0.0f, 0.8f, 0.0f), Quaternion.identity);
			break;
		case 3:
			Instantiate (DisplayPartner [3], new Vector3 (0.0f, 0.8f, 0.0f), Quaternion.identity);
			break;
		case 4:
			Instantiate (DisplayPartner [4], new Vector3 (0.0f, 0.8f, 0.0f), Quaternion.identity);
			break;
		case 5:
			Instantiate (DisplayPartner [5], new Vector3 (0.0f, 0.8f, 0.0f), Quaternion.identity);
			break;
		case 6:
			Instantiate (DisplayPartner [6], new Vector3 (0.0f, 0.8f, 0.0f), Quaternion.identity);
			break;
		case 7:
			Instantiate (DisplayPartner [7], new Vector3 (0.0f, 0.8f, 0.0f), Quaternion.identity);
			break;
		}
		Instantiate (ShowLevelTitle [UniversGod.NowLevelNum], new Vector3 (0.0f, 3.0f, 0.0f), Quaternion.identity);
		Instantiate (ShowLevel [UniversGod.NowLevelNum], new Vector3 (0.0f, 1.9f, 0.0f), Quaternion.identity);
		Instantiate (Caption_Buff [0], new Vector3 (0.0f, -0.5f, 0.0f), Quaternion.identity);
		Instantiate (Caption_Item [0], new Vector3 (0.0f, -2.35f, 0.0f), Quaternion.identity);
	}
	void Update(){
		if (Input.GetKeyDown(KeyCode.Escape)) {
			GameSL.AutoSave = true;
			Application.Quit(); 
		}
	}
	void OnGUI(){
		//
		if (GUI.Button (new Rect (Screen.width * StartX, Screen.height * StartY, Screen.width * .35f,Screen.height * .07f), "", StartB)) {
			ClearLevel ();
			GotoLevel (UniversGod.NowLevelNum);
		}
		if (GUI.Button (new Rect (Screen.width * BackX, Screen.height * BackY, Screen.width * .35f,Screen.height * .07f), "", Back)) {
			Application.LoadLevel(2);
			Character.LevelChos = 0;
		}
		///////////////////////////////
		if (GUI.Button (new Rect (Screen.width * LiveUPX, Screen.height * LiveUPY, Screen.width * 0.16f, Screen.height * 0.095f), "", "")) {				
			if (!bLiveUP) {
				bLiveUP = true;
				if (UniversGod.AliveFeather > 1) {
					skillOpen += 1;
					UniversGod.AliveFeather -= 1;
					UniversGod.Player_HealthMax = 10;
					UniversGod.NowMaxHp = 10;
					UniversGod.Player_Health = 10;
				}
			} else {
				bLiveUP = false;
				UniversGod.AliveFeather += 1;
				UniversGod.Player_HealthMax = 0;
				UniversGod.NowMaxHp = 10;
				UniversGod.Player_Health = 10;
				skillOpen -= 1;
			}	
		}
		if (GUI.Toggle (new Rect (Screen.width * LiveUPX, Screen.height * LiveUPY, Screen.width * 0.16f, Screen.height * 0.095f),bLiveUP, "", LiveUP)) {}
		///////////////////////////////
		if (GUI.Button (new Rect (Screen.width * DefendUPX, Screen.height * DefendUPY, Screen.width * 0.16f, Screen.height * 0.095f), "", "")) {

			if (!bDefendUP) {
				bDefendUP = true;
				if (UniversGod.AliveFeather > 1) {	
					UniversGod.AliveFeather -= 1;
					skillOpen += 1;
				}
			} else {				
				bDefendUP = false;
				UniversGod.AliveFeather += 1;
				skillOpen -= 1;
			}
		}
		if (GUI.Toggle (new Rect (Screen.width * DefendUPX, Screen.height * DefendUPY, Screen.width * 0.16f, Screen.height * 0.095f),bDefendUP, "", DefendUP)) {}
		///////////////////////////////
		if (GUI.Button (new Rect (Screen.width * MoveSpeedUPX, Screen.height * MoveSpeedUPY, Screen.width * 0.16f, Screen.height * 0.095f), "", "")) {
			if (!bMoveSpeedUP) {
				bMoveSpeedUP = true;
				if (UniversGod.AliveFeather > 1) {
					PlayerControl.isped = 0.02f;
					UniversGod.AliveFeather -= 1;
					skillOpen += 1;
				}
			} else {
				bMoveSpeedUP = false;
				UniversGod.AliveFeather += 1;
				skillOpen -= 1;
			}
		}
		if (GUI.Toggle (new Rect (Screen.width * MoveSpeedUPX, Screen.height * MoveSpeedUPY, Screen.width * 0.16f, Screen.height * 0.095f),bMoveSpeedUP, "", MoveSpeedUP)) {}
		///////////////////////////////
		if (GUI.Button (new Rect (Screen.width * AttackUPX, Screen.height * AttackUPY, Screen.width * 0.16f, Screen.height * 0.095f),  "", "")) {
			if (!bAttackUP) {
				bAttackUP = true;
				if (UniversGod.AliveFeather > 1) {	
					UniversGod.AliveFeather -= 1;
					skillOpen += 1;
				}
			} else {
				bAttackUP = false;
				UniversGod.AliveFeather += 1;
				skillOpen -= 1;
			}
		}
		if (GUI.Toggle (new Rect (Screen.width * AttackUPX, Screen.height * AttackUPY, Screen.width * 0.16f, Screen.height * 0.095f),bAttackUP, "", AttackUP)) {}
		//

		if (!cLiveButtom) {
			if (GUI.Toggle (new Rect (Screen.width * LiveButtomX, Screen.height * LiveButtomY, Screen.width * 0.16f, Screen.height * 0.095f),bLiveButtom, "", LiveButtom)) {
			}
		} else {
			if (GUI.Button (new Rect (Screen.width * LiveButtomX, Screen.height * LiveButtomY, Screen.width * 0.16f, Screen.height * 0.095f), "", LiveButtom)) {	
			}
		}

		if (!cBomb) {
			if (GUI.Toggle (new Rect (Screen.width * BombX, Screen.height * BombY, Screen.width * 0.16f, Screen.height * 0.095f), bBomb, "", Bomb)) {
			}
		} else {
			if (GUI.Button (new Rect (Screen.width * BombX, Screen.height * BombY, Screen.width * 0.16f, Screen.height * 0.095f), "", Bomb)) {
			}
		}

		if (!cSuperStar) {
			if (GUI.Toggle (new Rect (Screen.width * SuperStarX, Screen.height * SuperStarY, Screen.width * 0.16f, Screen.height * 0.095f), bSuperStar, "", SuperStar)) {
			}
		} else {
			if (GUI.Button (new Rect (Screen.width * SuperStarX, Screen.height * SuperStarY, Screen.width * 0.16f, Screen.height * 0.095f), "", SuperStar)) {
			}
		}

		if (!cTimeStop) {
			if (GUI.Toggle (new Rect (Screen.width * TimeStopX, Screen.height * TimeStopY, Screen.width * 0.16f, Screen.height * 0.095f), bTimeStop, "", TimeStop)) {
			}
		} else {
				if (GUI.Button (new Rect (Screen.width * TimeStopX, Screen.height * TimeStopY, Screen.width * 0.16f, Screen.height * 0.095f), "", TimeStop)) {
				}
			}

		//
	}
	void GotoLevel(int lv){
		if (lv == 3) {
			lv = 0;
			UniversGod.NowLevelNum = 0;
		}
		switch (lv) {
		case 0:			
			GameSL.AutoSave = true;
			Application.LoadLevel(3);
			break;
		case 1:			
			GameSL.AutoSave = true;
			Application.LoadLevel(4);
			break;
		case 2:			
			GameSL.AutoSave = true;
			Application.LoadLevel(5);
			break;
		}
	}
	void ClearLevel (){
		if (!bLiveUP) {
			UniversGod.Player_HealthMax = 0;
		}
		GameSL.AutoSave = true;
		God_.LevelComplete = false;
		God_.level = 0;
		UniversGod.Player_Health = UniversGod.NowMaxHp;
		PlayerControl.EatPartner = 0;
		PlayerControl.Partner_Num = 0;
		Monster_Spawn.maxNum = 5;
	}
}
