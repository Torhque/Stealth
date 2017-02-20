﻿using UnityEngine;
using System.Collections;

public class PlainKey : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// Set the appropriate boolean to true, play the associated sound clip, and then have it destroy itself since it is a pickup
	void OnTriggerEnter () {
		PlayerData.instance.hasPlainKey = true;
		AudioSource.PlayClipAtPoint (AudioManager.manager.plainKeySound, gameObject.GetComponent<Transform>().position, 0.5f);
		Destroy (gameObject);
	}
}
