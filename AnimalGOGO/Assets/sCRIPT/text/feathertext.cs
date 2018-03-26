using UnityEngine;
using System.Collections;

public class feathertext : MonoBehaviour {
	public GUIText gui;
	public int kill = 0;

	void Start () {	

		kill = UniversGod.KillNum;

	}

	void OnGUI() {

		GetComponent<GUIText>().text = kill.ToString ();
		gui.fontSize = 45;
	}
	// Update is called once per frame
	void Update () {
		kill = UniversGod.KillNum;
		if (kill <= 0) {
			kill = 0;
		}
	}
}
