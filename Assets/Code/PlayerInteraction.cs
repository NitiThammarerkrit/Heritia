﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour {

    public GameObject z;
    public GameObject currentInterObj = null;
    public InteractionObject currentInterObjScript = null;
    public Inventory inventory;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("warp")) z.SetActive(true);
        if (other.CompareTag("interObject"))
        {
            Debug.Log(other.name);
            currentInterObj = other.gameObject;
            currentInterObjScript = currentInterObj.GetComponent<InteractionObject>();
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        z.SetActive(false);
        if (other.CompareTag("interObject"))
        {
            if (other.gameObject == currentInterObj)
            {
                currentInterObj = null;
            }
        }

    }
    // Use this for initialization
    void Start () {
        z.SetActive(false);
        inventory = FindObjectOfType<Inventory>();
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton ("Interact")&& currentInterObj)
        {
            if(currentInterObjScript.inventory)
            {
                inventory.AddItem(currentInterObj);
            }
            //currentInterObj.SendMessage("DoInteraction");
        }
	}
}
