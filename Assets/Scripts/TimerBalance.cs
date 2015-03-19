using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimerBalance : MonoBehaviour {
	Text textTimer;
	public float startTimer;
	bool isStarted = false;
	public bool finished = false;

	void Start () {
		textTimer = GetComponent<Text> ();
	}

	void Update () {
		// Add time
		if (isStarted && !finished) {
			float time = Time.time - startTimer;
			float secondes = time % 60;
			float millisecondes = (secondes % 1) * 100;
			float minutes = time / 60;

			string sec = Mathf.Round(secondes).ToString();
			string min = Mathf.Round(minutes).ToString();
			string milli = Mathf.Round(millisecondes).ToString();

			if ( sec.Length == 1 ) sec = "0" + sec;
			if ( min.Length == 1 ) min = "0" + min;
			if ( milli.Length == 1 ) milli = "0" + milli;


			textTimer.text = min + ":"+sec+":"+milli;
		}
		// Waiting for the first input
		if (!isStarted && Time.timeScale != 0	) {
			if (Input.GetAxis ("Vertical") != 0 || Input.GetAxis ("Horizontal") != 0) {
				isStarted = true;
				startTimer = Time.time;	
			}
			textTimer.text = "00:00:00";
		}
	}
}
