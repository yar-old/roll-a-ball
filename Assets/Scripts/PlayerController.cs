using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float speed;
	public Text countText;
	public Text winText;

	private Rigidbody rb;
	private int count;

	// Use this for initialization
	void Start () {
		// Set to Rigidbody component on Player object
		rb = GetComponent<Rigidbody> ();

		// Initialize score count
		count = 0;
		SetCountText ();

		// Initialize text message for win
		winText.text = "";
	}

	// Update is called once per frame
	void Update () {

	}

	// FixedUpdate is called before performing any physics calculation
	void FixedUpdate () {
		// Capture X/Z axis movement from user input
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		// Add user movement to the Rigidbody
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.AddForce (movement * speed);
	}

	// Called when confronted with a trigger object
	void OnTriggerEnter (Collider other) {
		if (other.gameObject.CompareTag ("Pickup")) {
			other.gameObject.SetActive (false);
			count++;
			SetCountText ();
		}
	}

	void SetCountText () {
		countText.text = "Count: " + count.ToString ();

		if (count >= 16) {
			winText.text = "You Win!";
		}
	}
}
