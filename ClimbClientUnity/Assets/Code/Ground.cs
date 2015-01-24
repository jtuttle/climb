using UnityEngine;
using System.Collections;

public class Ground : MonoBehaviour {

	void Start() {
	
	}

	void Update() {
		transform.position -= new Vector3(0, 0.02f);
	}
}
