using UnityEngine;
using System.Collections;

public class itemInfo : MonoBehaviour {
	
	SpriteRenderer sr;
	public Sprite[] treasure;
	public static int treasureLv;
	public Sprite[] livebutton;
	public static int livebuttonLv;
	public Sprite[] bomb;
	public static int bombLv;
	public Sprite[] magnet;
	public static int magnetLv;
	public Sprite[] superstar;
	public static int superstarLv;
	public Sprite[] energy;
	public static int energyLv;
	public Sprite[] timestop;
	public static int timestopLv;
	public Sprite[] alivefeather;

	public Sprite[] starlevel;

	public static int ItemIDInfo = 0;


	// Use this for initialization
	void Start () {
		sr = GetComponent<SpriteRenderer>();

	}

	// Update is called once per frame
	void Update () {
		switch (ItemIDInfo) {
		case 0:
			switch(treasureLv){
			case 0:
				sr.sprite = treasure [0];
				break;
			case 1:
				sr.sprite = treasure [1];
				break;
			case 2:
				sr.sprite = treasure [2];
				break;
			case 3:
				sr.sprite = treasure [3];
				break;
			case 4:
				sr.sprite = treasure [4];
				break;
			}
			break;
		case 1:
			switch(livebuttonLv){
			case 0:
				sr.sprite = livebutton [0];
				break;
			case 1:
				sr.sprite = livebutton [1];
				break;
			case 2:
				sr.sprite = livebutton [2];
				break;
			case 3:
				sr.sprite = livebutton [3];
				break;
			case 4:
				sr.sprite = livebutton [4];
				break;
			}
			break;
		case 2:
			switch(bombLv){
			case 0:
				sr.sprite = bomb [0];
				break;
			case 1:
				sr.sprite = bomb [1];
				break;
			case 2:
				sr.sprite = bomb [2];
				break;
			case 3:
				sr.sprite = bomb [3];
				break;
			case 4:
				sr.sprite = bomb [4];
				break;
			}
			break;
		case 3:
			switch(magnetLv){
			case 0:
				sr.sprite = magnet [0];
				break;
			case 1:
				sr.sprite = magnet [1];
				break;
			case 2:
				sr.sprite = magnet [2];
				break;
			case 3:
				sr.sprite = magnet [3];
				break;
			case 4:
				sr.sprite = magnet [4];
				break;
			}
			break;
		case 4:
			switch(superstarLv){
			case 0:
				sr.sprite = superstar [0];
				break;
			case 1:
				sr.sprite = superstar [1];
				break;
			case 2:
				sr.sprite = superstar [2];
				break;
			case 3:
				sr.sprite = superstar [3];
				break;
			case 4:
				sr.sprite = superstar [4];
				break;
			}
			break;
		case 5:
			switch(energyLv){
			case 0:
				sr.sprite = energy [0];
				break;
			case 1:
				sr.sprite = energy [1];
				break;
			case 2:
				sr.sprite = energy [2];
				break;
			case 3:
				sr.sprite = energy [3];
				break;
			case 4:
				sr.sprite = energy [4];
				break;
			}
			break;
		case 6:
			switch(timestopLv){
			case 0:
				sr.sprite = timestop [0];
				break;
			case 1:
				sr.sprite = timestop [1];
				break;
			case 2:
				sr.sprite = timestop [2];
				break;
			case 3:
				sr.sprite = timestop [3];
				break;
			case 4:
				sr.sprite = timestop [4];
				break;
			}
			break;
		case 7:
			sr.sprite = alivefeather [0];
			break;
		}
	}
}
