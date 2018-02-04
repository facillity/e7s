using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TitleController : MonoBehaviour {

    public int currentIndex = 0;
    private int nextIndex;

    public GameObject[] gradients = new GameObject[4];
    public GameObject t1;
    public GameObject t2;
    public GameObject t3;
    public GameObject t4;
    //public GameObject[] gradients = {[ t1, t2, t3, t4};
    public float changeColor = 2.0f;
    private float timer = 0.0f;

    // Use this for initialization
    void Start() {
        gradients[0] = t1;
        gradients[1] = t2;
        gradients[2] = t3;
        gradients[3] = t4;
        t1.GetComponent<Renderer>().enabled = true;
        t1.SetActive(true);

        for (int i = 1; i < 4; i++)
        {
            gradients[i].GetComponent<Renderer>().enabled = false;
            gradients[i].SetActive(false);
        }
        //TextMeshPro text = GetComponent<TextMeshPro>();
    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log("testing!!");

        timer += Time.deltaTime;
        if (timer > changeColor)
        {
            currentIndex = (currentIndex+1) % gradients.Length;
            timer = 0.0f;
            if (currentIndex == 4)
                currentIndex = 0;
        }
        gradients[currentIndex].GetComponent<Renderer>().enabled = true;
        gradients[currentIndex].SetActive(true);
        for (int i = 0; i < 4; i++)
        {
            if (i != currentIndex)
            {
                gradients[i].GetComponent<Renderer>().enabled = false;
                gradients[i].SetActive(false);
            }
        }
        
		
	}
}
