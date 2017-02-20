using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Extraction : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter () {
		if (PlayerData.instance.hasSecretFiles == true) {
			SceneManager.LoadScene ("Victory Scene");
			AudioManager.manager.musicPlayer.clip = AudioManager.manager.winSong; // swap the songs
			AudioManager.manager.musicPlayer.Play (); // play the song
		}
	}
}
