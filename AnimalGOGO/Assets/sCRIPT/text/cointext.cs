using UnityEngine;
using System.Collections;

public class cointext : MonoBehaviour {
	public GUIText gui;
	public int Coin = 0;

	void Start () {	

		Coin = UniversGod.Coin;

	}

	void OnGUI() {

		GetComponent<GUIText>().text = Coin.ToString ();
		//gui.fontSize = 45;
	}
	// Update is called once per frame
	void Update () {
		Coin = UniversGod.Coin;
		if (Coin <= 0) {
			Coin = 0;
		}
	}
}
