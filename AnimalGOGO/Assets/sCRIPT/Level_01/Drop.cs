using UnityEngine;
using System.Collections;

[System.Serializable]
public struct dropItem{
	
	public int ItemID;
	public string ItemName;
	public GameObject ItemObject;
	public float dropRate;

}
public class Drop : MonoBehaviour {
	// Use this for initialization.
	public dropItem[] Itemlist;
	public dropItem[] ItemPartner;
	public dropItem[] ItemCoin;
	static bool creatItemb = false;
	static public float monx;
	static public float mony;
	static public bool[] partnerHave = new bool[7];
	public float r;
	public int r_1;
	public float r_2;
	void Start () {	
		partnerHave[0] = false;
		partnerHave[1] = false;	
		partnerHave[2] = false;
		partnerHave[3] = false;
		partnerHave[4] = false;
		partnerHave[5] = false;
		partnerHave[6] = false;
	}	
	// Update is called once per frame
	void Update () {
		
		if (creatItemb) {
			creatItem ();
			creatItemb = false;
		}
	}
	public void DropRate(){

	}
	//collision item
	static public void FindItem(int v){
		
		if (v < 4) {	NormalItem (v);	}
		if (v < 11 && v >= 4) {	PartnerItem (v);	}
		if (v >= 11&& v < 14) {	CoinItem (v);	}

	}
	//item effect
	void Box(){
		
	}

	static public void NormalItem(int n){
		
		switch(n){
		case 0:
			UniversGod.AliveFeather += 1;
			break;
		case 1:
			UniversGod.TimeCDMagnent = 5.0f + (float)itemInfo.magnetLv*0.6f;
			UniversGod.ItemContrl_Magnet = true;
			break;
		case 2:
			if (UniversGod.Player_Anger < 30) {
				UniversGod.Player_Anger += 1;
			}
			break;
		case 3:	
			break;
		}
	}
	static public void PartnerItem(int p){
		switch(p){
		case 4:	
			partnerHave[0] = true;
			break;
		case 5:		
			partnerHave[1] = true;	
			break;
		case 6:
			partnerHave[2] = true;
			break;
		case 7:
			partnerHave[3] = true;
			break;
		case 8:
			partnerHave[4] = true;
			break;
		case 9:
			partnerHave[5] = true;
			break;
		case 10:
			partnerHave[6] = true;
			break;
		default:
			break;
		}
	}
	static public void CoinItem(int c){
		switch(c){
		case 11:
			if (UniversGod.SuperStarActive == true) {	UniversGod.Coin += 2;	}
			UniversGod.Coin += 1;
			break;
		case 12:
			if (UniversGod.SuperStarActive == true) {	UniversGod.Coin += 10;	}
			UniversGod.Coin += 5;
			break;
		case 13:
			if (UniversGod.SuperStarActive == true) {	UniversGod.Coin += 20;	}
			UniversGod.Coin += 10;
			break;
		default:			
			break;
		}
	}
	//drop item
	static public void monsterDead(GameObject mon){
		monx = mon.transform.position.x;
		mony = mon.transform.position.y;
		creatItemb = true;
	}
	void creatItem(){
		r = Random.value;
		if (r <= 0.1) {			
			Instantiate (Itemlist [0].ItemObject, new Vector3 (monx, mony, 0.0f), Quaternion.identity);
		} else if (r <= 0.18) {
			Instantiate (Itemlist [3].ItemObject, new Vector3 (monx, mony, 0.0f), Quaternion.identity);
		} else if (r <= 0.27) {
			Instantiate (Itemlist [1].ItemObject, new Vector3 (monx, mony, 0.0f), Quaternion.identity);
		} else if (r <= 0.36) {
			Instantiate (Itemlist [2].ItemObject, new Vector3 (monx, mony, 0.0f), Quaternion.identity);
		} else if (r <= 0.55) {
			creatItem_Partner ();
		} else {
			creatItem_Coin ();
		}
	}
	void creatItem_Partner(){
		r_1 = Random.Range (0, 6);
		if (partnerHave [r_1] != true) {
			if (r_1 != Character.LevelChos) {
				Instantiate (ItemPartner [r_1].ItemObject, new Vector3 (monx, mony, 0.0f), Quaternion.identity);
				partnerHave [r_1] = true;
			}
		} else {
			creatItem_Coin ();
		}

	}
	void creatItem_Coin(){
		r_2 = Random.value;
		if (r_2 <= 0.2) {
			Instantiate (ItemCoin [2].ItemObject, new Vector3 (monx, mony, 0.0f), Quaternion.identity);
		} else if (r_2 <= 0.4) {
			Instantiate (ItemCoin [1].ItemObject, new Vector3 (monx, mony, 0.0f), Quaternion.identity);
		} else {
			Instantiate (ItemCoin [0].ItemObject, new Vector3 (monx, mony, 0.0f), Quaternion.identity);
		}
	}
	//get item id
	static public int GetitemID(GameObject a){
		switch (a.name) {
		case "alive_feather(Clone)":
			return 0;
			break;
		case "magnet(Clone)":
			return 1;
			break;
		case "lightball(Clone)":
			return 2;
			break;
		case "treasure(Clone)":
			return 3;
			break;
		case "Itempartner_mouse(Clone)":
			return 4;
			break;
		case "Itempartner_ox(Clone)":
			return 5;
			break;
		case "Itempartner_tiger(Clone)":
			return 6;
			break;
		case "Itempartner_dragon(Clone)":
			return 7;
			break;
		case "Itempartner_snake(Clone)":
			return 8;
			break;
		case "Itempartner_cock(Clone)":
			return 9;
			break;
		case "Itempartner_dog(Clone)":
			return 10;
			break;
		case "Itempartner_pig(Clone)":
			return 11;
			break;
		case "coin_1(Clone)":
			return 12;
			break;
		case "coin_5(Clone)":
			return 13;
			break;
		case "coin_10(Clone)":
			return 14;
			break;
		default:
			return 15;
			break;
		}
	}
}
