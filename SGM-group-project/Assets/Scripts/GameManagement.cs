using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagement : MonoBehaviour {

    public static GameManagement Instance;

    private void Awake()
    {
        Instance = this;
    }

    [SerializeField] private GameObject player1;
    [SerializeField] private GameObject player2;

    public GameObject getPlayer1() {
        return player1;
    }

    public GameObject getPlayer2()
    {
        return player2;
    }

    public GameObject getPlayer1HoldingObject()
    {
        PickUp pickUpScript = (PickUp)player1.GetComponentInChildren(typeof(PickUp)) as PickUp;

        return pickUpScript.getAttachedObject();
    }

    public GameObject getPlayer2HoldingObject()
    {
        PickUp pickUpScript = (PickUp)player2.GetComponent(typeof(PickUp));

        return pickUpScript.getAttachedObject();
    }
}
