using UnityEngine;
using System.Collections;

public class UpgradeMotionUI_showItem : MonoBehaviour {
	public GameObject[] Caption_SecUp;
	public GameObject[] Caption_rangeup;
	public GameObject[] Caption_NumUp;

	public int UpgradeLevel = 0;
	public int ItemIDCheck = 0;

	// Use this for initialization
	void Start () {
		ItemIDCheck = itemInfo.ItemIDInfo;
		switch(ItemIDCheck){
		case 0:
			itemInfo.ItemIDInfo = 0;				
				Instantiate (Caption_NumUp [0], new Vector3 (0.0f, 2.5f, 0.0f), Quaternion.identity);
			break;
		case 1:
			itemInfo.ItemIDInfo = 1;
				Instantiate (Caption_NumUp [0], new Vector3 (0.0f, 2.5f, 0.0f), Quaternion.identity);
			break;
		case 2:
			itemInfo.ItemIDInfo = 2;
			Instantiate (Caption_rangeup [0], new Vector3 (0.0f, 2.5f, 0.0f), Quaternion.identity);
			break;
		case 3:
			itemInfo.ItemIDInfo = 3;
				Instantiate (Caption_SecUp [0], new Vector3 (0.0f, 2.5f, 0.0f), Quaternion.identity);
			break;
		case 4:
			itemInfo.ItemIDInfo = 4;
				Instantiate (Caption_SecUp [0], new Vector3 (0.0f, 2.5f, 0.0f), Quaternion.identity);
			break;
		case 5:
			itemInfo.ItemIDInfo = 5;
				Instantiate (Caption_NumUp [0], new Vector3 (0.0f, 2.5f, 0.0f), Quaternion.identity);
			break;
		case 6:
			itemInfo.ItemIDInfo = 6;
				Instantiate (Caption_SecUp [0], new Vector3 (0.0f, 2.5f, 0.0f), Quaternion.identity);
			break;
		case 7:
			itemInfo.ItemIDInfo = 7;
			break;
		}

	}

	// Update is called once per frame
	void Update ()
	{

	}
}
