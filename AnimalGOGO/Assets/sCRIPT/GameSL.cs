using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameSL : MonoBehaviour {

	public static bool AutoSave;
	float Ti;

	// Use this for initialization
	void Awake(){
		Load ();
		DontDestroyOnLoad (this.gameObject);
	}
	// Update is called once per frame
	void Update () {

		Ti -= Time.deltaTime;

		if (AutoSave) {
			Save ();
			AutoSave = false;
		}

		if (Ti <= 0) {			
			AutoSave = true;
			Ti = 60.0f;
		}

	
	}
	public void Save(){

		BinaryFormatter binary = new BinaryFormatter ();
		FileStream fStream = File.Create (Application.persistentDataPath + "/saveFile.sav");

		SaveManager saver = new SaveManager ();
		saver.Coins = UniversGod.Coin;
		saver.Kills = UniversGod.KillNum;
		saver.Feather = UniversGod.AliveFeather;
		saver.CompleteLevel = UniversGod.NowLevelNum;

		saver.ItemLiveButtom = UniversGod.ItemLiveButtom;
		saver.ItemLiveButtomLv = UniversGod.ItemLiveButtomLv;

		saver.ItemSuperStar = UniversGod.ItemSuperStar;
		saver.ItemSuperStarLv = UniversGod.ItemSuperStarLv;

		saver.ItemSword = UniversGod.ItemBomb;
		saver.ItemSwordLv = UniversGod.ItemBombLv;

		saver.ItemTimeStop = UniversGod.ItemTimeStop;
		saver.ItemTimeStopLv = UniversGod.ItemTimeStopLv;
		//all want save

		binary.Serialize(fStream, saver);
		fStream.Close ();
	}
	public void Load(){
		if (File.Exists (Application.persistentDataPath + "/saveFile.sav"))
		{
			BinaryFormatter binary = new BinaryFormatter ();
			FileStream fStream = File.Open (Application.persistentDataPath + "/saveFile.sav", FileMode.Open);
			SaveManager saver = (SaveManager)binary.Deserialize(fStream);
			fStream.Close ();

			UniversGod.Coin = saver.Coins;
			UniversGod.KillNum = saver.Kills;
			UniversGod.AliveFeather = saver.Feather;
			UniversGod.NowLevelNum = saver.CompleteLevel;

			UniversGod.ItemTimeStop = saver.ItemTimeStop;
			UniversGod.ItemTimeStopLv = saver.ItemTimeStopLv;

			UniversGod.ItemBomb = saver.ItemSword;
			UniversGod.ItemBombLv = saver.ItemSwordLv;

			UniversGod.ItemSuperStar = saver.ItemSuperStar;
			UniversGod.ItemSuperStarLv = saver.ItemSuperStarLv;

			UniversGod.ItemLiveButtom = saver.ItemLiveButtom;
			UniversGod.ItemLiveButtomLv = saver.ItemLiveButtomLv;

		}

	}
}
[Serializable]
class SaveManager
{
	public int Coins;
	public int Kills;
	public int Feather;
	public int CompleteLevel;

	public int ItemLiveButtom;
	public int ItemSword;
	public int ItemSuperStar;
	public int ItemTimeStop;

	public int ItemLiveButtomLv;
	public int ItemSwordLv;
	public int ItemSuperStarLv;
	public int ItemTimeStopLv;
	// want save add 
	// int float bool string
	//vector 2 3 4 alllllllll values
}
