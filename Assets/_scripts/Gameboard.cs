using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gameboard : MonoBehaviour {

    private float buttonWidth;                                       
    private float buttonHeight;
    public Button prefab;
    private Button button;
    public int ID;
    public List<int> numset = new List<int>();
    List<int> Blackset = new List<int>();

    public void Start()
    {
        int playerNum = 5;
        ID = 1;
        RectTransform myRect = GetComponent<RectTransform>();        
        buttonHeight = myRect.rect.height / (float)playerNum;            
        buttonWidth = myRect.rect.width / (float)playerNum;            
        GridLayoutGroup grid = this.GetComponent<GridLayoutGroup>();
        grid.cellSize = new Vector2(buttonWidth, buttonHeight);
        for (int i = 0; i < playerNum; i++)
        {
            for (int j = 0; j < playerNum; j++)
            {
                button = (Button)Instantiate(prefab);
                button.transform.SetParent(transform, false);
                button.GetComponent<TileController>().myID = getID();
                //addToSet(button.GetComponent<TileController>().myID);
            }
        }    
    }

    public int getID()
    {
        return ID++;
    }

    public void addToSet(int num)
    {
        Debug.Log("Added " + num.ToString() + " to set");
        numset.Add(num);
    }

    public void removeFromSet(int num)
    {
        Debug.Log("Removed " + num.ToString() + " from set");
        numset.Remove(num);
    }

    public void updateBoard(Hashtable T)
    {
        foreach (DictionaryEntry entry in T)
            Debug.Log("enter room : " + entry.Key + " " + entry.Value);
        foreach (DictionaryEntry x in T)
        {
            if (x.Key.Equals(allVariables.getPlayerColor()) ) { } // return if player is you.
            else
            {
                foreach (int VID in T.Values)
                {
                    if (numset.Contains(VID))
                    {
                        Blackset.Add(VID);
                    }
                }
            }
        }
        fillBlackSetAndScore();
        resetStuf();
    }

    public void fillBlackSetAndScore()
    {
        foreach(Transform chil in transform)
        {
            
            if (Blackset.Contains(chil.GetComponent<TileController>().myID))
            {
                chil.GetComponent<Image>().color = Color.black;
            }
            if (chil.GetComponent<Image>().color == allVariables.getPlayerColor())
            {
                GetComponentInParent<Player>().setTotalBetAmount(GetComponentInParent<Player>().getTotalBetAmount() + 1);
            }
        }
        resetStuf();
    }

    public void resetStuf()
    {
        numset.Clear();
        Blackset.Clear();
        foreach (Transform chil in transform)
        {

            if (chil.GetComponent<Image>().color != Color.black)
            {
                chil.GetComponent<Image>().color = Color.white;
            }
        }
    }

	
	// Update is called once per frame
	public void Update ()
    {

    }
}
