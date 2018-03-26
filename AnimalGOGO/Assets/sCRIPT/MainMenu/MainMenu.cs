using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {


	// bottom set
	public GUIStyle PLAYGAME;
	public GUIStyle OPTION;
	public GUIStyle STORE;
	
	public float GUIBottomPLAYX;
	public float GUIBottomPLAYY;
	public float GUIBottomExitX;
	public float GUIBottomExitY;
	public float GUIBottomStoreX;
	public float GUIBottomStoreY;

	public GameObject BackMusic;
	public GameObject GodUniver;
	void Start(){
		if (!UniversGod.GodOnLive) {
			Instantiate (BackMusic, new Vector3 (0f, 0f, -0f), Quaternion.identity);
			Instantiate (GodUniver, new Vector3 (0f, 0f, -0f), Quaternion.identity);
		}
	}
	
	void Update(){
		if (Input.GetKeyDown(KeyCode.Escape)) {
			Application.Quit(); 
		}
	}
	void OnGUI(){
		
		// display background
		//display bottom (without GUI outline)
		if (GUI.Button (new Rect (Screen.width * GUIBottomPLAYX, Screen.height * GUIBottomPLAYY, Screen.width * .4f,Screen.height * .08f), "", PLAYGAME)) {
			BackGroundMusic.acount+=1;
			Application.LoadLevel(2);
		}
		if (GUI.Button (new Rect (Screen.width * GUIBottomExitX, Screen.height * GUIBottomExitY, Screen.width * .4f,Screen.height * .08f), "", OPTION)) {			
			Application.LoadLevel(8);			
		}
		if (GUI.Button (new Rect (Screen.width * GUIBottomStoreX, Screen.height * GUIBottomStoreY, Screen.width * .4f,Screen.height * .08f), "", STORE)) {
			Application.LoadLevel(7);				
		}
	}
}