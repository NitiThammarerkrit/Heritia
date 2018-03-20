using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyController : MonoBehaviour
{
    private Rigidbody2D myRB;
    public float moveSpeed;
    public float area;
    public GameObject thePlayer;
    private Vector3 thisPos;
    private Vector3 playerPos;
    private float playerdistance;
    bool left, right, firstmove = true;
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
       // thePlayer = FindObjectOfType<Player>();
    }

    void FixedUpdate()
    {

    }
    void Update()
    {
        playerPos = thePlayer.GetComponent<Transform>().position;
        thisPos = this.transform.position;
        playerdistance = Vector3.Distance(thisPos, playerPos);
        
        float xx = Mathf.Pow((playerPos.x - thisPos.x), 2);
        float yy = Mathf.Pow((playerPos.y - thisPos.y), 2);
       // float zz = Mathf.Pow((playerPos.z - thisPos.z), 2);
        if (Mathf.Sqrt(xx + yy) < area && Mathf.Sqrt(xx + yy) > 6)
        {
            this.transform.LookAt(thePlayer.transform.position);
            myRB.velocity = new Vector3(this.transform.forward.x * moveSpeed,-2.0f, 0);
            this.transform.rotation = Quaternion.Euler(0, -188, 0);
        }
        else
        if(Mathf.Sqrt(xx + yy) < 6.5)
        {
            this.GetComponentInChildren<ActivateTextAtLine>().arrive = true;
        }
        if (myRB.velocity.x < 0 && left == false)
        {
            Flip();
            left = true;
            right = false;
            firstmove = false;
        }
        /*else
            if (myRB.velocity.x > 0 && right == false && firstmove == false)
        {
            Flip();
            left = false;
            right = true;
        }*/
    }

    private void Flip()
    {
        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
