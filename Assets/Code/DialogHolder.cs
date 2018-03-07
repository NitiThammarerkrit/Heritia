using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogHolder : MonoBehaviour {

    public string missingdialogue;
    public string succeeddialogue;
    private DialogueManager dMAn;
    public GameObject item;
    public Inventory inventory;
    public GameObject requiment;
    bool firsttime = true;
    bool succeed ;
	// Use this for initialization
	void Start () {
        dMAn = FindObjectOfType<DialogueManager>();
        succeed = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.name == "Player")
        {
            if(Input.GetKeyUp(KeyCode.Z))
            {
                for (int i = 0; i < inventory.inventory.Length; i++)
                {
                    if (inventory.inventory[i] == requiment)
                    {
                        dMAn.ShowBox(succeeddialogue);
                        inventory.RemoveItemfrominventory(inventory.inventory[i]);
                        item.GetComponent<InteractionObject>().DoInteraction();
                        if (firsttime == true)
                        {
                            inventory.AddItem(item);
                            firsttime = false;
                        }
                        succeed = true;
                        break;
                    }
                }
                if(succeed == false)
                {
                    dMAn.ShowBox(missingdialogue);
                }
             }      
           }
        }
    }
