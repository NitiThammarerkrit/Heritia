﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextImporter : MonoBehaviour {

    public TextAsset textfile;
    public string[] textLines;
	// Use this for initialization
	void Start () {
		if(textfile != null)
        {
            textLines = (textfile.text.Split('\n'));
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
