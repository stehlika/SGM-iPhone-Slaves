using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NearbyObjectsLocatorScript : MonoBehaviour {
    [SerializeField] private float radius;
    [SerializeField] private  GameObject theClosestOne;
	// Use this for initialization
	void Start () {
        radius = 5f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public GameObject[] getPossibleNearbyObjects(GameObject obj)
    {
        Collider[] colliders = Physics.OverlapSphere(obj.transform.position, radius);
        GameObject[] possibleGameObjects = new GameObject[colliders.Length];
        List<GameObject> listok = new List<GameObject>();
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject.tag != obj.tag && colliders[i].GetComponent<Pickupable>()!=null)
            {
                listok.Add(colliders[i].gameObject);
            }
        }
        possibleGameObjects = listok.ToArray();
        return possibleGameObjects;
        

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
    public GameObject getFirstObjectForMerge(GameObject obj)
    {
        float distance = radius;
        
        foreach (var item in getPossibleNearbyObjects(obj))
        {
            if (Vector3.Distance(obj.transform.position, item.transform.position) < distance
                && item.tag!="New Iphone" && item.tag!="Box") //this is just for now, if we had 3 components we have to somehow
                //make sure that the iphone is handled differently and that the checkbox are interacted
                //properly and with respect :)
            {
                distance = Vector3.Distance(obj.transform.position, item.transform.position);
                theClosestOne = item;
            }
        }
        return theClosestOne;
    }
    public GameObject getClosestBox(GameObject obj)
    {
        float distance = radius;
        foreach (var item in getPossibleNearbyObjects(obj))
        {
            if (Vector3.Distance(obj.transform.position, item.transform.position) < distance
                && (item.tag=="Box" && item.GetComponent<IphoneMonitorScript>()==null))
            {
                distance = Vector3.Distance(obj.transform.position, item.transform.position);
                theClosestOne = item;
            }
 
        }
        return theClosestOne;
    }
    public GameObject getClosestIphone(GameObject obj)
    {
        float distance = radius;
        foreach (var item in getPossibleNearbyObjects(obj))
        {
            if (Vector3.Distance(obj.transform.position, item.transform.position) < distance
                && item.GetComponent<IphoneMonitorScript>().isReadyForPackage())
            {
                distance = Vector3.Distance(obj.transform.position, item.transform.position);
                theClosestOne = item;
            }

        }
        return theClosestOne;
    }
}


