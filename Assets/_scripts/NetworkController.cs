using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class NetworkController : NetworkBehaviour {
    public Button btn;
    // Use this for initialization

    public delegate void SendUpdateDelegate(Color color, int[] locs);

    [SyncEvent]
    public event SendUpdateDelegate EventSendUpdate;

    [Command]
    public void CmdDoMe()
    {
        List<int> ns = gameObject.GetComponent<Gameboard>().numset;
        SendUpdate(allVariables.getPlayerColor(), ns.ToArray());
    }

    [SyncVar]
    private int ct = 0;

    private Hashtable confirms = new Hashtable();

    void Start () {
        //Button btn = yourButton.GetComponent<Button>();
        if (NetworkClient.active)
            EventSendUpdate += SendUpdate;
        btn.onClick.AddListener(confirmed);
        //playerColor = allVariables.getPlayerColor();
        //myID = GetComponent<Gameboard>().getID();
    }

    public void SendUpdate(Color color, int[] locs)
    {
        ct += 1;
        confirms.Add(color, locs);
        Debug.Log("hello");
        if (ct == allVariables.getTotalPlayerCount())
        {
            Debug.Log("YEABOIIIIII");
            //allVariables.setCurrentScore(5);
            combineBoards();
           
        }
    }

    public void combineBoards()
    {
        GetComponent<Gameboard>().updateBoard(confirms);
        confirms.Clear();
    }

    // Update is called once per frame
    void Update () {
		
	}

    void confirmed ()
    {
        Debug.Log("entered");
        CmdDoMe();
        confirms.Clear();
    }
}
