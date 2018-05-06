using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

	
	void OnTriggerStay2D (Collider2D other)
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            StartCoroutine(GotoHouse());
        }
    }

    IEnumerator GotoHouse ()
    {
        yield return new WaitForSeconds(0.5f);
        Application.LoadLevel("House");
    }
}
