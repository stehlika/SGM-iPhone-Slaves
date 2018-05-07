using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IphoneMonitorScript : MonoBehaviour {
    [SerializeField]
    private bool display;
    [SerializeField]
    private bool body;
    [SerializeField]
    private bool inside = true;
    [SerializeField]
    private bool box;


    public bool Display
    {
        get
        {
            return display;
        }

        set
        {
            display = value;
        }
    }

    public bool Body
    {
        get
        {
            return body;
        }

        set
        {
            body = value;
        }
    }

    public bool Inside
    {
        get
        {
            return inside;
        }

        set
        {
            inside = value;
        }
    }

    public bool Box
    {
        get
        {
            return box;
        }

        set
        {
            box = value;
        }
    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public bool isReadyForPackage()
    {
        return Display && Body && Inside && !box;
    }
    public bool isCompletelyReady()
    {
        return isReadyForPackage() && Box;
    }
    public void setFullyReady()
    {
        display = true;
        body = true;
        inside = true;
        box = true;
    }
}
