using UnityEngine;
using System.Collections;

public class GridManager : MonoBehaviour {

	public class GUIButton
	{
		public string controlName;
		public string text;
		public Rect rect;
	}

	GUIButton[] buttons; // Array of buttons to navigate through.
	string[] controlNames = {"Play","Settings","Exit"};
	int current; // Index into buttons[].


	void Start() {
		RectTransform[] listRectanles = GetComponentsInChildren<RectTransform> ();
		if (listRectanles != null) {
			buttons = new GUIButton[listRectanles.Length];
			int index = 0;
			foreach(RectTransform rt in listRectanles ) {
				buttons[index] = new GUIButton();
				// Control name
				if ( index <= controlNames.Length ) {
					buttons[index].controlName = controlNames[index];
					buttons[index].text = controlNames[index];
				} else {
					buttons[index].controlName = "ERROR";
					buttons[index].text = "ERROR";
				}

				// Rectangle
				buttons[index].rect = rt.rect;
			}
		}
	}

	void OnGUI() {
		float axis = Input.GetAxis("Vertical");
		if (axis < 0) {
			current--; // Move to previous button.
		} else if (axis > 0) {
			current++; // Move to next button.
		}
		current = Mathf.Clamp(current, 0, buttons.Length-1);
		foreach (GUIButton button in buttons) {
			GUI.SetNextControlName(button.controlName);
			if (GUI.Button(button.rect, button.text)) {
				Debug.Log("ACTION : " + button.controlName);
			}
		}

		GUI.FocusControl(buttons[current].controlName);
	}

}
