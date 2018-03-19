using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTextAtLine : MonoBehaviour {


    public TextAsset succeedText;
    public TextAsset unsucceedText;

    public int startLine;
    public int endLine;

    public TextBoxmanager theTextBox;

    public bool destroyWhenActivate;
    public bool requireButtonPress;
    private bool waitForPress;


    public GameObject item;
    public Inventory inventory;
    public GameObject requiment;
    bool firsttime = true;
<<<<<<< HEAD
    bool succeed = false;
    bool onetime = true;
    public bool give ;
    // Use this for initialization
    void Start () {
        //theTextBox = FindObjectOfType<TextBoxmanager>();
        //succeed = false;
=======
    bool succeed;
    bool onetime = true;
    // Use this for initialization
    void Start () {
        theTextBox = FindObjectOfType<TextBoxmanager>();
>>>>>>> 755af25d6e09c252d2ae198862d68cb7802562ba
    }
	
	// Update is called once per frame
	void Update () {

		
	}

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.name == "Player")
        {
            if(requireButtonPress)
            {
                if(Input.GetKeyDown(KeyCode.Z))
                {
                    for (int i = 0; i < inventory.inventory.Length; i++)
                    {
<<<<<<< HEAD
                        if ((inventory.inventory[i] == requiment) && !give)
                        {
                            Debug.Log("kuay5");
=======
                        if (inventory.inventory[i] == requiment)
                        {
>>>>>>> 755af25d6e09c252d2ae198862d68cb7802562ba
                            inventory.RemoveItemfrominventory(inventory.inventory[i]);
                            inventory.AddItem(item);
                            Destroy(item);
                            succeed = true;
                            theTextBox.ReloadScript(succeedText);
                            if (theTextBox.currentLine >= endLine || theTextBox.currentLine == 0)
                            {
                                theTextBox.currentLine = startLine;
                            }
                            theTextBox.endAtLine = endLine;
                            theTextBox.EnableTextBox();
                            /* if (destroyWhenActivate)
                             {
                                 Destroy(gameObject);
                             }*/
                            break;
                        }
<<<<<<< HEAD
                        if ((inventory.inventory[i] == requiment||requiment == null) && give )
                        {
                            //Debug.Log("succeeddddddddd");
                            Debug.Log("kuay1");
                            inventory.AddItem(item);
                            item.SetActive(false);
                            theTextBox.ReloadScript(unsucceedText);
                            if (theTextBox.currentLine >= endLine || theTextBox.currentLine == 0)
                            {
                                theTextBox.currentLine = startLine;
                            }
                            theTextBox.endAtLine = endLine;
                            theTextBox.EnableTextBox();
                            if (destroyWhenActivate)
                            {
                                Destroy(gameObject);
                            }
                            give = false;
                            break;
                        }
                       
                    }
                    if (succeed == false && onetime == true)
                    {
                        Debug.Log("Hee");
=======
                    }
                    if (succeed == false&&onetime == true)
                    {
>>>>>>> 755af25d6e09c252d2ae198862d68cb7802562ba
                        theTextBox.ReloadScript(unsucceedText);
                        if (theTextBox.currentLine >= endLine || theTextBox.currentLine == 0)
                        {
                            theTextBox.currentLine = startLine;
                        }
                        theTextBox.endAtLine = endLine;
                        theTextBox.EnableTextBox();
                        if (destroyWhenActivate)
                        {
                            Destroy(gameObject);
                        }
                        onetime = false;
                    }
<<<<<<< HEAD
             } 

         }
    }
            
}
=======
                    
                }
            }
            
          }
        }
>>>>>>> 755af25d6e09c252d2ae198862d68cb7802562ba
void OnTriggerEnter2D(Collider other)
{
    onetime = true;
    if (other.name == "Player")
    {
        if (!requireButtonPress)
        {
            {
<<<<<<< HEAD
                theTextBox.ReloadScript(succeedText);
=======
                theTextBox.ReloadScript(unsucceedText);
>>>>>>> 755af25d6e09c252d2ae198862d68cb7802562ba
                theTextBox.currentLine = startLine;
                theTextBox.endAtLine = endLine;
                theTextBox.EnableTextBox();
                if (destroyWhenActivate)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
    void OnTriggerExit2D(Collider2D other)
    {
        onetime = true;
        if (other.name == "Player")
        {
            waitForPress = false;
        }
    }
}
