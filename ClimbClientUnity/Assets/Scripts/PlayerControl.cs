using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{

		[HideInInspector]
		public bool
				facingRight = true;
		[HideInInspector]
		public bool
				jump = false;				// Condition for whether the player should jump.

		private Animator anim;
		public float moveForce = 30f;			// Amount of force added to move the player left and right.
		public float maxSpeed = 5f;				// The fastest the player can travel in the x axis.
		public float jumpForce = 1000f;			// Amount of force added when the player jumps.
	
		// Use this for initialization
		void Start ()
		{
				anim = GetComponent<Animator> ();
		}
	
		// Update is called once per frame
		void Update ()
		{

				if (Input.GetButtonDown ("Jump"))
						jump = true;
		
		}

		void FixedUpdate ()
		{
				// Cache the horizontal input.
				float h = Input.GetAxis ("Horizontal");
		
				// The Speed animator parameter is set to the absolute value of the horizontal input.
				anim.SetFloat ("Speed", Mathf.Abs (h));

				// If the player is changing direction (h has a different sign to velocity.x) or hasn't reached maxSpeed yet...
				if (h * rigidbody2D.velocity.x < maxSpeed)
			// ... add a force to the player.
						rigidbody2D.AddForce (Vector2.right * h * moveForce);
		
				// If the player's horizontal velocity is greater than the maxSpeed...
				if (Mathf.Abs (rigidbody2D.velocity.x) > maxSpeed)
			// ... set the player's velocity to the maxSpeed in the x axis.
						rigidbody2D.velocity = new Vector2 (Mathf.Sign (rigidbody2D.velocity.x) * maxSpeed, rigidbody2D.velocity.y);

				if (jump) {
						rigidbody2D.AddForce (new Vector2 (0f, jumpForce));
						jump = false;
				}
		}

}
