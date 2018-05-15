using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Player))]
public class PlayerInput : MonoBehaviour {

	Player player;
    Animator anim;
    bool jump = false;
    GameObject zbut;


    void Start () {
		player = GetComponent<Player> ();
        anim = GetComponent<Animator>();
        zbut = GameObject.Find("z_butt");
    }
    
    bool left , right , firstmove = true;
	void Update () {

        Vector2 directionalInput = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
		player.SetDirectionalInput (directionalInput);
        if((Input.GetAxisRaw("Horizontal")>0||Input.GetAxisRaw("Horizontal")<0)&& player.canmove)
        {
            anim.SetBool("Iswalk",true);
        }
        else
            anim.SetBool("Iswalk", false);

        if (Input.GetKeyDown (KeyCode.Space)) {
			player.OnJumpInputDown ();
        }
		if (Input.GetKeyUp (KeyCode.Space)) {
			player.OnJumpInputUp ();
        }
        if(Input.GetAxisRaw("Horizontal")<0&&left == false)
        {
            Flip();
            left = true;
            right = false;
            firstmove = false;
        }
        else
            if(Input.GetAxisRaw("Horizontal") > 0 && right == false && firstmove == false)
        {
            Flip();
            left = false;
            right = true;
        }
	}
    private void Flip()
    {
        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        zbut.GetComponent<SpriteRenderer>().flipX = true;
    }   
}
