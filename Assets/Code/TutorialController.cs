using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialController : MonoBehaviour {

    public GameObject tutorial;
    public GameObject door;

	void Update () {
		if (GameData.pass_tutorial == false)
        {
            tutorial.SetActive(true);
            //door.SetActive(false);
        }
        else
        {
            tutorial.SetActive(false);
            //door.SetActive(true);
        }
	}

    //don't forget to delete commend before build the game!
}
