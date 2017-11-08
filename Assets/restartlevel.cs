using UnityEngine;
using System.Collections;

public class restartlevel : MonoBehaviour {

	// Use this for initialization
	void OnTriggerEnter(Collider other) {
		Application.LoadLevel(Application.loadedLevel);
	}
}
