using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	// store a public reference to the Player game object, so we can refer to it's Transform
	public GameObject player;
	// Store a Vector3 offset from the player (a distance to place the camera from the player at all times)
	private Vector3 offset;

	void Start ()
	{
		// Create an offset by subtracting the Camera's position from the player's position
		offset = transform.position - player.transform.position;
	}
    void Update()
	{ }
    // After the standard 'Update()' loop runs, and just before each frame is rendered..
    void LateUpdate (){transform.position = player.transform.position + offset;}}