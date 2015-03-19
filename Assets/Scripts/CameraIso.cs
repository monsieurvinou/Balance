using UnityEngine;
using System.Collections;

public class CameraIso : MonoBehaviour {

	public float joystickSensitivity = 0.1f;
	public float zoomSensitivity = 0.1f;
	public static bool isInverted = false;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (Time.timeScale != 0 && !GameObject.Find ("Timer").GetComponent<TimerBalance> ().finished) {
			float horizontalJoy = Input.GetAxis ("JoyX") * joystickSensitivity;
			float verticalJoy = -Input.GetAxis ("JoyY") * joystickSensitivity;
			
			Vector3 move = new Vector3 ( horizontalJoy, verticalJoy, 0  );
			if (CameraIso.isInverted) {
				move = -move;
			}
			
			transform.Translate (move);
			
			float zoom = Input.GetAxis ("Zoom") * zoomSensitivity;
			Camera[] allChildren = GetComponentsInChildren<Camera>();
			foreach (Camera child in allChildren)
			{
				child.orthographicSize += zoom;
				if ( child.orthographicSize < 2 ) child.orthographicSize = 2;
				else if ( child.orthographicSize > 15 ) child.orthographicSize = 15;
			}
		}
	}
}
