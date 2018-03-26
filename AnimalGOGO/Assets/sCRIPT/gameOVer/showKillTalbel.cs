using UnityEngine;
using System.Collections;

public class showKillTalbel : MonoBehaviour {
	public GUIText gui;
	public int kill = 0;

	void Start () {	

		kill = UniversGod.KillNum;

	}

	void OnGUI() {

		GetComponent<GUIText>().text = "總殺敵數：" +kill.ToString ();

	}
	// Update is called once per frame
	void Update () {
		kill = UniversGod.KillNum;
		if (kill <= 0) {
			kill = 0;
		}
	}
}
