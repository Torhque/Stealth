using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TryAgainButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Load the player at the beginning of the level when the click Try Again
	void OnMouseUp () {
		SceneManager.LoadScene ("Level"); 
		AudioManager.manager.musicPlayer.clip = AudioManager.manager.levelSong; // swap the songs
		AudioManager.manager.musicPlayer.Play (); // play the song
	}
}
