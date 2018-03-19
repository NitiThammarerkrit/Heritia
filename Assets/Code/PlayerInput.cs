using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Player))]
public class PlayerInput : MonoBehaviour {

	Player player;
    Animator anim;
<<<<<<< HEAD
    bool jump = false;
=======
>>>>>>> 755af25d6e09c252d2ae198862d68cb7802562ba


    void Start () {
		player = GetComponent<Player> ();
        anim = GetComponent<Animator>();
	}
    
    bool left , right , firstmove = true;
	void Update () {

        Vector2 directionalInput = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
		player.SetDirectionalInput (directionalInput);
<<<<<<< HEAD
        if((Input.GetAxisRaw("Horizontal")>0||Input.GetAxisRaw("Horizontal")<0)&& player.canmove)
=======
        if(Input.GetAxisRaw("Horizontal")>0||Input.GetAxisRaw("Horizontal")<0)
>>>>>>> 755af25d6e09c252d2ae198862d68cb7802562ba
        {
            anim.SetBool("Iswalk",true);
        }
        else
            anim.SetBool("Iswalk", false);

        if (Input.GetKeyDown (KeyCode.Space)) {
			player.OnJumpInputDown ();
<<<<<<< HEAD
        }
		if (Input.GetKeyUp (KeyCode.Space)) {
			player.OnJumpInputUp ();
        }
=======
		}
		if (Input.GetKeyUp (KeyCode.Space)) {
			player.OnJumpInputUp ();
		}
>>>>>>> 755af25d6e09c252d2ae198862d68cb7802562ba
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
    }
}
