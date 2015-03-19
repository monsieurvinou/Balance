using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class MenuSounds : MonoBehaviour {
	public AudioClip OnFocusSound;
	public AudioClip OnSelectSound;

	void Start() {
		audio.volume = PlayerPrefs.GetFloat ("SFX");
	}

	public void Focus() {
		audio.clip = OnFocusSound;
		audio.Play ();
	}

	public void Select() {
		audio.clip = OnSelectSound;
		audio.Play ();
	}

}
