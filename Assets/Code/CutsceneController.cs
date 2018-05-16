using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneController : MonoBehaviour {

    public GameObject first_cut;
    public GameObject last_cut;
    public AudioSource first_mu;
    public AudioSource last_mu;

	void Start () {
        first_cut.SetActive(false);
        last_cut.SetActive(false);
        first_mu.enabled = false;
        last_mu.enabled = false;

        if (GameData.pass_tutorial == false)
        {
            first_cut.SetActive(true);
            first_mu.enabled = true;
            StartCoroutine(goforward(24.0f, "House"));
        }
        else
        {
            last_cut.SetActive(true);
            last_mu.enabled = true;
            SaveLoad.Save();
            StartCoroutine(goforward(25.0f, "Menu"));
        }
	}


    IEnumerator goforward (float delay_time, string scene)
    {
        yield return new WaitForSeconds(delay_time);
        Application.LoadLevel(scene);
    }
}
