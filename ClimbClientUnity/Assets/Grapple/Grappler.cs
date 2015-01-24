using UnityEngine;
using System.Collections;

public class Grappler : MonoBehaviour {

	public GameObject grapple;
	public float offset = 1f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			ShootGrapple();
		}
	}

	void ShootGrapple () {
		Vector2 abovePos = new Vector2 (transform.position.x, transform.position.y + offset);
		RaycastHit2D hit = Physics2D.Raycast(abovePos, Vector2.up);
		print (hit.collider.tag);
		if (hit.collider != null) {
			float distance = hit.point.y - transform.position.y;
			print(distance);
			GameObject gr = Instantiate(grapple, abovePos, Quaternion.identity) as GameObject;
			gr.transform.localScale = new Vector2(gr.transform.localScale.x, distance);
		}
	}
}
