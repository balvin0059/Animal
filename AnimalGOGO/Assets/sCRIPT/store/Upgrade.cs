using UnityEngine;
using System.Collections;

public class Upgrade : MonoBehaviour {
	public GameObject Nomoney;
	public GameObject[] Caption_SecUp;
	public GameObject[] Caption_rangeup;
	public GameObject[] Caption_NumUp;
	//
	public GUIStyle Yes;
	public float YesX;
	public float YesY;

	public GUIStyle No;
	public float NoX;
	public float NoY;

	public int checkItem = 0;
	public int checkItemLv = 0;
	public int pay;


	// Use this for initialization
	void Start () {

		checkItem = itemInfo.ItemIDInfo;

		switch (checkItem) {
		case 0:
			checkItemLv = itemInfo.treasureLv;
			Instantiate (Caption_NumUp [0], new Vector3 (0.0f, 2.5f, 0.0f), Quaternion.identity);

			break;
		case 1:
			checkItemLv = itemInfo.livebuttonLv;
			Instantiate (Caption_NumUp [0], new Vector3 (0.0f, 2.5f, 0.0f), Quaternion.identity);

			break;
		case 2:
			checkItemLv = itemInfo.bombLv;
			Instantiate (Caption_rangeup [0], new Vector3 (0.0f, 2.5f, 0.0f), Quaternion.identity);

			break;
		case 3:
			checkItemLv = itemInfo.magnetLv;
			Instantiate (Caption_SecUp [0], new Vector3 (0.0f, 2.5f, 0.0f), Quaternion.identity);

			break;
		case 4:
			checkItemLv = itemInfo.superstarLv;
			Instantiate (Caption_SecUp [0], new Vector3 (0.0f, 2.5f, 0.0f), Quaternion.identity);

			break;
		case 5:
			checkItemLv = itemInfo.energyLv;
			Instantiate (Caption_NumUp [0], new Vector3 (0.0f, 2.5f, 0.0f), Quaternion.identity);
	
			break;
		case 6:
			checkItemLv = itemInfo.timestopLv;
			Instantiate (Caption_SecUp [0], new Vector3 (0.0f, 2.5f, 0.0f), Quaternion.identity);

			break;
		case 7:
			checkItemLv = 0;
			break;
		}
	}
	
	// Update is called once per frame
	void Update () {
		pay = needmoney (checkItemLv);
	}
	void OnGUI(){
		if (GUI.Button (new Rect (Screen.width * YesX, Screen.height * YesY, Screen.width * .30f,Screen.height * .06f), "", Yes)) {
			if (checkItemLv < 5) {				
				if (UniversGod.Coin > pay) {
					ItemLevelUP (checkItem);
					UniversGod.Coin -= pay;
					storecontrl.showOn = false;
					Destroy (gameObject);
				} else {
					Instantiate (Nomoney, new Vector3 (0.0f, 1.2f, 0.0f), Quaternion.identity);
					storecontrl.showOn = false;
					Destroy (gameObject);
				}
			}
			storecontrl.showOn = false;
			Destroy (gameObject);
		}
		if (GUI.Button (new Rect (Screen.width * NoX, Screen.height * NoY, Screen.width * .30f,Screen.height * .06f), "", No)) {
			storecontrl.showOn = false;
			Destroy (gameObject);
		}
	}
	void ItemLevelUP(int id){
		switch (id) {
		case 0:
			itemInfo.treasureLv += 1;
			break;
		case 1:
			itemInfo.livebuttonLv += 1;
			break;
		case 2:
			itemInfo.bombLv += 1;
			break;
		case 3:
			itemInfo.magnetLv += 1;
			break;
		case 4:
			itemInfo.superstarLv += 1;
			break;
		case 5:
			itemInfo.energyLv += 1;
			break;
		case 6:
			itemInfo.timestopLv += 1;
			break;
		case 7:
			checkItemLv = 0;
			break;
		}
	}
	int needmoney(int lv){
		switch (lv) {
		case 0:
			return 1000;
			break;
		case 1:
			return 4000;
			break;
		case 2:
			return 12000;
			break;
		case 3:
			return 20000;
			break;
		case 4:
			return 40000;
			break;
		default:
			return 0;
			break;
			
		}

	}
}
