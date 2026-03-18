// Include the namespace required to use Unity UI
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour 
{

	// Create private references to the player's rigidbody component and the current pick up count
	private Rigidbody rb;
	private int inTotalCount;
	[SerializeField] private float playerAcceleration; 
	[SerializeField] private Text numTotal;
	[SerializeField] private Text winText;

	// Runs once the game starts 
	void Start ()
	{
		rb = GetComponent<Rigidbody>();

		// At the start of the game, the count is set to 0
		inTotalCount = 0;

		// Update UI text
		SetCountText ();
		winText.text = "";
	}

	// Runs every physics update
	void FixedUpdate ()
	{
		// Set some local float variables equal to the value of our Horizontal and Vertical Inputs
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		// Create a Vector3 variable, and assign X and Z to feature our horizontal and vertical float variables above
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.AddForce (movement * playerAcceleration);
	}

	// Runs when the player collides with a trigger object
	void OnTriggerEnter(Collider other) 
	{
		// Checks if object is tagged "Pick Up"
		if (other.gameObject.CompareTag ("Pick Up"))
		{
			// Hide the Pick Up
			other.gameObject.SetActive (false);

			// Increase the count by 1
			inTotalCount++;

			// Update UI with new count
			SetCountText ();
		}
	}

	// Updates the pickup counter value
	void SetCountText()
	{
		if (numTotal == null)
		{
			Debug.Log("NumTotal is null.");
			return;
		}

		numTotal.text = "Count: " + inTotalCount.ToString ();
		
		// Check if player has collected enough pickups to win
		if (inTotalCount >= 12) 
		{
			winText.text = "You Won the game!!";
		}
	}
}	