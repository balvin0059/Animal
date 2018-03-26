using UnityEngine;
using System.Collections;

public class state : MonoBehaviour {
	public GUIStyle Close;
	public float CloseX;
	public float CloseY;
	// Use this for initialization

	// Update is called once per frame
	void Update () {
	
	}
	void OnGUI(){
		if (GUI.Button (new Rect (Screen.width * CloseX, Screen.height * CloseY, Screen.width * .325f,Screen.height * .065f), "", Close)) {
			Character.showOn = false;
			Destroy (gameObject);
		}
}

}
