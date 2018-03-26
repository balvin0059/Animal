using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class healthbar : MonoBehaviour {

	public Scrollbar mylifebar;
	public float health; 
	public float m;
	// Use this for initialization
	void Start () {
		health = (float)UniversGod.Player_Health;
		m = (float)UniversGod.NowMaxHp;
	}
	
	// Update is called once per frame
	void Update () {
		health = (float)UniversGod.Player_Health;
		mylifebar.size = health/m;
	}
}
