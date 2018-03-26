using UnityEngine;
using System.Collections;

public class LoadSence : MonoBehaviour {
	public string levelToload;
	public int leveltoload;

	// Use this for initialization

	void Start () {
		StartCoroutine (DisplayLoadingScreen (leveltoload));
	}
	
	// Update is called once per frame
	void Update () {
	}
	void nExtLevEl(){
		Application.LoadLevel (1);
		Destroy (gameObject);
	}

	IEnumerator DisplayLoadingScreen(int level){

		AsyncOperation async = Application.LoadLevelAsync (leveltoload);
		while (!async.isDone) {
			yield return null;
		}
	}
}
