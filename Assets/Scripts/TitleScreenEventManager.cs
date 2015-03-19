using UnityEngine;
using System.Collections;

public class TitleScreenEventManager : MonoBehaviour {

	void Start() {
		if (!PlayerPrefs.HasKey ("IsAzerty")) {
			// Azerty
			PlayerPrefs.SetInt("IsAzerty", 0);

			// Sounds
			PlayerPrefs.SetFloat ("BGM", 1f);
			PlayerPrefs.SetFloat ("SFX", 0.7f);

			// Level unlock and best times
			PlayerPrefs.SetInt("Level_1", 1);
			PlayerPrefs.SetFloat("Time_Level_1", -1f);
			for ( int i = 2; i<11; i++ ) {
				PlayerPrefs.SetInt("Level_"+i, 0);
				PlayerPrefs.SetFloat("Time_Level_"+i, -1f);
			}

			PlayerPrefs.Save();
		}
	}

	public void StartGame() {
		AutoFade.LoadLevel ("LevelSelectScreen",0.5f,0.5f, Color.black);
	}

	public void Settings() {
		AutoFade.LoadLevel ("Settings",0.5f,0.5f, Color.black);
	}

	public void QuitGame() {
		Application.Quit ();
	}

}
