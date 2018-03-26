using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class levelbar : MonoBehaviour {

	public Scrollbar levelingbar;
	public float nowlevel; 
	public float barnow;
	static public bool nextmis = false;
	static public bool prepare = false;
	public float alarm = 5.0f;

	static public bool levelup = false;
	static public bool Check = false;

	// Use this for initialization
	void Start () {
		nowlevel = 0.0f;
		barnow = (float)Monster_Spawn.NextLevel;
		nextCheck();
	}

	// Update is called once per frame
	void Update () {
		
		if (Check) {nextCheck ();}
		if (!prepare) {
			if (!nextmis) {
				//barnow = (float)Monster_Spawn.NextLevel;
				nowlevel = barnow - (float)Monster_Spawn.NextLevel;
				levelingbar.size = nowlevel / barnow;
			}
		} else {
			nextmis = true;
			levelingbar.size = alarm / 5.0f;
			alarm -= Time.deltaTime;
			if (alarm <= 0) {
				alarm = 5.0f;
				prepare = false;
				God_.preparingEnd = true;
				if (God_.LevelComplete) {
					God_.oknextlevel = true;
				}
			}
		}
	}
	void nextCheck(){
		nowlevel = (float)Monster_Spawn.NextLevel;
		barnow = (float)Monster_Spawn.NextLevel;
		nextmis = false;
		Check = false;
	}
}
