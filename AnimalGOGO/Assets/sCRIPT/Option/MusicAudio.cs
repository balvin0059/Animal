using UnityEngine;
using System.Collections;

public class MusicAudio : MonoBehaviour {
	public GUIStyle MusicOneA;
	public GUIStyle MusicOneB;
	public GUIStyle MusicTwoA;
	public GUIStyle MusicTwoB;

	public float MusicOneAX;
	public float MusicOneAY;
	public float MusicOneBX;
	public float MusicOneBY;
	public float MusicTwoAX;
	public float MusicTwoAY;
	public float MusicTwoBX;
	public float MusicTwoBY;

	public GUIStyle Back;
	public float BackX;
	public float BackY;

	public static int musicA = 5;
	public static int musicB = 5;


	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			GameSL.AutoSave = true;
			Application.Quit(); 
		}
	}
	void OnGUI(){
		if (GUI.Button (new Rect (Screen.width * MusicOneAX, Screen.height * MusicOneAY, Screen.width * .14f, Screen.height * .08f), "", MusicOneA)) {
			if (musicA == 0) {
				
			} else {
				musicA -= 1;
			}
		}
		if (GUI.Button (new Rect (Screen.width * MusicOneBX, Screen.height * MusicOneBY, Screen.width * .14f, Screen.height * .08f), "", MusicOneB)) {
			if (musicA == 5) {
				
			} else {
				musicA += 1;
			}
		}
		if (GUI.Button (new Rect (Screen.width * MusicTwoAX, Screen.height * MusicTwoAY, Screen.width * .14f, Screen.height * .08f), "", MusicTwoA)) {
			if (musicB == 0) {
				
			} else {
				musicB -= 1;
			}
		}
		if (GUI.Button (new Rect (Screen.width * MusicTwoBX, Screen.height * MusicTwoBY, Screen.width * .14f, Screen.height * .08f), "", MusicTwoB)) {
			if (musicB == 5) {
				
			} else {
				musicB += 1;
			}
		}
		if (GUI.Button (new Rect (Screen.width * BackX, Screen.height * BackY, Screen.width * .4f, Screen.height * .08f), "", Back)) {
			Application.LoadLevel(1);
			Character.LevelChos = 0;
		}


	}
}
