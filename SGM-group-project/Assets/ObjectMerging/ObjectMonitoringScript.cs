using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMonitoringScript : MonoBehaviour {
    private static ObjectMonitoringScript instance = null;
    private ObjectMonitoringScript()
    {
    }
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void NotifyIphone(GameObject toBePerformedActionOn, IphoneMonitorScript script)
    {
        IphoneMonitorScript iphoneMonitor = script;
        if (toBePerformedActionOn.tag == "display")
        {
            iphoneMonitor.Display = true;
        }
        if (toBePerformedActionOn.tag == "body")
        {
            iphoneMonitor.Body = true;
        }
        if (toBePerformedActionOn.tag == "inside")
        {
            iphoneMonitor.Inside = true;
        }
        if (toBePerformedActionOn.tag == "box")
        {
            iphoneMonitor.Box = true;
        }
    }
    public static ObjectMonitoringScript getInstance()
    {
        if (instance != null)
            return instance;
        else return new ObjectMonitoringScript();
    }
}
