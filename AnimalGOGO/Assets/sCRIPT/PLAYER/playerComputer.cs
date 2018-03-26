using UnityEngine;
using System.Collections;

public class playerComputer : MonoBehaviour {
	static int a;
	// Use this for initialization
	void Start () {
		a = Character.LevelChos;
	}
	
	// Update is called once per frame
	void Update () {
		a = Character.LevelChos;

	}
	static public void killmonster(){
		switch (a) {
		case 0:
			UniversGod.player_mouse.Playerexp += 1;
			UniversGod.player_mouse.Playerkillnum += 1;
			break;
		case 1:
			UniversGod.player_ox.Playerexp += 1;
			UniversGod.player_ox.Playerkillnum += 1;
			break;
		case 2:
			UniversGod.player_tiger.Playerexp += 1;
			UniversGod.player_tiger.Playerkillnum += 1;
			break;
		case 3:
			UniversGod.player_dragon.Playerexp += 1;
			UniversGod.player_dragon.Playerkillnum += 1;
			break;
		case 4:
			UniversGod.player_snake.Playerexp += 1;
			UniversGod.player_snake.Playerkillnum += 1;
			break;
		case 5:
			UniversGod.player_cock.Playerexp += 1;
			UniversGod.player_cock.Playerkillnum += 1;
			break;
		case 6:
			UniversGod.player_dog.Playerexp += 1;
			UniversGod.player_dog.Playerkillnum += 1;
			break;
		case 7:
			UniversGod.player_pig.Playerexp += 1;
			UniversGod.player_pig.Playerkillnum += 1;
			break;		
		}
	}
	static public void gethealth(){
		if (Character.LevelChos == 0) {
			UniversGod.Player_Health = UniversGod.player_mouse.health+UniversGod.Player_HealthMax;
				UniversGod.Player_Speed = UniversGod.player_mouse.sped;
				UniversGod.Player_AttackDmg = UniversGod.player_mouse.atk;
		} else if (Character.LevelChos == 1) {
			UniversGod.Player_Health = UniversGod.player_ox.health+UniversGod.Player_HealthMax;
				UniversGod.Player_Speed = UniversGod.player_ox.sped;
			UniversGod.Player_AttackDmg = UniversGod.player_mouse.atk;
		} else if (Character.LevelChos == 2) {
			UniversGod.Player_Health = UniversGod.player_tiger.health+UniversGod.Player_HealthMax;
				UniversGod.Player_Speed = UniversGod.player_tiger.sped;
			UniversGod.Player_AttackDmg = UniversGod.player_tiger.atk;
		} else if (Character.LevelChos == 3) {
			UniversGod.Player_Health = UniversGod.player_dragon.health+UniversGod.Player_HealthMax;
			UniversGod.Player_Speed = UniversGod.player_dragon.sped;
			UniversGod.Player_AttackDmg = UniversGod.player_dragon.atk;
		} else if (Character.LevelChos == 4) {
			UniversGod.Player_Health = UniversGod.player_snake.health+UniversGod.Player_HealthMax;
			UniversGod.Player_Speed = UniversGod.player_snake.sped;
			UniversGod.Player_AttackDmg = UniversGod.player_snake.atk;
		} else if (Character.LevelChos == 5) {
			UniversGod.Player_Health = UniversGod.player_cock.health+UniversGod.Player_HealthMax;
			UniversGod.Player_Speed = UniversGod.player_cock.sped;
			UniversGod.Player_AttackDmg = UniversGod.player_cock.atk;
		} else if (Character.LevelChos == 6) {
			UniversGod.Player_Health = UniversGod.player_dog.health+UniversGod.Player_HealthMax;
			UniversGod.Player_Speed = UniversGod.player_dog.sped;
			UniversGod.Player_AttackDmg = UniversGod.player_dog.atk;
		} else if (Character.LevelChos == 7) {
			UniversGod.Player_Health = UniversGod.player_pig.health+UniversGod.Player_HealthMax;
			UniversGod.Player_Speed = UniversGod.player_pig.sped;
			UniversGod.Player_AttackDmg = UniversGod.player_pig.atk;
		}
	}
}
