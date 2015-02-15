using UnityEngine;
using System.Collections;

public class Ground : MonoBehaviour {
	private bool _move = false;



	void Update() {
		if(!_move) return;

		transform.position -= new Vector3(0, 0.5f) * Time.deltaTime;
	}

	public void Begin() {
		_move = true;
	}

	public void Stop() {
		_move = false;
	}
	 
	public void Reset() {
		_move = false;

		transform.position = new Vector3(0, -18.5f, 0);
	}
}
