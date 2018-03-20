using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkyRandom : MonoBehaviour {

    public const int num_sky = 3;
    public Sprite[] sky = new Sprite[num_sky];

	void Start () {
        int ran = Random.Range(0,num_sky);
        this.GetComponent<SpriteRenderer>().sprite = sky[ran];	
	}
	
}
