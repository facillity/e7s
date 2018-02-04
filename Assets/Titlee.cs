﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Titlee : MonoBehaviour
{

    public int pos;
    public GameObject menu;
    public Text red, orange, yellow, green, lightBlue, darkBlue, purple;

    // Use this for initialization
    void Start()
    {
        red = red.GetComponent<Text>();
        orange = orange.GetComponent<Text>();
        yellow = yellow.GetComponent<Text>();
        green = green.GetComponent<Text>();
        lightBlue = lightBlue.GetComponent<Text>();
        darkBlue = darkBlue.GetComponent<Text>();
        purple = purple.GetComponent<Text>();

    }

    public void turnOffColors()
    {
        red.enabled = false;
        orange.enabled = false;
        yellow.enabled = false;
        green.enabled = false;
        lightBlue.enabled = false;
        darkBlue.enabled = false;
        purple.enabled = false;
    }

    void turnRed()
    {
        turnOffColors();
        red.enabled = true;
    }

    void turnOrange()
    {
        turnOffColors();
        orange.enabled = true;
    }

    void turnYellow()
    {
        turnOffColors();
        yellow.enabled = true;
    }

    void turnGreen()
    {
        turnOffColors();
        green.enabled = true;
    }

    void turnLightBlue()
    {
        turnOffColors();
        lightBlue.enabled = true;
    }

    void turnDarkBlue()
    {
        turnOffColors();
        darkBlue.enabled = true;
    }

    void turnPurple()
    {
        turnOffColors();
        purple.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(menu.GetComponent<MenuScript>().IsRulesPressed());
        if (!menu.GetComponent<MenuScript>().IsButtonPressed())
        {
            pos = pos + 1;
            if (pos < 15)
            {
                turnRed();
            }
            else if (pos < 30)
            {
                turnOrange();
            }
            else if (pos < 45)
            {
                turnYellow();
            }
            else if (pos < 60)
            {
                turnGreen();
            }
            else if (pos < 75)
            {
                turnLightBlue();
            }
            else if (pos < 90)
            {
                turnDarkBlue();
            }
            else if (pos < 105)
            {
                turnPurple();
            }
            else if (pos <= 120)
            {
                turnRed();
                pos = 0;
            }
        }
        else
        {
            turnOffColors();
        }

    }
}