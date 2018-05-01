using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TextBoxmanager : MonoBehaviour {

    public GameObject textBox;

    public Text theText;
    private string [] theTexttemp;
    private string[] theTextLinestemp;

    public TextAsset textfile;
    public string[] textLines;

    public int currentLine;
    public int endAtLine;

    public bool isActive;
    public Player player;

    public bool StopPlayerMovement;
    private bool isTyping = false;
    private bool cancelTyping = false;

    public bool issucceed = false;
    public int number;
    public float typeSpeed = 0;
    // Use this for initialization
    public void ReloadScript(TextAsset theText)
    {
        if (theText != null)
        {
           // textfile = theText;
            textLines = new string[1];
            textLines = (theText.text.Split('\n'));
            /*Debug.Log("text temp 1"+ textLines[0]);
            Debug.Log("text temp 2" + textLines[1]);
            theTexttemp = (textLines[j].Split(':'));
            typeSpeed = float.Parse(theTexttemp[i]);
            Debug.Log(typeSpeed);
            j++;
            i += 2;*/
            // theTexttemp = theText;  
        }
    }
    void Start () {
        player = FindObjectOfType<Player>();
        if (isActive)
        {
            EnableTextBox();
        }
        else
        {
            DisableTextBox();
        }
        player = FindObjectOfType<Player>();
        if (textfile != null)
        {
            //typeSpeed = (float)Convert.ToDouble(theText.text.Split(':'));
            textLines = new string[1];
            textLines = (theText.text.Split('\n'));
           /* Debug.Log("text 1 " + textLines[0]);
            Debug.Log("text 2 " + textLines[1]);
            theTexttemp = (textLines[j].Split(':'));
            typeSpeed = float.Parse(theTexttemp[i]);
            Debug.Log(typeSpeed);*/
        }

        if (endAtLine == 0)
        {
            endAtLine = textLines.Length - 1;
        }
       
	}
	
	// Update is called once per frame
	void Update () {
        /*if (currentLine >= endAtLine)
        {
            i = 0;
        }*/

        if (!isActive)
        {
            return;
        }
        // theText.text = textLines[currentLine];

        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (!isTyping)
            {
                currentLine += 1;
                if (currentLine > endAtLine)
                {
                    DisableTextBox();
                }
                else
                {
                    StartCoroutine(TextScroll(textLines[currentLine]));
                }
            }
            else
                if(isTyping&&!cancelTyping)
            {
                cancelTyping = true;
            }
        }
	}

    private IEnumerator TextScroll(string lineOfText)
    {
        int letter = 0;
        theText.text = "";
        isTyping = true;
        cancelTyping = false;
        theTextLinestemp = new string[1];
        theTextLinestemp = lineOfText.Split(':');
        while (isTyping && !cancelTyping && letter < lineOfText.Length - theTextLinestemp[0].Length - 1)
        {
           // Debug.Log(lineOfText.Length);
            //Debug.Log(i);
            string temptext = theTextLinestemp[1];
            typeSpeed = float.Parse(theTextLinestemp[0]); 
           // Debug.Log("typeSpeed" + typeSpeed);
            yield return new WaitForSeconds(typeSpeed);
            theText.text += temptext[letter];
            if(letter < lineOfText.Length)
            letter += 1;
        }
          // i += 1;
       // theText.text = lineOfText;
        isTyping = false;
        //cancelTyping = false;*/
    }

    public void EnableTextBox()
    {
        textBox.SetActive(true);
        isActive = true;
        player.canmove = false;
        StartCoroutine(TextScroll(textLines[currentLine]));
    }

    public void DisableTextBox()
    {
        isActive = false;
        textBox.SetActive(false);
        player.canmove = true;
        if (issucceed && currentLine > endAtLine)
        {
            GameData.events_complete[number] = true;
            issucceed = false;
            SaveLoad.Save();
        }
    }

   
}
