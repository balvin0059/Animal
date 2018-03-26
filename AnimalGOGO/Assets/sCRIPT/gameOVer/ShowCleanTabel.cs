using UnityEngine;
using System.Collections;

public class ShowCleanTabel : MonoBehaviour {
	public GUIText gui;
	public int Coin = 0;

	void Start () {	

		Coin = UniversGod.Coin;

	}

	void OnGUI() {

		GetComponent<GUIText>().text = "總金幣：" + Coin.ToString ();

	}
	// Update is called once per frame
	void Update () {
		Coin = UniversGod.Coin;
		if (Coin <= 0) {
			Coin = 0;
		}
	}
}
