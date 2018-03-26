using UnityEngine;
using System.Collections;

public class fttext : MonoBehaviour {
	public GUIText gui;
	public int ft = 0;
	public float px = 0.0f;
	public float py = 0.0f;
	void Start () {	

		ft = UniversGod.AliveFeather;

	}

	void OnGUI() {

		GetComponent<GUIText>().text = ft.ToString ();
		gui.fontSize = 45;
	}
	// Update is called once per frame
	void Update () {
		ft = UniversGod.AliveFeather;
		if (ft <= 0) {
			ft = 0;
		}
	}
}