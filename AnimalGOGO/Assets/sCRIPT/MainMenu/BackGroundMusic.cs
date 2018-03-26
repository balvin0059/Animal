using UnityEngine;
using System.Collections;

public class BackGroundMusic : MonoBehaviour {
	public static int acount = 0;
	AudioSource audio;
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this.gameObject);
		audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		audio.volume = 0.2f * (float)MusicAudio.musicA;
		if(acount >= 2){
			GameObject.Destroy(gameObject);
		}
	}
}
