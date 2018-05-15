﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Check : MonoBehaviour {

    public Inventory inventory;
    public GameObject ChiefHeritia;
    public GameObject ChiefBeach;
    public GameObject ButcherBefore;
    public GameObject Hunter;
    public Sprite ButcherBefores;
    public Sprite ButcherAfter;
    public GameObject Dog1Before;
    public GameObject Dog2Before;
    public Sprite Dog1Befores;
    public Sprite Dog2Befores;
    public Sprite Dog1After;
    public Sprite Dog2After;
    public GameObject Hunterbefore;
    public GameObject HunterAfter;

    public GameObject CAT;
    public Sprite cat0;
    public Sprite cat1;
    public Sprite cat2;
    public Sprite cat3;
    // Use this for initialization
    void Start () {
        GameData.current_scene = SceneManager.GetActiveScene().buildIndex;
        FindObjectOfType<Player>().canmove = true;
        for (int i = 0; i < 8; i++)
        {
            SaveLoad.Load();
            if (GameData.items[i] != null)
            {
                Debug.Log(GameData.items[i]);
                inventory.inventory[i] = GameObject.Find(GameData.items[i]);
                inventory.InventoryButtons[i].image.overrideSprite = GameObject.Find(GameData.items[i]).GetComponent<SpriteRenderer>().sprite;
            }    
        }
    }
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < 8; i++)
        {
            if(GameData.items[i]!=null)
            {
                Debug.Log(GameData.items[i]);
                inventory.inventory[i] = GameObject.Find(GameData.items[i]);
                inventory.InventoryButtons[i].image.overrideSprite = GameObject.Find(GameData.items[i]).GetComponent<SpriteRenderer>().sprite;
            }

        }
        if (ButcherBefore != null)
        {
            if (GameData.events_complete[0] == true)
            {
                ButcherBefore.transform.position = new Vector3(154, -1.83f, -2.96f);
                ButcherBefore.GetComponent<SpriteRenderer>().sprite = ButcherAfter;
            }
            else if (GameData.events_complete[0] == false)
            {
                ButcherBefore.transform.position = new Vector3(40.81f, -1.83f, -2.96f);
                ButcherBefore.GetComponent<SpriteRenderer>().sprite = ButcherBefores;
            }
            if (GameData.events_complete[1] == true)
            {
                Dog1Before.transform.position = new Vector3(78, -2.5f, -3f);
                Dog1Before.GetComponent<SpriteRenderer>().sprite = Dog1After;
                Dog2Before.GetComponent<SpriteRenderer>().sprite = Dog2After;
            }
            else if (GameData.events_complete[1] == false)
            {
                Dog1Before.transform.position = new Vector3(161.9f, -2.527f, -3f);
                Dog1Before.GetComponent<SpriteRenderer>().sprite = Dog1Befores;
                Dog2Before.GetComponent<SpriteRenderer>().sprite = Dog2Befores;
            }
        }
        if (Hunter != null)
        {
            if (GameData.events_complete[2] == true)
            {
                if (HunterAfter != null)
                    HunterAfter.SetActive(true);
                if (Hunterbefore != null)
                    Hunterbefore.SetActive(false); 
            }
            else if (GameData.events_complete[2] == false)
            {
                if (HunterAfter != null)
                    HunterAfter.SetActive(false);
                if (Hunterbefore != null)
                    Hunterbefore.SetActive(true);
            }
        }
        if(GameData.events_complete[3] == true)
        {
            if(ChiefHeritia!=null)
            ChiefHeritia.SetActive(true);
            if (ChiefBeach != null)
            ChiefBeach.SetActive(false);
        }
        else if(GameData.events_complete[3] == false)
        {
            if (ChiefHeritia != null)
            ChiefHeritia.SetActive(false);
            if (ChiefBeach != null)
            ChiefBeach.SetActive(true);
        }
        if(CAT!=null)
        {
            if(GameData.gems_receive==0)
            {
                CAT.GetComponent<SpriteRenderer>().sprite = cat0;
            }
            else
            if (GameData.gems_receive == 1)
            {
                CAT.GetComponent<SpriteRenderer>().sprite = cat1;
            }
            else
            if (GameData.gems_receive == 2)
            {
                CAT.GetComponent<SpriteRenderer>().sprite = cat2;
            }
            else
            if (GameData.gems_receive == 3)
            {
                CAT.GetComponent<SpriteRenderer>().sprite = cat3;
            }
            else
            if (GameData.gems_receive == 4)
            {
                CAT.GetComponent<SpriteRenderer>().sprite = cat1;
            }
        }

    }
}