using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour {
    [SerializeField]
    private Transform position;
    [SerializeField]
    private GameObject spawnedObject;
    [SerializeField]
    private GameObject effect;
    private GameObject obj;
    private ObjectMonitoringScript objectMonitor;

    // Update is called once per frame
    void Update () {
      
	}
    public void Action(GameObject obj1, GameObject obj2)
    {
        if (obj1.tag == "Box" || obj1.tag == "New Iphone")

        {
            obj = Instantiate(spawnedObject, position.position, position.rotation);
            obj.AddComponent<IphoneMonitorScript>();
            obj.GetComponent<IphoneMonitorScript>().setFullyReady();
        }
        else
        {
            //Instantiate(effect, position.position, position.rotation);
            obj = Instantiate(spawnedObject, position.position, position.rotation);
            obj.AddComponent<IphoneMonitorScript>();
            obj.AddComponent<Pickupable>();
            obj.tag = "New Iphone";

            IphoneMonitorScript script = obj.GetComponent<IphoneMonitorScript>();


            objectMonitor = ObjectMonitoringScript.getInstance();
            objectMonitor.NotifyIphone(obj1, script);
            objectMonitor.NotifyIphone(obj2, script);
            //the idea is to attach a monitoring script to the clone of the prefab created :)
            // therefore every object created contains information about themselves
        }

    }
    public void setPosition(Transform position)
    {
        this.position = position;
    }
    public GameObject GetObjectForSpawn()
    {
        return this.spawnedObject;
    }
    public void setObjectForSpawn(GameObject obj) {
        spawnedObject = obj;
    }
}
