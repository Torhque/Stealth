using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static GameManager instance;
	public bool wasSpotted = false;

	void Awake () {
	}

	// Use this for initialization
	void Start () {
		Screen.lockCursor = false;	

		if (instance == null) {
			instance = this;
			DontDestroyOnLoad (this.gameObject);

			AudioManager.manager.musicPlayer.clip = AudioManager.manager.menuSong; // swap the songs
			AudioManager.manager.musicPlayer.Play (); // play the song

		} else {
			Destroy (this.gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {


	}
}