using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpGate : MonoBehaviour {

    public bool isEnterFromRight; 

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Player")
        {
            StartCoroutine(GotoNextScene());
            SaveLoad.Save();
        }
	}

    IEnumerator GotoNextScene()
    {
        if (isEnterFromRight == true)
        {
            GameData.previous_scene = Application.loadedLevel;
            GameData.current_scene = Application.loadedLevel - 1;
            GameObject.Find("TransitionController").GetComponent<TransitionController>().gogo();
            yield return new WaitForSeconds(1.0f);
            Application.LoadLevel(Application.loadedLevel - 1);
        }
        else
        {
            GameData.previous_scene = Application.loadedLevel;
            GameData.current_scene = Application.loadedLevel + 1;
            GameObject.Find("TransitionController").GetComponent<TransitionController>().gogo();
            yield return new WaitForSeconds(1.0f);
            Application.LoadLevel(Application.loadedLevel + 1);
        }
    }
}
