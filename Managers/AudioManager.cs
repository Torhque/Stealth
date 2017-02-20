using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {

	public static AudioManager manager;

	// Music clips
	public AudioClip menuSong;
	public AudioClip levelSong;
	public AudioClip deathSong;
	public AudioClip winSong;
	public AudioClip failSong;
	public AudioSource musicPlayer; // AudioSource object for storing and swapping songs

	// Pickup SFX
	public AudioClip plainKeySound;
	public AudioClip keyCardSound;
	public AudioClip keyPadSound;
	public AudioClip secretFilesSound;

	// Door SFX
	public AudioClip openMetalDoorSound;
	public AudioClip lockedMetalDoorSound;
	public AudioClip openWoodenDoorSound;
	public AudioClip lockedWoodenDoorSound;
	public AudioClip openKeypadDoorSound;
	public AudioClip lockedKeypadDoorSound;

	void Awake () {
		if (manager == null) {
			manager = this;

			// Don't destroy this AudioManager!
			DontDestroyOnLoad (gameObject);
		} else {
			Destroy (gameObject);
		}
	}

	// Use this for initialization
	void Start () {
		musicPlayer = GetComponent<AudioSource> ();
	}

	// Update is called once per frame
	void Update () {
		
	}
}