using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class MenuScript : MonoBehaviour {
    public Button start;
    public Button rules;
    public Button credits;
    public Button backButton;
    public Button nextButton;
    public Text next;
    public Text back;
    public Text creditsText;
    public Text rulesText;
    public Text startText;
    //public TextMeshProUGUI title;
    public bool ButtonIsPressed;
    public Text instructions;
    public Text creds;
    public GameObject diagram;
    public GameObject menu;


    // Use this for initialization
    public void Start () {
        ButtonIsPressed = false;
        start = start.GetComponent<Button>();
        nextButton = nextButton.GetComponent<Button>();
        next.enabled = false;
        startText = startText.GetComponent<Text>();
        rulesText = rulesText.GetComponent<Text>();
        credits = credits.GetComponent<Button>();
        creditsText = creditsText.GetComponent<Text>();
        diagram.SetActive(false);
        backButton = backButton.GetComponent<Button>();
        back = back.GetComponent<Text>();
        instructions = instructions.GetComponent<Text>();
        creds = creds.GetComponent<Text>();
        backButton.enabled = false;
        backButton.GetComponentInChildren<CanvasRenderer>().SetAlpha(0);
        nextButton.enabled = false;
        nextButton.GetComponentInChildren<CanvasRenderer>().SetAlpha(0);
        back.enabled = false;
        instructions.enabled = false;
        creds.enabled = false;



	}
	

	public void BackPress () {
        start.enabled = true;
        startText.enabled = true;
        creditsText.enabled = true;
        credits.enabled = true;
        rules.enabled = true;
        rulesText.enabled = true;
        back.enabled = false;
        backButton.enabled = false;
        backButton.GetComponentInChildren<CanvasRenderer>().SetAlpha(0);
        credits.GetComponentInChildren<CanvasRenderer>().SetAlpha(0);
        nextButton.enabled = false;
        diagram.SetActive(false);
        nextButton.GetComponentInChildren<CanvasRenderer>().SetAlpha(0);
        next.enabled = false;
        instructions.enabled = false;
        creds.enabled = false;
        ButtonIsPressed = false;
	}

    public void PlayPress () {
    }

    public void CreditsPress()
    {
        creds.enabled = true;
        ButtonIsPressed = true;
        start.enabled = false;
        startText.enabled = false;
        credits.enabled = false;
        rules.enabled = false;
        rules.GetComponentInChildren<CanvasRenderer>().SetAlpha(0);
        start.GetComponentInChildren<CanvasRenderer>().SetAlpha(0);
        credits.GetComponentInChildren<CanvasRenderer>().SetAlpha(0);
        creditsText.enabled = false;
        rules.enabled = false;
        rulesText.enabled = false;
        back.enabled = true;
        backButton.enabled = true;
    }

    public void RulesPress()
    {
        ButtonIsPressed = true;
        // GetComponentInChildren<TextMeshProUGUI>().enabled = false;
        menu.GetComponent<Titlee>().turnOffColors();
        nextButton.enabled = true;
        next.enabled = true;
        start.enabled = false;
        startText.enabled = false;
        credits.enabled = false;
        creditsText.enabled = false;
        rules.enabled = false;
        rulesText.enabled = false;
        rules.GetComponentInChildren<CanvasRenderer>().SetAlpha(0);
        credits.GetComponentInChildren<CanvasRenderer>().SetAlpha(0);
        start.GetComponentInChildren<CanvasRenderer>().SetAlpha(0);
        instructions.enabled = true;
        back.enabled = true;
        backButton.enabled = true;
    }

    public void NextPress()
    {
        instructions.enabled = false;
        diagram.SetActive(true);
        nextButton.enabled = false;
        nextButton.GetComponentInChildren<CanvasRenderer>().SetAlpha(0);
        next.enabled = false;

    }
    
    public bool IsButtonPressed()
    {
        return ButtonIsPressed;

    }
}
