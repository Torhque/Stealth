using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ReturnToMainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// Return to the Main Menu when the player clicks this button
	void OnMouseUp () {
		SceneManager.LoadScene ("Main Menu");
		AudioManager.manager.musicPlayer.clip = AudioManager.manager.menuSong; // swap the songs
		AudioManager.manager.musicPlayer.Play (); // play the song
	}
}
