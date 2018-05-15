using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialController : MonoBehaviour {

    public GameObject tutorial;
    public GameObject door;

	// Update is called once per frame
	void Update () {
		if (GameData.pass_tutorial == true)
        {
            tutorial.SetActive(true);
            door.SetActive(false);
        }
        else
        {
            tutorial.SetActive(false);
            //door.SetActive(true);
        }
	}
}
