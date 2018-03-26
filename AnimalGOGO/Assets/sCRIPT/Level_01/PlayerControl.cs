using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {	
	static public bool[] cornor;
	static public Transform[] cornorTar;
	static public int[] cornorWay;
	static public int[] cornorWayAfter;
	static public int cornorTime = 0;
	int WayAfter = 0;

	public GameObject[] Partner_Set;
	public GameObject[] Partner_AttacK;
	public GameObject GameOVer;
	static public int EatPartner = 0;
	bool GameIsOver = false;
	static public int par = 0;
	//set
	static public float isped = 0.0f;
	public float speed = UniversGod.Player_Speed + isped;
	public float minSwipeDistY = 200.0f;	
	public float minSwipeDistX = 100.0f;	
	private Vector2 startPos;
	public int Way = 0;
	static public int PartnerWay = 0;
	int MovWay = 0;
	static public int Partner_Num;
	float OneStepX = 0.0f;
	float OneStepY = 0.0f;

	float MemoryX = 0.0f;
	float MemoryY = 0.0f;

	float RoundX = 0.0f;
	float RoundY = 0.0f;


	bool Memory = true;

	bool OnMoving = false;

	public float time = 0.0f;

	public float alarm = 5.0f;

	public AudioClip eat;
	AudioSource audio;
	//UP = 0
	//DOWN = 1
	//LEFT = 2
	//RIGHT = 3
	public Animator anim;

	// Use this for initialization
	void Start () {
		playerComputer.gethealth ();
		UniversGod.NowMaxHp = UniversGod.Player_Health;
		//set loading cornor
		cornor = new bool[4];
		cornorTar = new Transform[4];
		cornorWay = new int[4];
		cornorWayAfter = new int[4];
		//
		MemoryX = transform.position.x;
		MemoryY = transform.position.y;
		audio = GetComponent<AudioSource>();
	}
	// Update is called once per frame
	void Update () {		
		keycheck ();
		if (UniversGod.Player_Health <= 0) {
			GameOver ();
		}
		if (!UniversGod.GamePause) {
			if (!UniversGod.Boss_Display) {
				if (!UniversGod.StageShow) {
					alarm -= Time.deltaTime;
					if (alarm <= 0) {
						isped = 0;
					}
					anim.speed = 1;
					GameIsOver = false;
					speed = 0.04f + isped;
					time += Time.deltaTime;
					time = (float)System.Math.Round (time, 2);
					RoundX = (float)System.Math.Round (transform.position.x, 2);
					RoundY = (float)System.Math.Round (transform.position.y, 2);

					transform.position = new Vector3 (RoundX, RoundY, 0.0f);

					//moving
					OneStepX = MemoryX % 1.0f;
					OneStepY = MemoryY % 1.0f;
					//
					MemoryX = (float)System.Math.Floor (RoundX * 10);
					MemoryY = (float)System.Math.Floor (RoundY * 10);

					if (OneStepX == 0 || OneStepY == 0) {
						if (OnMoving) {
							Way = MovWay;
							OnMoving = false;
						}
					} 
					Moving ();
					///Touch to swpie event
					if (Input.touchCount > 0) {
						OnSwipe ();
					}
				} else {
					anim.speed = 0;
				}
			} else {
				anim.speed = 0;
			}
		} else {
				anim.speed = 0;
			}
		
	}
	void Moving(){//自動行走
		switch (Way) {
		case 0://Up
			anim.SetFloat("SpeedX",-0.5f);
			anim.SetFloat("SpeedY",0.5f);
			PartnerWay = 0;
			PlayerAttackRange.AttackWay = 0;
			transform.position += new Vector3 (0.0f, speed, 0.0f);
			if (Memory) {	Memory = false;	}
			break;
		case 1://Down
			anim.SetFloat("SpeedX",-0.5f);
			anim.SetFloat("SpeedY",-0.5f);
			PlayerAttackRange.AttackWay = 1;
			PartnerWay = 1;
			transform.position -= new Vector3 (0.0f, speed, 0.0f);
			if (Memory) {	Memory = false;	}
			break;
		case 2://Left
			anim.SetFloat("SpeedX",-1.0f);
			anim.SetFloat("SpeedY",0.0f);
			PlayerAttackRange.AttackWay = 2;
			PartnerWay = 2;
			transform.position -= new Vector3 (speed, 0.0f, 0.0f);
			if (Memory) {	Memory = false;	}
			break;
		case 3://Right
			anim.SetFloat("SpeedX",0.0f);
			anim.SetFloat("SpeedY",0.0f);
			PlayerAttackRange.AttackWay = 3;
			PartnerWay = 3;
			transform.position += new Vector3 (speed, 0.0f, 0.0f);
			if (Memory) {	Memory = false;	}
			break;
		}
	}
	void OnSwipe(){//滑動
		
		Touch touch = Input.touches[0];
		switch (touch.phase){				
		case TouchPhase.Began:				
			startPos = touch.position;
			float swipeDistVertical = (new Vector3(0, touch.position.y, 0) - new Vector3(0, startPos.y, 0)).magnitude;				
			if (swipeDistVertical > minSwipeDistY){					
				float swipeValue = Mathf.Sign(touch.position.y - startPos.y);					
				if (swipeValue > 0){
					if(Way != 1){
						WayAfter = Way;
						if (OneStepY < 0.4f){
							OnMoving = true; 
							MovWay = 0;
							LoadingCornor (MovWay);
						}else{Way = 0;
							LoadingCornor (Way);}
					}
				}//up swipe
				else if (swipeValue < 0){
					if(Way != 0){
						WayAfter = Way;
						if (OneStepY < 0.4f){
							OnMoving = true; 
							MovWay = 1;
							LoadingCornor (MovWay);
						}else{Way = 1;
							LoadingCornor (Way);}
					}
				}//down swipe
			}				
			float swipeDistHorizontal = (new Vector3(touch.position.x,0, 0) - new Vector3(startPos.x, 0, 0)).magnitude;				
			if (swipeDistHorizontal > minSwipeDistX){
				float swipeValue = Mathf.Sign(touch.position.x - startPos.x);
				if (swipeValue > 0){
					if(Way != 2){
						WayAfter = Way;
						if (OneStepX < 0.4f){
							OnMoving = true; 
							MovWay = 3;
							LoadingCornor (MovWay);
						}else{Way = 3;
							LoadingCornor (Way);}
					}
				}//right swipe
				else if (swipeValue < 0){
					if(Way != 3){
						WayAfter = Way;
						if (OneStepX < 0.4f){
							OnMoving = true; 
							MovWay = 2;
							LoadingCornor (MovWay);
						}else{Way = 2;
							LoadingCornor (Way);}
					}
				}//left swipe	
			}
			break;
		case TouchPhase.Ended:
			break;
		}

	}
	void keycheck (){
		if (Input.GetKeyDown ("up")) {
			if(Way != 1){
				WayAfter = Way;
				if (OneStepY < 0.4f){
					OnMoving = true; 
					MovWay = 0;
					LoadingCornor (MovWay);
				}else{Way = 0;
					LoadingCornor (Way);}
			}
		}
		if (Input.GetKeyDown ("down")) {
			if(Way != 0){
				WayAfter = Way;
				if (OneStepY < 0.4f){
					OnMoving = true; 
					MovWay = 1;
					LoadingCornor (MovWay);
				}else{Way = 1;
					LoadingCornor (Way);}
			}
		}
		if (Input.GetKeyDown ("right")) {
			if(Way != 2){
				WayAfter = Way;
				if (OneStepX < 0.4f){
					OnMoving = true; 
					MovWay = 3;
					LoadingCornor (MovWay);
				}else{Way = 3;
					LoadingCornor (Way);}
			}
		}
		if (Input.GetKeyDown ("left")) {
			if(Way != 3){
				WayAfter = Way;
				if (OneStepX < 0.4f){
					OnMoving = true; 
					MovWay = 2;
					LoadingCornor (MovWay);
				}else{Way = 2;
					LoadingCornor (Way);}
			}
		}
	}
	void GetItemID(int id){	

		audio.PlayOneShot(eat, 1.0f);

		float ax = 0.0f;
		float ay = 0.0f;
		float distance = 0.0f;
		distance = (float)0.5f+(Partner_Num*0.5f);
		if (Way == 0) {
			ax = RoundX;
			ay = RoundY - distance;
		}
		if (Way == 1) {
			ax = RoundX;
			ay = RoundY + distance;
		}
		if (Way == 2) {
			ax = RoundX + distance;
			ay = RoundY;
		}
		if (Way == 3) {
			ax = RoundX - distance;
			ay = RoundY;
		}

		if (id < 11 && id >= 4) {
			if (Partner_Num < 4) {
				par = SummonPartner (id);
				Instantiate (Partner_Set [par], new Vector3 (ax, ay, 0.0f), Quaternion.identity);
				EatPartner = id + 1;
				Partner_Num += 1;
				Drop.PartnerItem (id);
			}
		} else if (id == 3) {
			
		}else{
			Drop.FindItem (id);
		}


	}
	int SummonPartner(int s){
		switch(s){
		case 4:
			return 0;
			break;
		case 5:
			return 1;
			break;
		case 6:
			return 2;
			break;
		case 7:
			return 3;
			break;
		case 8:
			return 4;
			break;
		case 9:
			return 5;
			break;
		case 10:
			return 6;
			break;
		default:
			return 0;
			break;
		}
	}

	void OnTriggerEnter2D(Collider2D col){//碰撞
		if (col.gameObject.tag == "Area_Poison") {
			UniversGod.Player_Health -= 1;
		}

		if (col.gameObject.tag == "Wall") {
			UniversGod.Player_Health = 0;
		}
		if (col.gameObject.tag == "Item_Partner") {
			
		}
	}
	void ApplyDamage(int dmg){
		UniversGod.Player_Health -= dmg;
	}
	void GameOver(){
		if (GameIsOver == false) {
			speed = 0;
			transform.position = new Vector3 (0.0f, 0.02f, 0.0f);
			Instantiate (GameOVer, transform.position, Quaternion.identity);
			GameIsOver = true;
			UniversGod.GamePause = true;
		}
	}

	void LoadingCornor(int b){
		if (Partner_Num > 0) {
			cornorTime += Partner_Num;
			for (int a = 0; a < 4; a++) {
				if (!cornor [a]) {
					cornorWayAfter [a] = WayAfter;
					cornorTar [a] = gameObject.transform;
					cornorWay [a] = b;
					cornor [a] = true;
					break;
				}
			}
		}
	}
}
