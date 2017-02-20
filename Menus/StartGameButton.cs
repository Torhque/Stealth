using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartGameButton : MonoBehaviour {

	// Use this for initialization
	void Start () {		
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// Load the level when the user clicks Start Game
	void OnMouseUp () {

		SceneManager.LoadScene ("Level");
		AudioManager.manager.musicPlayer.clip = AudioManager.manager.levelSong; // swap the songs
		AudioManager.manager.musicPlayer.Play (); // play the song
	}
}
