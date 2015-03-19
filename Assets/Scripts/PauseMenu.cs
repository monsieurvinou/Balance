using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	bool isPause = false;
	float previousTimeScale = 0;
	GameObject pauseContainer;
	bool pausePossible = true;

	// Use this for initialization
	void Start () {
		pauseContainer = GameObject.Find ("PauseMenuContainer");
		pauseContainer.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (pausePossible && !AutoFade.Fading) {
			if (!isPause && Input.GetButtonDown ("Menu")) {
				isPause = true;
				previousTimeScale = Time.timeScale;
				Time.timeScale = 0;
				pauseContainer.SetActive(true);
				Button resumeButton = GameObject.Find("Resume").GetComponent<Button>();
				resumeButton.Select();
				resumeButton.OnSelect(null);
			} else if ( isPause && Input.GetButtonDown("Menu")) {
				isPause = false;
				Time.timeScale = previousTimeScale;
				pauseContainer.SetActive(false);
				
			}
		}
	}

	public void Resume() {
		if (pausePossible) {
			isPause = false;
			Time.timeScale = previousTimeScale;
			pauseContainer.SetActive(false);
		}
	}

	public void Retry() {
		if (pausePossible) {
			Time.timeScale = previousTimeScale;
			pausePossible = false;
			AutoFade.LoadLevel (Application.loadedLevelName,1f,0.5f, Color.black);
		}
	}

	public void Quit() {
		if (pausePossible) {
			Time.timeScale = previousTimeScale;
			pausePossible = false;
			AutoFade.LoadLevel ("TitleScreen", 1f, 0.5f, Color.black);
		}
	}
}
