using UnityEngine;
using System.Collections;

public class SecretFiles : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// Set the appropriate boolean to true, play the associated sound clip, and then have it destroy itself since it is a pickup
	void OnTriggerEnter () {
		PlayerData.instance.hasSecretFiles = true;
		AudioSource.PlayClipAtPoint (AudioManager.manager.secretFilesSound, gameObject.GetComponent<Transform>().position, 1.0f);
		Destroy (gameObject);
	}
}
