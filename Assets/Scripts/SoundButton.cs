using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;

public class SoundButton : MonoBehaviour, ISelectHandler, ISubmitHandler {
	static MenuSounds soundManager;

	void Start() {
		if (SoundButton.soundManager == null) {
			SoundButton.soundManager = GameObject.Find("SoundManagerMenu").GetComponent<MenuSounds>();
		}
	}
	
	public void OnSelect(BaseEventData eventData) {
		SoundButton.soundManager.Focus ();
	}
	
	public void OnSubmit(BaseEventData eventData) {
		SoundButton.soundManager.Select ();
	}
}
