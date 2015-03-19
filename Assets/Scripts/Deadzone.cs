using UnityEngine;
using System.Collections;

public class Deadzone : MonoBehaviour {
	void OnTriggerEnter (Collider other) {
		if (!GameObject.Find ("Timer").GetComponent<TimerBalance> ().finished) {
			GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("SFX");
			GetComponent<AudioSource>().Play();
			AutoFade.LoadLevel (Application.loadedLevelName,2.5f,0.5f, Color.black);
		}
	}
}
