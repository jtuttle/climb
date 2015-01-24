using UnityEngine;
using System.Collections;

public class StalkDown : MonoBehaviour {
	//FIELDS
	int x =0;
	int y = 0;
	private bool inputDetected = false;
	
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//will need code raise the water 1/6 the way up the screen once there is 
		//input detected from the user
		
		//need to find out what input will look like
		//if(x==0 && Input.GetKey(KeyCode.F )){
		if(x==0 && Input.anyKey){
		inputDetected =true;
			x+=1;
		}
		if(y ==0 && inputDetected ==true) {
			//raise the water to the visible part of the screen
			transform.Translate(Vector3.down * Time.deltaTime, Space.World);
			/*if(transform.position.y <= -3.91){
				transform.Translate(Vector3.down *Time.deltaTime, Space.World);
				y = 1;
			}*/
		}
	}
	
}