using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionController : MonoBehaviour {

    public GameObject gotoRight;
    public GameObject gotoLeft;
    public GameObject comefromRight;
    public GameObject comefromLeft;
    public GameObject PlayerPrefab;

	void Awake () {
        gotoLeft.SetActive(false);
        gotoRight.SetActive(false);
        comefromLeft.SetActive(false);
        comefromRight.SetActive(false);

        if (GameData.current_scene < GameData.previous_scene)
        {
            GameObject sp_point = GameObject.Find("SpawnRight");
            Instantiate(PlayerPrefab, sp_point.transform.position, sp_point.transform.rotation);
            comefromRight.SetActive(true);
        }
        else if (GameData.current_scene > GameData.previous_scene)
        {
            GameObject sp_point = GameObject.Find("SpawnLeft");
            Instantiate(PlayerPrefab, sp_point.transform.position, sp_point.transform.rotation);
            comefromLeft.SetActive(true);
        }
        else
        {
            GameObject sp_point = GameObject.Find("SpawnLeft");
            Instantiate(PlayerPrefab, sp_point.transform.position, sp_point.transform.rotation);
        }
    }

    public void gogo ()
    {
        if (GameData.current_scene > GameData.previous_scene) gotoRight.SetActive(true);
        else gotoLeft.SetActive(true);
    }
}
