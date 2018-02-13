﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    private Vector2 velocity;

    public float smoothTimex;
    public float smoothTimey;

    public GameObject player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}

    // Update is called once per frame
    void FixedUpdate()
    {
        float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, smoothTimex);
        float posY = Mathf.SmoothDamp(transform.position.y ,player.transform.position.y, ref velocity.y, smoothTimey);

        transform.position = new Vector3(posX, posY, transform.position.z);
    }
    void Update () {
		
	}
}
