using UnityEngine;
using System.Collections;

public class gameoveraudio : MonoBehaviour {
	public GameObject gmovrbox;
	AudioSource audio;
	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		audio.volume = 0.2f * (float)MusicAudio.musicA;
		if (GameOver.ggmsc) {
			Destroy (gameObject);
			Instantiate (gmovrbox, new Vector3 (0.0f, 0.0f, 0.0f), Quaternion.identity);
		}
	}
}
