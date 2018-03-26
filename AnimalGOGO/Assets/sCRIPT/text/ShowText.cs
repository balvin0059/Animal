using UnityEngine;
using System.Collections;

public class ShowText : MonoBehaviour {
	public GUIText gui;
	public int Remain = 0;

	void Start () {	

		Remain = Monster_Spawn.NextLevel;

	}

	void OnGUI() {

		GetComponent<GUIText>().text = "還需擊殺:" + Remain.ToString ();
		gui.fontSize = 50;
	}
	// Update is called once per frame
	void Update () {
		Remain = Monster_Spawn.NextLevel;
		if (Remain <= 0) {
			Remain = 0;
		}
	}
}
