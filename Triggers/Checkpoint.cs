using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void OnTriggerEnter () {

		// Set the player's spawn point to the checkpoint's location because that's what the checkpoint should do
		PlayerData.spawnPoint = gameObject.GetComponent<Transform> ().position;
	}
}