using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

	void OnTriggerStay2D (Collider2D other)
    {
        if (Input.GetKeyDown(KeyCode.Z) && Application.loadedLevel == 2)
        {
            GameData.previous_scene = 2;
            GameData.current_scene = 1;
            StartCoroutine(Goto("House"));
        }
        else if (Input.GetKeyDown(KeyCode.Z) && Application.loadedLevel == 1)
        {
            GameData.previous_scene = 1;
            GameData.current_scene = 2;
            StartCoroutine(Goto("Farm"));
        }
    }

    IEnumerator Goto (string scene)
    {
        GameObject.Find("TransitionController").GetComponent<TransitionController>().gogo();
        yield return new WaitForSeconds(1.0f);
        Application.LoadLevel(scene);
    }
}
