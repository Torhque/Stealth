using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerData : MonoBehaviour {

	public static PlayerData instance;

	public GameObject player;
	public static Vector3 spawnPoint;
	public GameObject deathScreen;

	// Booleans for storing which pickup the player has
	public bool hasKeyCard;
	public bool hasPlainKey;
	public bool hasKeyCode;
	public bool hasSecretFiles;

	// Life sprites displayed for a visual repsentation of lives left
	[HideInInspector]public int numLives = 3;
	public GameObject [] lifeSprites;

	// Use this for initialization
	void Start () {
		instance = this;
		PlayerData.spawnPoint = GetComponent<Transform> ().position;
		deathScreen.SetActive (false); // Disable the death screen since the player isn't dead yet
	}

	// Update is called once per frame
	void Update () {

		// Check if number lives is greater than zero
		// Set lifeSprite to active if true, disable if false
		for (int i = 0; i < lifeSprites.Length; i++) {
			if (numLives > i) {
				lifeSprites [i].SetActive (true);
			} else {
				lifeSprites [i].SetActive (false);
			}
		}

		if (numLives == 0) {

			SceneManager.LoadScene ("Failure Scene");
			AudioManager.manager.musicPlayer.clip = AudioManager.manager.failSong; // swap the songs
			AudioManager.manager.musicPlayer.Play (); // play the song
			numLives = 3; // Reset the number of lives since they've failed and will restart
		}

	}
}
