using UnityEngine;
using System.Collections;

public class Treadmill : MonoBehaviour {
	public Vector3 treadmillForce = Vector3.zero;
	private ArrayList passengers;

	void Start() {
		passengers = new ArrayList ();
	}

	void OnTriggerEnter (Collider other) {
		if (other.tag == "Player") {
			if ( !passengers.Contains(other) ) {
				passengers.Add(other);
			}
		}
	}

	void OnTriggerExit (Collider other) {
		if (other.tag == "Player") {
			if ( passengers.Contains(other) ) {
				passengers.Remove(other);
			}
		}
	}

	void Update() {
		foreach(Collider passenger in passengers) {
			passenger.rigidbody.AddForce(treadmillForce);
		}
	}
}
