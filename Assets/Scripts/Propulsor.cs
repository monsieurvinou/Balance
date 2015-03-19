using UnityEngine;
using System.Collections;

public class Propulsor : MonoBehaviour {
	public Vector3 propulsionForce = new Vector3(0, 10000, 0);
	public float timeOffset = 0.25f;
	public Color transitionColor = new Color(0.5f, 0.5f, 0.5f, 0.1f);


	void OnTriggerEnter (Collider other) {
		if (other.tag == "Player") {
			iTween.ColorTo(gameObject, transitionColor, timeOffset);
			Invoke("Propulse", timeOffset);
		}
	}

	public void Propulse() {
		AudioSource audioPropulsor = GameObject.Find ("PropulsorSound").GetComponent<AudioSource> ();
		if (audioPropulsor != null) {
			audioPropulsor.volume = PlayerPrefs.GetFloat("SFX");
			audioPropulsor.Play();
		}
		GameObject[] players = GameObject.FindGameObjectsWithTag ("Player");
		foreach (GameObject ball in players) {
			iTween.ColorTo(gameObject, new Color(1,1,1,1), timeOffset);
			ball.rigidbody.AddForce(propulsionForce);
		}
	}
}
