using UnityEngine;
using System.Collections;

public class LockedKeypadDoor : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// If the meet the requirement, unlock the door. Otherwise, play the associated lock sound
	void OnTriggerEnter () {
		if (PlayerData.instance.hasKeyCode == true) {
			AudioSource.PlayClipAtPoint (AudioManager.manager.openKeypadDoorSound, gameObject.GetComponent<Transform>().position, 1.0f);
			Destroy (gameObject);
		} else {
			AudioSource.PlayClipAtPoint (AudioManager.manager.lockedKeypadDoorSound, gameObject.GetComponent<Transform>().position, 1.0f);
		}
	}
}
