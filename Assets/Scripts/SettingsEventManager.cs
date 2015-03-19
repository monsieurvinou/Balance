using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SettingsEventManager : MonoBehaviour {
	Slider BGMSlider;
	Slider SFXSlider;
	Toggle IsAzerty;

	void Start() {
		// BGM
		GameObject temp = GameObject.Find ("SliderBGM");
		if (temp != null) {
			BGMSlider = temp.GetComponent<Slider>();
			BGMSlider.value = PlayerPrefs.GetFloat("BGM");
		}

		// SFX
		temp = GameObject.Find ("SliderSFX");
		if (temp != null) {
			SFXSlider = temp.GetComponent<Slider>();
			SFXSlider.value = PlayerPrefs.GetFloat("SFX");
		}


		// IsAzerty
		GameObject tempToggle = GameObject.Find ("ToggleAzerty");
		if (tempToggle != null) {
			IsAzerty = tempToggle.GetComponent<Toggle>();
			IsAzerty.isOn = PlayerPrefs.GetInt("IsAzerty") == 1;
		}
	}

	public void SaveSettings() {
		PlayerPrefs.SetFloat("BGM", BGMSlider.value);
		PlayerPrefs.SetFloat("SFX", SFXSlider.value);

		PlayerPrefs.Save ();

		AutoFade.LoadLevel ("TitleScreen",0.5f,0.5f, Color.black);
	}
}
