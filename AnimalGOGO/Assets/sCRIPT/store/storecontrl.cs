using UnityEngine;
using System.Collections;

public class storecontrl : MonoBehaviour {
	
	public GameObject UpgradeM;
	public GameObject BuyM;
	public GameObject[] DisplayItem;
	//word
	public GameObject[] Caption_ChooseItem;
	//
	public int ItemIDchose = 0;
	public int ItemCheckLv = 0;
	//
	// bottom set
	public GUIStyle Buy;
	public bool bBuy = true;
	public bool cBuy = false;
	public float BuyX;
	public float BuyY;
	public GUIStyle Upgrade;
	public bool bUpgrade = true;
	public bool cUpgrade = false;
	public float UpgradeX;
	public float UpgradeY;
	//
	public GUIStyle ChangeL;
	public float ChangeLX;
	public float ChangeLY;
	public GUIStyle ChangeR;
	public float ChangeRX;
	public float ChangeRY;
	//
	public GUIStyle Back;
	public float BackX;
	public float BackY;
	//
	public bool InShow = false;
	public static bool showOn = false;


	void Start () {
		GameSL.AutoSave = true;
		ItemIDchose = itemInfo.ItemIDInfo;
		Instantiate (Caption_ChooseItem [0], new Vector3 (0.0f, 3.45f, 0.0f), Quaternion.identity);
		CheckLevel ();
	}
	void Update(){
		bBuy = true;
		bUpgrade = true;
		cBuy = true;
		cUpgrade = true;

		CheckLevel ();
		itemInfo.ItemIDInfo = ItemIDchose;

		if (ItemIDchose == 0) {	cBuy = false;	}
		if (ItemIDchose == 3) { cBuy = false;	}
		if (ItemIDchose == 5) {	cBuy = false;	}
		if (ItemIDchose == 7) {	cUpgrade = false;	}
		if (ItemCheckLv >= 4) {	cUpgrade = false;	}

		if (Input.GetKeyDown(KeyCode.Escape)) {
			Application.Quit(); 
		}

	}
	void OnGUI(){
		//
		switch(ItemIDchose){
		case 0:
			itemInfo.ItemIDInfo = 0;
			if (InShow == false) {				
				Instantiate (DisplayItem [0], new Vector3 (0.0f, 2.5f, 0.0f), Quaternion.identity);
				InShow = true;
			}
			break;
		case 1:
			itemInfo.ItemIDInfo = 1;
			if (InShow == false) {
				Instantiate (DisplayItem [1], new Vector3 (0.0f, 2.5f, 0.0f), Quaternion.identity);
				InShow = true;
			}
			break;
		case 2:
			itemInfo.ItemIDInfo = 2;
			if (InShow == false) {
				Instantiate (DisplayItem [2], new Vector3 (0.0f, 2.5f, 0.0f), Quaternion.identity);
				InShow = true;
			}
			break;
		case 3:
			itemInfo.ItemIDInfo = 3;
			if (InShow == false) {
				Instantiate (DisplayItem [3], new Vector3 (0.0f, 2.5f, 0.0f), Quaternion.identity);
				InShow = true;
			}
			break;
		case 4:
			itemInfo.ItemIDInfo = 4;
			if (InShow == false) {
				Instantiate (DisplayItem [4], new Vector3 (0.0f, 2.5f, 0.0f), Quaternion.identity);
				InShow = true;
			}
			break;
		case 5:
			itemInfo.ItemIDInfo = 5;
			if (InShow == false) {
				Instantiate (DisplayItem [5], new Vector3 (0.0f, 2.5f, 0.0f), Quaternion.identity);
				InShow = true;
			}
			break;
		case 6:
			itemInfo.ItemIDInfo = 6;
			if (InShow == false) {
				Instantiate (DisplayItem [6], new Vector3 (0.0f, 2.5f, 0.0f), Quaternion.identity);
				InShow = true;
			}
			break;
		case 7:
			itemInfo.ItemIDInfo = 7;
			if (InShow == false) {
				Instantiate (DisplayItem [7], new Vector3 (0.0f, 2.5f, 0.0f), Quaternion.identity);
				InShow = true;
			}
			break;
		}
		if (!cBuy) {
			if (GUI.Toggle (new Rect (Screen.width * BuyX, Screen.height * BuyY, Screen.width * .30f, Screen.height * .07f), bBuy, "", Buy)) {
			}
		} else {
			if (GUI.Button (new Rect (Screen.width * BuyX, Screen.height * BuyY, Screen.width * .30f, Screen.height * .07f), "", Buy)) {
				if (!showOn) {
					BuyMotion ();
				}
			}
		}
		//
		if (!cUpgrade) {
			if (GUI.Toggle (new Rect (Screen.width * UpgradeX, Screen.height * UpgradeY, Screen.width * .50f, Screen.height * .07f), bUpgrade, "", Upgrade)) {
			}
		} else {
			if (GUI.Button (new Rect (Screen.width * UpgradeX, Screen.height * UpgradeY, Screen.width * .50f, Screen.height * .07f), "", Upgrade)) {
				if (!showOn) {
					UpgradeMotion ();
				}
			}	
		}
		//
		if (GUI.Button (new Rect (Screen.width * ChangeLX, Screen.height * ChangeLY, Screen.width * .20f,Screen.height * .12f), "", ChangeL)) {
			if (!showOn) {
				cBuy = true;
				cUpgrade = true;
				if (ItemIDchose == 0) {	
					ItemIDchose = 7;	
				} else {	
					ItemIDchose -= 1;	
				}
				InShow = false;
			}
		}
		if (GUI.Button (new Rect (Screen.width * ChangeRX, Screen.height * ChangeRY, Screen.width * .20f,Screen.height * .12f), "", ChangeR)) {
			if (!showOn) {
				cBuy = true;
				cUpgrade = true;
				if (ItemIDchose == 7) {	
					ItemIDchose = 0;
				} else {
					ItemIDchose += 1;	
				}
				InShow = false;
			}
		}
		//
		if (GUI.Button (new Rect (Screen.width * BackX, Screen.height * BackY, Screen.width * .40f,Screen.height * .08f), "", Back)) {
			if (!showOn) {
				GameSL.AutoSave = true;
				Application.LoadLevel (1);
			}
		}
		//
	}
	void BuyMotion(){
		showOn = true;
		Instantiate (BuyM, new Vector3 (0.0f, 1.0f, 0.0f), Quaternion.identity);
	}
	void UpgradeMotion(){
		showOn = true;
		Instantiate (UpgradeM, new Vector3 (0.0f, 1.0f, 0.0f), Quaternion.identity);	
	}
	void CheckLevel(){
		switch (ItemIDchose) {
		case 0:
			ItemCheckLv = itemInfo.treasureLv;
			break;
		case 1:
			ItemCheckLv = itemInfo.livebuttonLv;
			break;
		case 2:
			ItemCheckLv = itemInfo.bombLv;
			break;
		case 3:
			ItemCheckLv = itemInfo.magnetLv;
			break;
		case 4:
			ItemCheckLv = itemInfo.superstarLv;
			break;
		case 5:
			ItemCheckLv = itemInfo.energyLv;
			break;
		case 6:
			ItemCheckLv = itemInfo.timestopLv;
			break;
		case 7:
			ItemCheckLv = 0;
			break;
		}
	}
}
