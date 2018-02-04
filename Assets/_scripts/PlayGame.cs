using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	public void ChangeScene()
    {
        SceneManager.LoadScene("gamelobby");
    }
	// Update is called once per frame
	void Update () {
		
	}
}
