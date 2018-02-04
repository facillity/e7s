using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Tuple<T1, T2>
{
    public T1 First { get; private set; }
    public T2 Second { get; private set; }
    internal Tuple(T1 first, T2 second)
    {
        First = first;
        Second = second;
    }
}

public static class Tuple
{
    public static Tuple<T1, T2> New<T1, T2>(T1 first, T2 second)
    {
        var tuple = new Tuple<T1, T2>(first, second);
        return tuple;
    }
}

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
        //SendUpdate(allVariables.getPlayerColor(), ns.ToArray());
    }

    [SyncVar]
    private int ct = 0;

    private Hashtable confirms = new Hashtable();

    void Start () {
        //Button btn = yourButton.GetComponent<Button>();
        /*if (NetworkClient.active)*/
        //EventSendUpdate += SendUpdate;
        btn.onClick.AddListener(confirmed);
        //playerColor = allVariables.getPlayerColor();
        //myID = GetComponent<Gameboard>().getID();
    }

    public void SendUpdate(Tuple<Color, int[]> xxx)
    {
        ct += 1;
        confirms.Add(xxx.First, xxx.Second);
        Debug.Log("hello");
        if (ct == allVariables.getTotalPlayerCount())
        {
            Debug.Log("YEABOIIIIII");
            //allVariables.setCurrentScore(5);
            combineBoards();
            ct = 0;
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
        //CmdDoMe();
        List<int> ns = gameObject.GetComponent<Gameboard>().numset;
        //SendUpdate(allVariables.getPlayerColor(), ns.ToArray());
        var p = new Tuple<Color, int[]>(allVariables.getPlayerColor(), ns.ToArray());
        BroadcastMessage("SendUpdate", p);
        confirms.Clear();
    }
}
