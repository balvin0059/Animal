using UnityEngine;
using System.Collections;

public class BossBar : MonoBehaviour {
	SpriteRenderer sr;
	public Sprite[] Sn;
	public float BossHealthDisplay;
	int BarToint;
	// Use this for initialization
	void Start () {
		sr = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		switch (UniversGod.NowLevelNum) {
		case 0:
			BossHealthDisplay = Monster_SlimeKing.Boss01_health;
			break;
		case 1:
			BossHealthDisplay = Level_02BossAI.Boss02_health;
			break;
		case 2:
			BossHealthDisplay = Level_03BossAI.Boss03_health;
			break;

		}
		BarToint = (int)Mathf.Ceil (BossHealthDisplay);

		sr.sprite = Sn[BarToint];
	}
}
