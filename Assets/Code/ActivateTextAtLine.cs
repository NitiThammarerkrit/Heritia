using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTextAtLine : MonoBehaviour {

    public GameObject character; 
    public TextAsset succeedText;
    public TextAsset unsucceedText;
    public TextAsset FirstText;

    public int startLine;
    public int FirstTimeendLine;
    public int unsucceedendLine;
    public int succeedendLine;

    public TextBoxmanager theTextBox;

    public bool destroyWhenActivate;
    public bool requireButtonPress;
    private bool waitForPress;
    public Sprite changeto;

    public GameObject item;
    public Inventory inventory;
    public GameObject requiment;
    public bool arrive = false;
    bool firsttime = true;
    bool succeed = false;
    bool onetime = true;
    bool FirstTime;
    bool inconver=true;
    // Use this for initialization
    void Start () {
        //theTextBox = FindObjectOfType<TextBoxmanager>();
        //succeed = false;
        if (character.gameObject.name == "BUTCHER")
        {
            FirstTime = false;
        }
        else
        {
            FirstTime = true;
        }

    }
	
	// Update is called once per frame
	void Update () {

		
	}

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            if (requireButtonPress && inconver)
            {
                if (Input.GetKeyDown(KeyCode.Z))
                {
                    for (int i = 0; i < inventory.inventory.Length; i++)
                    {
                        if (requiment != null && (inventory.inventory[i] == requiment))
                        {
                            Debug.Log("kuay5");
                            succeed = true;
                            inventory.RemoveItemfrominventory(inventory.inventory[i]);
                            //inventory.AddItem(item);
                            //Destroy(item);
                            theTextBox.ReloadScript(succeedText);
                            if (theTextBox.currentLine >= succeedendLine || theTextBox.currentLine == 0)
                            {
                                theTextBox.currentLine = startLine;
                            }
                            theTextBox.endAtLine = succeedendLine;
                            theTextBox.EnableTextBox();
                            if (destroyWhenActivate)
                             {
                                 Destroy(gameObject);
                             }
                            break;
                        }
                        
                        if ((inventory.inventory[i] == requiment || requiment == null) && FirstTime)
                        {
                            //Debug.Log("succeeddddddddd");
                            Debug.Log("kuay1");
                            inventory.AddItem(item);
                            item.SetActive(false);
                            theTextBox.ReloadScript(FirstText);
                            if (theTextBox.currentLine >= FirstTimeendLine || theTextBox.currentLine == 0)
                            {
                                theTextBox.currentLine = startLine;
                            }
                            theTextBox.endAtLine = FirstTimeendLine;
                            theTextBox.EnableTextBox();
                            if (destroyWhenActivate)
                            {
                                Destroy(gameObject);
                            }
                            FirstTime = false;
                            break;
                        }
                        
                        if (requiment == null && !FirstTime && onetime == true && (character.gameObject.name != "BUTCHER"))
                        {
                            Debug.Log("succeeddddddddd");
                            theTextBox.ReloadScript(unsucceedText);
                            if (theTextBox.currentLine >= unsucceedendLine || theTextBox.currentLine == 0)
                            {
                                theTextBox.currentLine = startLine;
                            }
                            theTextBox.endAtLine = unsucceedendLine;
                            theTextBox.EnableTextBox();
                            if (destroyWhenActivate)
                            {
                                Destroy(gameObject);
                            }
                            onetime = false;
                            break;
                        }

                        if (onetime == true)
                        {
                            //succeed = true;
                            if(succeed == false)
                            {
                                Debug.Log("Hee");
                                theTextBox.ReloadScript(unsucceedText);
                                if (theTextBox.currentLine >= unsucceedendLine || theTextBox.currentLine == 0)
                                {
                                    theTextBox.currentLine = startLine;
                                }
                                theTextBox.endAtLine = unsucceedendLine;
                                theTextBox.EnableTextBox();
                                if (destroyWhenActivate)
                                {
                                    Destroy(gameObject);
                                }
                                onetime = false;
                                break;
                            }
                            
                        }
                        
                        if (succeed == true && character.gameObject.name == "BUTCHER" && onetime == true && arrive)
                        {
                            Debug.Log("sasssss");
                            theTextBox.ReloadScript(FirstText);
                            if (theTextBox.currentLine >= FirstTimeendLine || theTextBox.currentLine == 0)
                            {
                                theTextBox.currentLine = startLine;
                            }
                            theTextBox.endAtLine = FirstTimeendLine;
                            theTextBox.EnableTextBox();
                            if (destroyWhenActivate)
                            {
                                Destroy(gameObject);
                            }
                            onetime = false;
                            break;
                        }
                    }
                    inconver = false;
                }
            }
        }

    }
void OnTriggerEnter2D(Collider other)
{
    onetime = true;
        inconver = true;
    if (other.name == "Player")
    {
        if (!requireButtonPress)
        {
            {
                theTextBox.ReloadScript(unsucceedText);
                theTextBox.currentLine = startLine;
                theTextBox.endAtLine = unsucceedendLine;
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
        if (succeed)
        {
            character.GetComponent<EnemyController>().enabled = true;
            character.GetComponent<SpriteRenderer>().sprite = changeto;
        }
        onetime = true;
        inconver = true;
        if (other.name == "Player")
        {
            waitForPress = false;
        }
    }
}
