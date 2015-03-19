using UnityEngine;
using System.Collections;

public class RotatingWorld : MonoBehaviour {
	private float maxAngle = 20; 
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.timeScale != 0 && !GameObject.Find ("Timer").GetComponent<TimerBalance> ().finished) {
			float joyX = Input.GetAxis ("Horizontal") * maxAngle;
			float joyZ = Input.GetAxis ("Vertical") * maxAngle;
			
			Quaternion qX = Quaternion.AngleAxis (joyX, Vector3.left);
			Quaternion qZ = Quaternion.AngleAxis (joyZ, Vector3.back);
			
			Quaternion q = qX * qZ;
			transform.rotation = q;
		}
	}
}
