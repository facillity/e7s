using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ActualTitleController : MonoBehaviour {

    public int pos;
    public static int cycle = 60;
    public GameObject menu; 
	// Use this for initialization
	void Start () {

	}

    // Update is called once per frame
    void Update() {
        //Debug.Log(menu.GetComponent<MenuScript>().IsRulesPressed());
        if (!menu.GetComponent<MenuScript>().IsButtonPressed())
        {
            pos = (pos + 1) % cycle;
            if (pos < 15)
            {
                GetComponentInChildren<TextMeshProUGUI>().enabled = true;
            }
            if (pos > 15)
            {
                GetComponentInChildren<TextMeshProUGUI>().enabled = false;
            }
        }
        else
        {
            GetComponentInChildren<TextMeshProUGUI>().enabled = false;
        }
        
	}
}
