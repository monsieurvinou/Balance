using UnityEngine;
using System.Collections;

public class PlayerBall : MonoBehaviour {
	void Start() {
		audio.volume = PlayerPrefs.GetFloat ("SFX");
	}
	void OnCollisionEnter(Collision collision) {
		foreach (ContactPoint contact in collision.contacts) {
			Debug.DrawRay(contact.point, contact.normal, Color.white);
		}
		if (collision.relativeVelocity.magnitude > 4)
			audio.Play();
	}

}
