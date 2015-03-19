using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class LevelSelectButton : MonoBehaviour, ISelectHandler {
	Button buttonReference;
	public bool isBack = false;
	static MenuSounds menuSounds;

	// Use this for initialization
	void Start () {
		if (menuSounds == null) {
			menuSounds = GameObject.Find("SoundManagerMenu").GetComponent<MenuSounds>();
		}
		buttonReference = GetComponent<Button> ();
		if (!isBack) {
			buttonReference.onClick.AddListener (SelectLevel);
			if (PlayerPrefs.GetInt (name) == 1) {
				buttonReference.interactable = true;
			} else {
				buttonReference.interactable = false;
			}
		} else {
			buttonReference.interactable = true;	
		}

	}

	public void OnSelect(BaseEventData eventData) {
		menuSounds.Focus ();
		string textHighscore = "--:--:--";
		if (isBack) {
			textHighscore = "";
		} else {
			float time = PlayerPrefs.GetFloat ("Timer_" + name);
			
			if (time > 0) {
				float secondes = time % 60;
				float millisecondes = (secondes % 1) * 100;
				float minutes = time / 60;
				
				string sec = Mathf.Round(secondes).ToString();
				string min = Mathf.Round(minutes).ToString();
				string milli = Mathf.Round(millisecondes).ToString();
				
				if ( sec.Length == 1 ) sec = "0" + sec;
				if ( min.Length == 1 ) min = "0" + min;
				if ( milli.Length == 1 ) milli = "0" + milli;
				
				
				textHighscore = min + ":"+sec+":"+milli;
			}
		}
		GameObject.Find ("Highscore").GetComponent<Text> ().text = textHighscore;
	}

	void SelectLevel() {
		AutoFade.LoadLevel (name,1f,0.5f, Color.black);
		menuSounds.Select ();
	}

	public void Back() {
		AutoFade.LoadLevel ("TitleScreen",0.5f,0.5f, Color.black);
		menuSounds.Select ();
	}
}
