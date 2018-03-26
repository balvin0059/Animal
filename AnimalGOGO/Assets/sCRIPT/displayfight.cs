using UnityEngine;
using System.Collections;

public class displayfight : MonoBehaviour {

	public float speed = 0.04f;
	public float aspds = 0.0f;
	bool shotOK = false;
	// Use this for initialization
	void Start () {
		resetAspd ();
	}
	
	// Update is called once per frame
	void Update () {
		
		aspds -= Time.deltaTime;
		if (aspds <= 0) {
			shotOK = true;	
			resetAspd ();
		}
		if (shotOK == true) {
			if (transform.position.x < 1.2f) {
				transform.position += new Vector3 (speed, 0.0f, 0.0f);
			} else {	speed = 0;	shotOK = false;}
		}
	}
	void resetAspd(){
		if (Character.LevelChos == 0) {
			aspds = UniversGod.player_mouse.aspd;
			transform.position = new Vector3 (-0.5f, 1.95f, 0.0f);
			speed = 0.04f;
		} else if (Character.LevelChos == 1) {
			aspds =UniversGod.player_ox.aspd;
		} else if (Character.LevelChos == 2) {
			aspds =UniversGod.player_tiger.aspd;
		} else if (Character.LevelChos == 3) {
			aspds =UniversGod.player_dragon.aspd;
			transform.position = new Vector3 (-0.5f, 1.95f, 0.0f);
			speed = 0.04f;
		} else if (Character.LevelChos == 4) {
			aspds =UniversGod.player_snake.aspd;
			transform.position = new Vector3 (-0.5f, 1.95f, 0.0f);
			speed = 0.04f;
		} else if (Character.LevelChos == 5) {
			aspds = UniversGod.player_cock.aspd;
			transform.position = new Vector3 (-0.5f, 1.95f, 0.0f);
			speed = 0.04f;
		} else if (Character.LevelChos == 6) {
			aspds =UniversGod.player_dog.aspd;
			transform.position = new Vector3 (-0.5f, 1.95f, 0.0f);
			speed = 0.04f;
		} else if (Character.LevelChos == 7) {
			aspds =UniversGod.player_pig.aspd;
		}
	}
}
