using UnityEngine;
using System.Collections;

public class LockedWoodenDoor : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// If the meet the requirement, unlock the door. Otherwise, play the associated lock sound
	void OnTriggerEnter () {
		if (PlayerData.instance.hasPlainKey == true) {
			AudioSource.PlayClipAtPoint (AudioManager.manager.openWoodenDoorSound, gameObject.GetComponent<Transform>().position, 1.0f);
			Destroy (gameObject);
		} else {
			AudioSource.PlayClipAtPoint (AudioManager.manager.lockedWoodenDoorSound, gameObject.GetComponent<Transform>().position, 1.0f);
		}
	}
}
