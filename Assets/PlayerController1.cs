using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : MonoBehaviour {

	public float MoveSpeed;

	private Rigidbody2D myRigidbody;

	private Vector3 moveInput;
	private Vector3 moveVelocity;

	void Start () {
		myRigidbody = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate () {
		myRigidbody.velocity = moveVelocity;

		var mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Quaternion rot = Quaternion.LookRotation (transform.position - mousePosition, Vector3.forward);
		rot.x = 0f;
		rot.y = 0f;

		transform.rotation = rot;
	}

	void Update () {
		moveInput = new Vector3 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"), 0f);
		moveVelocity = moveInput * MoveSpeed;
	}

	void OnTriggerEnter (Collider other) {
		if (other.name == "Sphere") 
		{
			Destroy (this.gameObject);
		}
	}
}
