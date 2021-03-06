﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

    public GameObject[] inventory = new GameObject[8];
    public Button[] InventoryButtons = new Button[8];
    bool onetime = true;

    public void AddItem(GameObject item)
    {
        bool itemAdded = false;
        for(int i = 0; i<inventory.Length;i++)
        {
            if(inventory[i]==item)
            {
                break;
            }
            if(inventory[i]==null)
            {
                Debug.Log(item.name);
                inventory[i] = item;
                GameData.items[i] = item.name;
                InventoryButtons[i].image.overrideSprite = inventory[i].GetComponent<SpriteRenderer>().sprite;
                Debug.Log(item.name + " was added");
                itemAdded = true;
                item.SendMessage("DoInteraction");
                SaveLoad.Save();
                /*if (onetime)
                {
                    GameData.items[i] = item.name;
                    SaveLoad.Save();
                    onetime = false;
                }*/
                break;
            }   
        }
        //SaveLoad.Save();
        if (!itemAdded)
        {
            Debug.Log("inventory Full - Item cannot be added");
        }
    }
    public void RemoveItemfrominventory(GameObject item)
    {
        for (int i = 0; i< inventory.Length;i++)
        {
            if(inventory[i]==item)
            {
                inventory[i] = null;
                GameData.items[i] = null;
                Debug.Log(item.name + "was remove from inventory");
                InventoryButtons[i].image.overrideSprite = null;
                break;
            }
        }
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
