using UnityEngine;
using System.Collections;

public class ShowBG : MonoBehaviour {
	SpriteRenderer sr;
	public Sprite LevelOne;
	public Sprite LevelTwo;
	public Sprite LevelTree;
	public int ShowNum = 0;
	// Use this for initialization
	void Start () {
		ShowNum = UniversGod.NowLevelNum;
		sr = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		switch (ShowNum) {
		case 0:
			sr.sprite = LevelOne;
			break;
		case 1:
			sr.sprite = LevelTwo;
			break;
		case 2:
			sr.sprite = LevelTree;
			break;
		}
	}
}
