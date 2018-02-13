using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    private Rigidbody2D myRigidbody;
    //public Animator anim;
    //private float inputH;
    //private float inputV;
    //int floorMask;
    //float camRayLength = 100f;
    public GameObject Player;
    private Vector2 moveInput;
    private Vector2 moveVelocity;
    public Camera mainCamera;
    public float jump;
    private bool IsGround = false;
    //public HandGrenade grenadePrefab;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsGround == true)
        {
            moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), 0f /*Input.GetAxisRaw("Vertical")*/);
        }
        else
            moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), -1f /*Input.GetAxisRaw("Vertical")*/);
        moveVelocity = moveInput * moveSpeed;
        if (Input.GetKeyDown("space"))
        {
            if (IsGround == true)
            {
                myRigidbody.AddForce(new Vector2(0f, jump*Time.deltaTime));
            }
        }
    }
    void FixedUpdate()
    {
        myRigidbody.velocity = moveVelocity;

    }
    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "Floor")
        {
            IsGround = true;
        }
    }
    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Floor")
        {
            IsGround = false;
        }
    }
}
