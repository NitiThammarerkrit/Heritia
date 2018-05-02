using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextManager : MonoBehaviour
{

    public GameObject character;
    public TextAsset succeedText;
    public TextAsset unsucceedText;
    public TextAsset FirstText;
    public TextAsset OnetimeText;

    public int startLine;
    public int FirstTimeendLine;
    public int unsucceedendLine;
    public int succeedendLine;
    public int OnetimeendLine;

    public TextBoxmanager theTextBox;

    public bool destroyWhenActivate;
    public bool requireButtonPress;
    private bool waitForPress;
    public Sprite changeto;

    public GameObject canvas;
    public GameObject item;
    public GameObject gem;
    public Inventory inventory;
    public GameObject requiment;
    bool onetime = true;
    bool inconver = false;
    float delayfade = 2.5f;
    bool fade = false;
    bool FirstTime = true;
    // Use this for initialization
    void Start()
    { 

    }

    // Update is called once per frame
    void Update()
    {
        /*if (succeed == true && theTextBox.currentLine == succeedendLine + 1)
        {
            canvas.GetComponent<Fade>().Fades(true, 1.05f);
            fade = true;
            theTextBox.currentLine += 1;
        }
        if (fade == true)
        {
            delayfade -= 1 * Time.deltaTime;
        }
        canvas.GetComponent<Fade>().Fades(false, 1.25f);
        fade = false;
        delayfade = 2.5f;*/
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (requireButtonPress && !inconver)
            {
                Debug.Log("Getin2!!");
                if (Input.GetKeyDown(KeyCode.Z))
                {
                    Debug.Log("Getin3!!");
                    if (this.GetComponentInParent<Rigidbody2D>().name == "BUTCHER")
                    {
                        Debug.Log("BUTCHER!!");
                        if (GameData.events_complete[0] == true && FirstTime)
                        {
                            FirstTime = false;
                            theTextBox.ReloadScript(FirstText);
                            if (theTextBox.currentLine >= FirstTimeendLine || theTextBox.currentLine == 0)
                            {
                                theTextBox.currentLine = startLine;
                            }
                            theTextBox.endAtLine = FirstTimeendLine;
                            theTextBox.EnableTextBox();
                            inconver = true;
                        }
                        else
                        if (GameData.events_complete[0] == true && !FirstTime)
                        {
                            theTextBox.ReloadScript(succeedText);
                            if (theTextBox.currentLine >= succeedendLine || theTextBox.currentLine == 0)
                            {
                                theTextBox.currentLine = startLine;
                            }
                            theTextBox.endAtLine = succeedendLine;
                            theTextBox.EnableTextBox();
                            inconver = true;
                        }
                        for (int i = 0; i < inventory.inventory.Length; i++)
                        {
                            if ((inventory.inventory[i] != requiment && GameData.events_complete[0] == false))
                            {
                                theTextBox.ReloadScript(unsucceedText);
                                if (theTextBox.currentLine >= unsucceedendLine || theTextBox.currentLine == 0)
                                {
                                    theTextBox.currentLine = startLine;
                                }
                                theTextBox.endAtLine = unsucceedendLine;
                                theTextBox.EnableTextBox();
                                inconver = true;
                                break;
                            }
                        }
                        for (int i = 0; i < inventory.inventory.Length; i++)
                        {
                            if (inventory.inventory[i] == requiment && GameData.events_complete[0] == false)
                            {
                                theTextBox.issucceed = true;
                                theTextBox.number = 0;
                                inventory.RemoveItemfrominventory(inventory.inventory[i]);
                                theTextBox.ReloadScript(OnetimeText);
                                if (theTextBox.currentLine >= OnetimeendLine || theTextBox.currentLine == 0)
                                {
                                    theTextBox.currentLine = startLine;
                                }
                                theTextBox.endAtLine = OnetimeendLine;
                                theTextBox.EnableTextBox();
                                inconver = true;
                                break;
                            }
                        }
                    }
                    else
                    if (this.GetComponentInParent<Rigidbody2D>().name == "Ama")
                    {
                        Debug.Log("Ama!!");
                        if (FirstTime && GameData.events_complete[0] == false)
                        {
                            theTextBox.ReloadScript(FirstText);
                            if (theTextBox.currentLine >= FirstTimeendLine || theTextBox.currentLine == 0)
                            {
                                theTextBox.currentLine = startLine;
                            }
                            theTextBox.endAtLine = FirstTimeendLine;
                            theTextBox.EnableTextBox();
                            inventory.AddItem(item);
                            item.SetActive(false);
                            FirstTime = false;
                            inconver = true;
                        }
                        else
                        if (!FirstTime && GameData.events_complete[0] == false)
                        {
                            theTextBox.ReloadScript(unsucceedText);
                            if (theTextBox.currentLine >= unsucceedendLine || theTextBox.currentLine == 0)
                            {
                                theTextBox.currentLine = startLine;
                            }
                            theTextBox.endAtLine = unsucceedendLine;
                            theTextBox.EnableTextBox();
                            inconver = true;
                        }
                        else
                        if (!FirstTime && GameData.events_complete[0] == true)
                        {
                            theTextBox.ReloadScript(succeedText);
                            if (theTextBox.currentLine >= succeedendLine || theTextBox.currentLine == 0)
                            {
                                theTextBox.currentLine = startLine;
                            }
                            theTextBox.endAtLine = succeedendLine;
                            theTextBox.EnableTextBox();
                            inconver = true;
                        }
                    }
                    else
                    if (this.GetComponentInParent<Rigidbody2D>().name == "DOG")
                    {
                        Debug.Log("Dog!!");
                        if (GameData.events_complete[1] == true)
                        {
                            theTextBox.ReloadScript(FirstText);
                            if (theTextBox.currentLine >= FirstTimeendLine || theTextBox.currentLine == 0)
                            {
                                theTextBox.currentLine = startLine;
                            }
                            theTextBox.endAtLine = FirstTimeendLine;
                            theTextBox.EnableTextBox();
                            inconver = true;
                        }
                        for (int i = 0; i < inventory.inventory.Length; i++)
                        {
                            if ((inventory.inventory[i] != requiment && GameData.events_complete[1] == false))
                            {
                                theTextBox.ReloadScript(unsucceedText);
                                if (theTextBox.currentLine >= unsucceedendLine || theTextBox.currentLine == 0)
                                {
                                    theTextBox.currentLine = startLine;
                                }
                                theTextBox.endAtLine = unsucceedendLine;
                                theTextBox.EnableTextBox();
                                inconver = true;
                                break;
                            }
                        }
                        for (int i = 0; i < inventory.inventory.Length; i++)
                        {
                            if (inventory.inventory[i] == requiment && GameData.events_complete[1] == false)
                            {
                                inventory.RemoveItemfrominventory(inventory.inventory[i]);
                                theTextBox.issucceed = true;
                                theTextBox.number = 1;
                                theTextBox.ReloadScript(succeedText);
                                if (theTextBox.currentLine >= succeedendLine || theTextBox.currentLine == 0)
                                {
                                    theTextBox.currentLine = startLine;
                                }
                                theTextBox.endAtLine = succeedendLine;
                                theTextBox.EnableTextBox();
                                inconver = true;
                                break;
                            }
                        }
                    }
                    else
                    if (this.GetComponentInParent<Rigidbody2D>().name == "DEK")
                    {
                        Debug.Log("DEK!!");
                        if (FirstTime && GameData.events_complete[1] == false)
                        {
                            theTextBox.ReloadScript(FirstText);
                            if (theTextBox.currentLine >= FirstTimeendLine || theTextBox.currentLine == 0)
                            {
                                theTextBox.currentLine = startLine;
                            }
                            theTextBox.endAtLine = FirstTimeendLine;
                            theTextBox.EnableTextBox();
                            FirstTime = false;
                            inventory.AddItem(item);
                            item.SetActive(false);
                        }
                        else
                        if (!FirstTime && GameData.events_complete[1] == false)
                        {
                            theTextBox.ReloadScript(unsucceedText);
                            if (theTextBox.currentLine >= unsucceedendLine || theTextBox.currentLine == 0)
                            {
                                theTextBox.currentLine = startLine;
                            }
                            theTextBox.endAtLine = unsucceedendLine;
                            theTextBox.EnableTextBox();
                        }
                        else
                        if (GameData.events_complete[1] == true && onetime)
                        {
                            inventory.AddItem(gem);
                            gem.SetActive(false);
                            theTextBox.ReloadScript(OnetimeText);
                            if (theTextBox.currentLine >= OnetimeendLine || theTextBox.currentLine == 0)
                            {
                                theTextBox.currentLine = startLine;
                            }
                            theTextBox.endAtLine = OnetimeendLine;
                            theTextBox.EnableTextBox();
                            onetime = false;
                        }
                        else
                        if (GameData.events_complete[1] == true && !onetime)
                        {
                            theTextBox.ReloadScript(succeedText);
                            if (theTextBox.currentLine >= succeedendLine || theTextBox.currentLine == 0)
                            {
                                theTextBox.currentLine = startLine;
                            }
                            theTextBox.endAtLine = succeedendLine;
                            theTextBox.EnableTextBox();
                        }
                    }
                    else
                    if (this.GetComponentInParent<Rigidbody2D>().name == "COWBOII")
                    {
                        Debug.Log("COWBOII!!");
                        {
                            theTextBox.ReloadScript(unsucceedText);
                            if (theTextBox.currentLine >= unsucceedendLine || theTextBox.currentLine == 0)
                            {
                                theTextBox.currentLine = startLine;
                            }
                            theTextBox.endAtLine = unsucceedendLine;
                            theTextBox.EnableTextBox();
                        }
                    }
                    else
                    if (this.GetComponentInParent<Rigidbody2D>().name == "HUNTER")
                    {
                        for (int i = 0; i < inventory.inventory.Length; i++)
                        {
                            if (inventory.inventory[i] != requiment && GameData.events_complete[2] == false)
                            {
                                theTextBox.ReloadScript(unsucceedText);
                                if (theTextBox.currentLine >= unsucceedendLine || theTextBox.currentLine == 0)
                                {
                                    theTextBox.currentLine = startLine;
                                }
                                theTextBox.endAtLine = unsucceedendLine;
                                theTextBox.EnableTextBox();
                                inconver = true;
                                break;
                            }
                        }
                        for (int i = 0; i < inventory.inventory.Length; i++)
                        {
                            if (inventory.inventory[i] == requiment && GameData.events_complete[2] == false)
                            {
                                inventory.RemoveItemfrominventory(inventory.inventory[i]);
                                inventory.AddItem(gem);
                                gem.SetActive(false);
                                theTextBox.issucceed = true;
                                theTextBox.number = 2;
                                theTextBox.ReloadScript(succeedText);
                                if (theTextBox.currentLine >= succeedendLine || theTextBox.currentLine == 0)
                                {
                                    theTextBox.currentLine = startLine;
                                }
                                theTextBox.endAtLine = succeedendLine;
                                theTextBox.EnableTextBox();
                                inconver = true;
                                break;
                            }
                        }
                    }
                    else
                    if (this.GetComponentInParent<Rigidbody2D>().name == "Christine")
                    {
                        if (FirstTime && GameData.events_complete[2] == false)
                        {
                            theTextBox.ReloadScript(FirstText);
                            if (theTextBox.currentLine >= FirstTimeendLine || theTextBox.currentLine == 0)
                            {
                                theTextBox.currentLine = startLine;
                            }
                            theTextBox.endAtLine = FirstTimeendLine;
                            theTextBox.EnableTextBox();
                            FirstTime = false;
                            inventory.AddItem(item);
                            item.SetActive(false);
                        }
                        else
                        if (!FirstTime && GameData.events_complete[2] == false)
                        {
                            theTextBox.ReloadScript(unsucceedText);
                            if (theTextBox.currentLine >= unsucceedendLine || theTextBox.currentLine == 0)
                            {
                                theTextBox.currentLine = startLine;
                            }
                            theTextBox.endAtLine = unsucceedendLine;
                            theTextBox.EnableTextBox();
                        }
                    }
                    else
                    if (this.GetComponentInParent<Rigidbody2D>().name == "Chief")
                    {
                        if (GameData.events_complete[3] == false)
                        {
                            theTextBox.issucceed = true;
                            theTextBox.number = 3;
                            theTextBox.ReloadScript(unsucceedText);
                            if (theTextBox.currentLine >= unsucceedendLine || theTextBox.currentLine == 0)
                            {
                                theTextBox.currentLine = startLine;
                            }
                            theTextBox.endAtLine = unsucceedendLine;
                            theTextBox.EnableTextBox();
                            inconver = true;
                        }
                        else
                        if (GameData.events_complete[3] == true)
                        {
                            theTextBox.ReloadScript(succeedText);
                            if (theTextBox.currentLine >= succeedendLine || theTextBox.currentLine == 0)
                            {
                                theTextBox.currentLine = startLine;
                            }
                            theTextBox.endAtLine = succeedendLine;
                            theTextBox.EnableTextBox();
                            inconver = true;
                        }
                    }
                    else
                    if (this.GetComponentInParent<Rigidbody2D>().name == "Farmer")
                    {
                        theTextBox.ReloadScript(unsucceedText);
                        if (theTextBox.currentLine >= unsucceedendLine || theTextBox.currentLine == 0)
                        {
                            theTextBox.currentLine = startLine;
                        }
                        theTextBox.endAtLine = unsucceedendLine;
                        theTextBox.EnableTextBox();
                        inconver = true;
                    }
                    else
                    if(this.GetComponentInParent<Rigidbody2D>().name == "Woman")
                    {
                        theTextBox.ReloadScript(unsucceedText);
                        if (theTextBox.currentLine >= unsucceedendLine || theTextBox.currentLine == 0)
                        {
                            theTextBox.currentLine = startLine;
                        }
                        theTextBox.endAtLine = unsucceedendLine;
                        theTextBox.EnableTextBox();
                        inconver = true;
                    }
                    else
                    if(this.GetComponentInParent<Rigidbody2D>().name == "Lumberjack")
                    {
                        theTextBox.ReloadScript(unsucceedText);
                        if (theTextBox.currentLine >= unsucceedendLine || theTextBox.currentLine == 0)
                        {
                            theTextBox.currentLine = startLine;
                        }
                        theTextBox.endAtLine = unsucceedendLine;
                        theTextBox.EnableTextBox();
                        inconver = true;
                    }
                    else
                    if(this.GetComponentInParent<Rigidbody2D>().name == "Merchant")
                    {
                        for (int i = 0; i < inventory.inventory.Length; i++)
                        {
                            if (inventory.inventory[i] != requiment && GameData.events_complete[4] == false)
                            {
                                theTextBox.ReloadScript(unsucceedText);
                                if (theTextBox.currentLine >= unsucceedendLine || theTextBox.currentLine == 0)
                                {
                                    theTextBox.currentLine = startLine;
                                }
                                theTextBox.endAtLine = unsucceedendLine;
                                theTextBox.EnableTextBox();
                                inconver = true;
                                break;
                            }
                        }
                        for (int i = 0; i < inventory.inventory.Length; i++)
                        {
                            if (inventory.inventory[i] == requiment && GameData.events_complete[4] == false&&FirstTime)
                            {
                                inventory.AddItem(item);
                                item.SetActive(false);
                                theTextBox.ReloadScript(succeedText);
                                if (theTextBox.currentLine >= succeedendLine || theTextBox.currentLine == 0)
                                {
                                    theTextBox.currentLine = startLine;
                                }
                                theTextBox.endAtLine = succeedendLine;
                                theTextBox.EnableTextBox();
                                FirstTime = false;
                                inconver = true;
                                break;
                            }
                        }
                    }
                    else
                    if (this.GetComponentInParent<Rigidbody2D>().name == "Miner")
                    {
                        for (int i = 0; i < inventory.inventory.Length; i++)
                        {
                            if (inventory.inventory[i] != requiment && GameData.events_complete[4] == false && FirstTime)
                            {
                                inventory.AddItem(item);
                                item.SetActive(false);
                                theTextBox.ReloadScript(FirstText);
                                if (theTextBox.currentLine >= FirstTimeendLine || theTextBox.currentLine == 0)
                                {
                                    theTextBox.currentLine = startLine;
                                }
                                theTextBox.endAtLine = FirstTimeendLine;
                                theTextBox.EnableTextBox();
                                FirstTime = false;
                                inconver = true;
                                break;
                            }
                            else
                            if (inventory.inventory[i] != requiment && GameData.events_complete[4] == false && !FirstTime)
                            {
                                theTextBox.ReloadScript(unsucceedText);
                                if (theTextBox.currentLine >= unsucceedendLine || theTextBox.currentLine == 0)
                                {
                                    theTextBox.currentLine = startLine;
                                }
                                theTextBox.endAtLine = unsucceedendLine;
                                theTextBox.EnableTextBox();
                                FirstTime = false;
                                inconver = true;
                                break;
                            }
                        }
                        for (int i = 0; i < inventory.inventory.Length; i++)
                        {
                            if (inventory.inventory[i] == requiment && GameData.events_complete[4] == false)
                            {
                                inventory.RemoveItemfrominventory(inventory.inventory[i]);
                                for (int j = 0; j < inventory.inventory.Length; j++)
                                {
                                    if (inventory.inventory[j] == item)
                                    {
                                        inventory.RemoveItemfrominventory(inventory.inventory[j]);
                                    }
                                }
                                inventory.AddItem(gem);
                                gem.SetActive(false);
                                theTextBox.issucceed = true;
                                theTextBox.number = 4;
                                theTextBox.ReloadScript(succeedText);
                                if (theTextBox.currentLine >= succeedendLine || theTextBox.currentLine == 0)
                                {
                                    theTextBox.currentLine = startLine;
                                }
                                theTextBox.endAtLine = succeedendLine;
                                theTextBox.EnableTextBox();
                                inconver = true;
                                break;
                            }
                        }
                        if(GameData.events_complete[4] == true)
                        {
                            theTextBox.ReloadScript(OnetimeText);
                            if (theTextBox.currentLine >= OnetimeendLine || theTextBox.currentLine == 0)
                            {
                                theTextBox.currentLine = startLine;
                            }
                            theTextBox.endAtLine = OnetimeendLine;
                            theTextBox.EnableTextBox();
                            inconver = true;
                        }
                    }
                 inconver = true;
                }
                
            }
        }
    }
    void OnTriggerEnter2D(Collider other)
    {
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
        inconver = false;
        if (other.name == "Player")
        {
            waitForPress = false;
        }
    }
}
