using UnityEngine;
using System.Collections;

public class Ground : MonoBehaviour {
	private bool _move = false;

	void Start() {
	
	}

	void Update() {
		if(_move) transform.position -= new Vector3(0, 0.02f);
		
		if(Input.GetKey(KeyCode.Space))
			_move = true;
	}
}
