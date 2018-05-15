using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGchange : MonoBehaviour {

    public Sprite[] bg = new Sprite[3];

	// Use this for initialization
	void Start () {
        int ran = Random.Range(0,3);
        this.GetComponent<Image>().sprite = bg[ran];
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
