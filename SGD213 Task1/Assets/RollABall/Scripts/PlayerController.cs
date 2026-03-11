using UnityEngine;

// Include the namespace required to use Unity UI
using UnityEngine.UI;

using System.Collections;

public class PlayerController : MonoBehaviour {

    // Create public variables for player speed, and for the Text UI game objects
    [SerializeField]
    public float f_horPlayAccel;

	public Text NumTotal;
	public Text wintext;

	// Create private references to the rigidbody component on the player, and the count of pick up objects picked up so far
	private Rigidbody rb;
	private float inttotalcount;

	// At the start of the game..
	void Start ()	{rb = GetComponent<Rigidbody>();inttotalcount = 0;SetCountText ();wintext.text = "";}

	void FixedUpdate ()
	{
		// Set some local float variables equal to the value of our Horizontal and Vertical Inputs
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		// Create a Vector3 variable, and assign X and Z to feature our horizontal and vertical float variables above
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.AddForce (movement * f_horPlayAccel);
	}
	void OnTriggerEnter(Collider other) 
{
if (other.gameObject.CompareTag ("Pick Up"))
{							other.gameObject.SetActive (false);
							inttotalcount = inttotalcount + 1;
							SetCountText ();
		}}

    void DoSomething()
	{
	
	}
    void SetCountText()
{NumTotal.text = "Count: " + inttotalcount.ToString ();
		if (inttotalcount >= 12) 
{
			// Set the text value of our 'winText'
			wintext.text = "You Win!";
}
}
}