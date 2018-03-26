using UnityEngine;
using System.Collections;

public class Buy : MonoBehaviour {
	public GameObject Nomoney;
	public GUIStyle Yes;
	public float YesX;
	public float YesY;
	public GUIStyle No;
	public float NoX;
	public float NoY;

	public int checkItem = 0;
	static public int BuyItemLevel = 0;
	int pay;
	// Use this for initialization
	void Start () {
		checkItem = itemInfo.ItemIDInfo;
		switch (checkItem) {
		case 0:
			BuyItemLevel = itemInfo.treasureLv;
			break;
		case 1:
			BuyItemLevel = itemInfo.livebuttonLv;
			break;
		case 2:
			BuyItemLevel = itemInfo.bombLv;
			break;
		case 3:
			BuyItemLevel = itemInfo.magnetLv;
			break;
		case 4:
			BuyItemLevel = itemInfo.superstarLv;
			break;
		case 5:
			BuyItemLevel = itemInfo.energyLv;
			break;
		case 6:
			BuyItemLevel = itemInfo.timestopLv;
			break;
		case 7:
			BuyItemLevel = 4;
			break;
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
	void OnGUI(){
		if (GUI.Button (new Rect (Screen.width * YesX, Screen.height * YesY, Screen.width * .30f,Screen.height * .06f), "", Yes)) {
			if (UniversGod.Coin >= pay) {
				UniversGod.Coin -= pay;
				GetItem ();
				storecontrl.showOn = false;
				Destroy (gameObject);
			}else {
				Instantiate (Nomoney, new Vector3 (0.0f, 1.2f, 0.0f), Quaternion.identity);
				storecontrl.showOn = false;
				Destroy (gameObject);
			}
		}
		if (GUI.Button (new Rect (Screen.width * NoX, Screen.height * NoY, Screen.width * .30f,Screen.height * .06f), "", No)) {
			storecontrl.showOn = false;
			Destroy (gameObject);
		}
		//
	}
	void GetItem(){
		switch (checkItem) {
		case 0:
			break;
		case 1:
			UniversGod.ItemLiveButtom += 1;
			break;
		case 2:
			UniversGod.ItemBomb += 1;
			break;
		case 3:
			break;
		case 4:UniversGod.ItemSuperStar += 1;
			break;
		case 5:
			break;
		case 6:
			UniversGod.ItemTimeStop += 1;
			break;
		case 7:
			UniversGod.AliveFeather += 1;
			break;
		default:
			break;
		}
	}
	int needmoney(int lv){
		return 100 * lv;
	}
}
