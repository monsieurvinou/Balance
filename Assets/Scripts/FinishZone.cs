using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FinishZone : MonoBehaviour {

	public string nextLevel = "TitleScreen";
	bool alreadyTriggered = false;
	GameObject menu;


	void Start() {
		menu = GameObject.Find ("EndMenu");
		menu.SetActive (false);
	}

	void OnTriggerEnter (Collider other) {
		if (other.tag == "Player" && !alreadyTriggered) {
			alreadyTriggered = true;

			// Audio Part
			GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("SFX");
			GetComponent<AudioSource>().Play ();

			// Unlock the next level
			PlayerPrefs.SetInt(nextLevel, 1);

			menu.SetActive(true);

			// We get the timer
			TimerBalance timer = GameObject.Find("Timer").GetComponent<TimerBalance>();
			timer.finished = true;

			float time = Time.time - timer.startTimer;
			string sec = Mathf.Round(time % 60).ToString();
			string milli = Mathf.Round(((time % 60) % 1) * 100).ToString();
			string min = Mathf.Round(time / 60).ToString();
			if ( sec.Length == 1 ) sec = "0" + sec;
			if ( min.Length == 1 ) min = "0" + min;
			if ( milli.Length == 1 ) milli = "0" + milli;

			GameObject.Find("ScoreText").GetComponent<Text>().text = min + ":"+sec+":"+milli;
			GameObject.Find("Timer").GetComponent<Text>().text = min + ":"+sec+":"+milli;


			// determine if new highscore
			float previousTime = PlayerPrefs.GetFloat("Timer_"+Application.loadedLevelName);
			if ( previousTime <= 0 || previousTime > time ) {
				// New HIGHSCORE
				PlayerPrefs.SetFloat("Timer_"+Application.loadedLevelName, time);
				GameObject.Find("NewRecord").SetActive(true);
			} else {
				GameObject.Find("NewRecord").SetActive(false);
			}

			// Focus on the "Next" if it exists, else the quit
			GameObject nextLevelObject = GameObject.Find("NextLevel");
			if ( nextLevelObject != null ) {
				nextLevelObject.GetComponent<Button>().Select ();
				nextLevelObject.GetComponent<Button>().OnSelect(null);
			} else {
				GameObject.Find("QuitLevel").GetComponent<Button>().Select ();
				GameObject.Find("QuitLevel").GetComponent<Button>().OnSelect(null);
			}
		}
	}

	public void Next() {
		AutoFade.LoadLevel(nextLevel, 0.2f, 0.2f, Color.black);
	}

	public void Retry() {
		AutoFade.LoadLevel(Application.loadedLevelName, 0.2f, 0.2f, Color.black);
	}

	public void Quit() {
		AutoFade.LoadLevel("TitleScreen", 0.2f, 0.2f, Color.black);
	}
}
