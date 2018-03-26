using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthText : MonoBehaviour {
	public GUIText gui;
	public int Health = 0;
	public string stringToEdit = "";

	void Start () {	
		
		Health = UniversGod.Player_Health;

	}

	void OnGUI() {
		
		GetComponent<GUIText>().text = "Lives:" + Health.ToString ();
		gui.fontSize = 50;

	}
	// Update is called once per frame
	void Update () {
		Health = UniversGod.Player_Health;
		if (Health <= 0) {
			Health = 0;
		}
	}
}
