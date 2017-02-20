using UnityEngine;
using System.Collections;

public class DeathTrigger : MonoBehaviour {

	public GameObject deathScreen;

	// Use this for initialization
	void Start () {
		

	}

	// Update is called once per frame
	void Update () {

	}

	public void OnTriggerEnter () {

		// Display the death screen canvas when the player is "killed"
		deathScreen.SetActive (true);
	}
}