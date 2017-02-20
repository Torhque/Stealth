using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class AIController : MonoBehaviour {

	[HideInInspector] public Transform tf;
	[HideInInspector] public Renderer render;

	public Material hearMaterial;
	public Material seenMaterial;
	public Material defaultMaterial;
	public float maxRotateSpeed;
	public float hearingRadius;
	public AudioSource alarmPlayer; // Create audio source, so the AI can store its own sound
	public AudioClip heardSound;
	public AudioClip spottedSound;

	public float fieldOfView = 60.0f; // Degress from center that the AI can see
	public float viewDistance = 10.0f; // How far the AI can see


	// Use this for initialization
	void Start () {
		render = GetComponent<Renderer> ();
		tf = GetComponent<Transform> ();

		alarmPlayer = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {

		// If I can hear the player
		if (CanHear (PlayerData.instance.player)) {
			
			render.material = hearMaterial; // Turn yellow once the player can be heard

			// Play heardSound since player can be heard
			if (alarmPlayer.isPlaying == false) { // Only play if you're not already playing
				alarmPlayer.clip = heardSound; // Assign the appropriate sound to the alarmPlayer
				alarmPlayer.Play ();
			}

			// Turn towards the player
			Quaternion targetRotation;
			Transform playerTransform = PlayerData.instance.player.GetComponent<Transform> ();
			targetRotation = Quaternion.LookRotation (playerTransform.position - tf.position);
			tf.rotation = Quaternion.RotateTowards (tf.rotation, targetRotation, maxRotateSpeed);
		
			// If I can see the player
			if (CanSee (PlayerData.instance.player)) {
				
				render.material = seenMaterial; // Turn red once the player can be seen
				GameManager.instance.wasSpotted = true; // Store the spotted state, so I can access it elsewhere

				// Tell the player to "die" (it is technically teleporting the player back to their recent checkpoint)
				PlayerData pd = PlayerData.instance.player.gameObject.GetComponent<PlayerData> ();

				if (pd != null) {

//					// Bring up the death scene since the player was spotted.
//					GameManager.instance.wasSpotted = true;
//					PlayerData.instance.deathScreen.SetActive (true);

					alarmPlayer.clip = spottedSound; // Swap the appropriate sound to the alarmPlayer
					// Only play if you're not already playing
					if (alarmPlayer.isPlaying == false) {
						alarmPlayer.Play ();
					}

					AudioManager.manager.musicPlayer.clip = AudioManager.manager.deathSong; // swap the songs

					// Play the death track since they were spotted
					if (AudioManager.manager.musicPlayer.isPlaying == false) {						
						AudioManager.manager.musicPlayer.Play (); // play the song
					}

//					if (Input.GetKeyDown (KeyCode.Space) ) {
//						PlayerData.instance.deathScreen.SetActive (false); // Disable death screen
//
//						// Teleport once spotted line
//						PlayerData.instance.player.gameObject.GetComponent<Transform> ().position = PlayerData.spawnPoint;
//						PlayerData.instance.numLives--; // Remove a life since the player was spotted
//
//						// Begin the level song again since they've respawned
//						AudioManager.manager.musicPlayer.clip = AudioManager.manager.levelSong; // swap the songs
//						AudioManager.manager.musicPlayer.Play (); // play the song
//					}
				} else {
					Destroy (PlayerData.instance.player.gameObject);
				}
			}
		}

		// Else, can't detect player
		else {
			alarmPlayer.Stop (); // Stop the spotted alarm once the player cannot be seen anymore
			render.material = defaultMaterial;
		}

		if (GameManager.instance.wasSpotted == true) {
			// Bring up the death scene since the player was spotted.
			PlayerData.instance.deathScreen.SetActive (true);

			if (Input.GetKeyDown (KeyCode.Space) ) {
				PlayerData.instance.deathScreen.SetActive (false); // Disable death screen
				GameManager.instance.wasSpotted = false; // Set wasSpotted back to false since they've "respawned"

				// Teleport to most recent checkpoint
				PlayerData.instance.player.gameObject.GetComponent<Transform> ().position = PlayerData.spawnPoint;
				PlayerData.instance.numLives--; // Remove a life since the player was spotted

				// Begin the level song again since they've respawned
				AudioManager.manager.musicPlayer.clip = AudioManager.manager.levelSong; // swap the songs
				AudioManager.manager.musicPlayer.Play ();
			}
		}
	}

	public bool CanSee (GameObject target) {
		
		Vector3 vectorToTarget = target.GetComponent<Transform>().position - tf.position; // Vector from target
		float angleToTarget = Vector3.Angle(tf.forward, vectorToTarget);

		// If target is within FOV
		if (angleToTarget <= fieldOfView) {

			// Define the ray by storing an empty Ray() into the new Ray object. Used to check for obstructions
			Ray theRay = new Ray(); 
			theRay.origin = tf.position;
			theRay.direction = tf.forward;

			RaycastHit hitInfo;

			// AND if they are within our view distance
			if (Physics.Raycast(theRay, out hitInfo, viewDistance)) {

				// AND, if the first thing our raycast hits is our target
				if (hitInfo.collider.gameObject == target) {

					// Then I can see the target
					// Debug.Log ("I see something");
					return true;
				}
			}
		}
		// else
		return false;
	}

	public bool CanHear ( GameObject target ) {
		// If we are in range
		if (Vector3.Distance (tf.position, target.GetComponent<Transform> ().position) < hearingRadius) {
			
			// AND, they are making noise
			NoiseMaker targetNoiseMaker = target.GetComponent<NoiseMaker>();
			if (targetNoiseMaker.isMakingNoise) {
				return true;
			}
		}
		// else
		return false;
	}

}
