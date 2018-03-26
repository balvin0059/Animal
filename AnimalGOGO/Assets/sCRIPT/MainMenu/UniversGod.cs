using UnityEngine;
using System.Collections;

public class UniversGod : MonoBehaviour {
	public class PlayerStates
	{
		public int CharacterID;
		public int Playerexp;
		public int Playerkillnum;
		public int starLevel;
		public float atk;
		public float sped; 
		public float aspd;
		public int health;
		public PlayerStates(int id, int exp, int kill,int sl, float atks,float sed, float aspds, int hp){
			CharacterID = id;
			Playerexp = exp;
			Playerexp = kill;
			starLevel = sl;
			atk = atks;
			sped = sed;
			aspd = aspds;
			health = hp;
		}	
	}
	static public bool levelUP = false;
	static public PlayerStates player_mouse = new PlayerStates (0, 0, 0, 0, 1.0f, 0.033f, 1.2f, 12);
	static public PlayerStates player_ox = new PlayerStates (1, 0, 0, 0, 1.2f, 0.032f, 1.0f, 14);
	static public PlayerStates player_dragon = new PlayerStates (2, 0, 0, 0, 1.0f, 0.0325f, 1.0f, 12);
	static public PlayerStates player_snake = new PlayerStates (3, 0, 0, 0, 0.6f, 0.36f, 1.5f, 12);
	static public PlayerStates player_cock = new PlayerStates (4, 0, 0, 0, 1.0f, 0.0325f, 0.8f, 10);
	static public PlayerStates player_dog = new PlayerStates (5, 0, 0, 0, 1.0f, 0.0325f, 1.2f, 10);
	static public PlayerStates player_pig = new PlayerStates (6, 0, 0, 0, 1.2f, 0.0325f, 1.0f, 12);
	static public PlayerStates player_tiger = new PlayerStates (7, 0, 0, 0, 1.5f, 0.031f, 0.8f, 14);

	static public bool GodOnLive = false;
	//
	static public bool DestroyGame = false;
	static public bool GamePause = false;
	//
	static public int Player_Health = 10;
	static public int Player_HealthMax = 0;
	static public float Player_Speed = 0.0f;
	static public int Player_Anger = 0;
	static public int Player_AngerMax = 20;
	static public float Player_AttackDmg = 1.0f;
	static public int Player_ASLevel = 0;
	static public int[] Player_Exp;
	static public int KillNum = 0;
	//
	static public int AliveFeather = 9999;
	//
	static public int ItemLiveButtom = 5000;
	static public int ItemBomb = 10;
	static public int ItemSuperStar = 0;
	static public int ItemTimeStop = 500;

	static public int ItemLiveButtomLv = 0;
	static public int ItemBombLv = 0;
	static public int ItemSuperStarLv = 0;
	static public int ItemTimeStopLv = 0;
	//
	static public int Coin = 100000;
	//
	static public int NowLevelNum = 0;
	//
	static public int BuyLive = 0;
	static public int BuyShield = 0;
	static public int BuySpeed = 0;
	static public int BuyAttack = 0;
	//
	static public bool ShieldActive = false;
	static public bool SpeedActive = false;
	static public bool AttackDmgUP = false;
	//
	static public bool BombActive = false;
	static float BombKTime = 3.0f;
	static float BombCDTime = 20.0f;
	static public bool SuperStarActive = false;
	static float SuperStarKTime = 3.0f;
	static float SuperStarCDTime = 30.0f;
	static public bool TimeStopActive = false;
	static float TimeStopKTime = 3.0f;
	static float TimeStopCDTime = 60.0f;
	//
	static public bool ItemContrl_Magnet = false;

	float EventTimeCheck;
	static public float TimeCDMagnent = 5.0f;
	static public int NowMaxHp = 10;
	/// <summary>
	static public float[] Boss_heath;
	static public float[] Boss_heathMax;
	/// </summary>
	static public bool Boss_Display = false;
	static public bool StageShow = false;

	// Use this for initialization
	void Start () {
		GodOnLive = true;
		DontDestroyOnLoad(this.gameObject);

		Boss_heath = new float[3];
		Boss_heathMax = new float[3];
		Boss_heath [0] = 10.0f;
		Boss_heath [1] = 30.0f;
		Boss_heath [2] = 50.0f;
		Boss_heathMax [0] = 10.0f;
		Boss_heathMax [1] = 30.0f;
		Boss_heathMax [2] = 50.0f;
	}
	void LevelUP(){
		int a = Character.LevelChos;
		switch (a) {
		case 0:
			UniversGod.player_mouse.starLevel += 1;
			UniversGod.player_mouse.health += 2;
			break;
		case 1:
			UniversGod.player_ox.starLevel += 1;
			UniversGod.player_ox.health += 2;
			break;
		case 2:
			UniversGod.player_tiger.starLevel += 1;
			UniversGod.player_tiger.health += 2;
			break;
		case 3:
			UniversGod.player_dragon.starLevel += 1;
			UniversGod.player_dragon.health += 2;
			break;
		case 4:
			UniversGod.player_snake.starLevel += 1;
			UniversGod.player_snake.health += 2;
			break;
		case 5:
			UniversGod.player_cock.starLevel += 1;
			UniversGod.player_cock.health += 2;
			break;
		case 6:
			UniversGod.player_dog.starLevel += 1;
			UniversGod.player_dog.health += 2;
			break;
		case 7:
			UniversGod.player_pig.starLevel += 1;
			UniversGod.player_pig.health += 2;
			break;		
		}
		levelUP = false;
	}
	// Update is called once per frame
	void Update () {
		if (levelUP == true) {			LevelUP();		}
		GetItemLv ();
		if (BombActive) {
			if (BombKTime <= 0) {	BombKTime = 3.0f;	Player_AttackDmg = 0.6f;	}else{	BombKTime -= Time.deltaTime;	}
			if (BombCDTime <= 0) {	BombCDTime = 20.0f;	BombActive = false;	}else{	BombCDTime -= Time.deltaTime;	}
		}
		if (SuperStarActive) {
			if (SuperStarKTime <= 0) {	SuperStarKTime = 3.0f;	}else{	SuperStarKTime -= Time.deltaTime;	}
			if (SuperStarCDTime <= 0) {	SuperStarCDTime = 30.0f;	SuperStarActive = false;	}else{	SuperStarCDTime -= Time.deltaTime;	}
		}
		if (TimeStopActive) {
			if (TimeStopKTime <= 0) {	TimeStopActive = false;}else{	TimeStopKTime -= Time.deltaTime;	}
			if (TimeStopCDTime <= 0) {	TimeStopCDTime = 60.0f;	TimeStopActive = false;	}else{	TimeStopCDTime -= Time.deltaTime;	}
		}
		if (ItemContrl_Magnet) {
			if (TimeCDMagnent <= 0.0f) {
				ItemContrl_Magnet = false;
				TimeCDMagnent = 5.0f + (float)itemInfo.magnetLv*0.6f;
			} else {
				TimeCDMagnent -= Time.deltaTime;
			}
		}

		if (DestroyGame) {
			Player_Health = 10;
			GamePause = false;
			DestroyGame = false;
		}
	}
	void GetItemLv(){
		ItemLiveButtomLv = itemInfo.livebuttonLv;
		ItemBombLv = itemInfo.bombLv;
		ItemSuperStarLv = itemInfo.superstarLv;
		ItemTimeStopLv = itemInfo.timestopLv;
	}
	static public void BombEvent(){
		BombKTime = (float)3.0f + (ItemBombLv * 0.2f);
		BombActive = true;
		if (ItemBombLv > 0) {
			Player_AttackDmg = Player_AttackDmg + ItemBombLv + 1;
		} else {	Player_AttackDmg = 1;	}
	}
	static public void SuperStarEvent(){
		SuperStarKTime = (float)3.0f + ItemSuperStarLv;
		SuperStarActive = true;
	}
	static public void TimeStopEvent(){
		TimeStopKTime = (float)3.0f + (ItemTimeStopLv * 0.2f);
		TimeStopActive = true;
	}

}
