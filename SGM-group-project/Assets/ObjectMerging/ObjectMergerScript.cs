using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMergerScript : MonoBehaviour
{
    [SerializeField]
    private SpawnerScript spawner;
    [SerializeField]
    private DestroyerScript destroyer;
    [SerializeField]
    private MergingDistanceScript mergingDistanceScript;
    [SerializeField]
    private GameObject closedBox;
    [SerializeField]
    private GameObject Iphone;
    private bool isDone = false;
    private GameObject obj1ForMerge;
    private GameObject obj2ForMerge;
    [SerializeField]
    private SphereCasterScript sphereCasterScript;
    [SerializeField] PickUp pickup;
    [SerializeField] NearbyObjectsLocatorScript nearbyLocator;

    private void Start()
    {
        pickup = gameObject.GetComponentInChildren<PickUp>();

    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetButtonDown("Interact_P1") || Input.GetButtonDown("Interact_P2"))
        {
            //obj1ForMerge = GameObject.FindGameObjectWithTag("display");
            //obj2ForMerge = GameObject.FindGameObjectWithTag("body");
            //treba iny vyhladavaci mechanizmus, nie podla tagu ale podla toho co hrac vidi
            // a getnut to co drzi :)
            /*if (obj1ForMerge != null && obj2ForMerge != null
                && mergingDistanceScript.CheckPossibleMerge(obj2ForMerge, obj1ForMerge))
            {*/
            Debug.Log("Object held :" + pickup.getAttachedObject());
            if (pickup.getAttachedObject() != null)
            {
                Merge();
            }
        }

    }
    public void Merge()
    {
        GameObject objectHeld = pickup.getAttachedObject();

        switch (objectHeld.tag)
        {
            case "New Iphone":
                if(objectHeld.GetComponent<IphoneMonitorScript>().isReadyForPackage())
                destroyer.SetObjectToBeDestroyed(nearbyLocator.getClosestBox(pickup.getAttachedObject()));
                spawner.setObjectForSpawn(closedBox);
                classicMerge();
                break;
            case "Box": destroyer.SetObjectToBeDestroyed(nearbyLocator.getClosestIphone(pickup.getAttachedObject()));
                spawner.setObjectForSpawn(closedBox);
                classicMerge();
                break;
            default:
                destroyer.SetObjectToBeDestroyed(nearbyLocator.getFirstObjectForMerge(pickup.getAttachedObject()));
                spawner.setObjectForSpawn(Iphone);
                classicMerge();
                break;
        }
    }
    private void classicMerge() { 
        Debug.Log("TOTO je miesto" +nearbyLocator.getFirstObjectForMerge(pickup.getAttachedObject()));
        Transform spawnLocation = destroyer.GetSpawnLocation();
        GameObject objToBeDestroyed = destroyer.GetObjectToBeDestroyed();


        if (spawnLocation != null)
        {
            Debug.Log("TUTO SOM SA DOSTAL");
            spawner.setPosition(spawnLocation);
            GameObject FirstComponent = objToBeDestroyed;
            Debug.Log("FirstObjectToBEDestroyed = " + FirstComponent);
            destroyer.Action(); //tento znici ten ktory vidi na stole (na stole ide prvy lebo tam sa ma
                                //objavit novy objekt
            destroyer.SetObjectToBeDestroyed(pickup.getAttachedObject());
            //tento ho setne na to aby znicil ten ktory ma v ruke
            GameObject SecondComponent = destroyer.GetObjectToBeDestroyed();
            Debug.Log("secondObjectToBeDestroyed = " + SecondComponent);
            destroyer.Action();
            spawner.Action(FirstComponent, SecondComponent);
            spawnLocation = null;
        }
        else return;
    }
    private void specialSpawn()
    {
        Transform spawnLocation = destroyer.GetSpawnLocation();
        spawner.setObjectForSpawn(closedBox);
        GameObject objToBeDestroyed = destroyer.GetObjectToBeDestroyed();
        if (spawnLocation != null)
        {
            Debug.Log("TUTO SOM SA DOSTAL");
            spawner.setPosition(spawnLocation);
            GameObject FirstComponent = objToBeDestroyed;
            Debug.Log("FirstObjectToBEDestroyed = " + FirstComponent);
            destroyer.Action(); //tento znici ten ktory vidi na stole (na stole ide prvy lebo tam sa ma
                                //objavit novy objekt
            destroyer.SetObjectToBeDestroyed(pickup.getAttachedObject());
            //tento ho setne na to aby znicil ten ktory ma v ruke
            GameObject SecondComponent = destroyer.GetObjectToBeDestroyed();
            Debug.Log("secondObjectToBeDestroyed = " + SecondComponent);
            destroyer.Action();
            spawner.Action(FirstComponent, SecondComponent);
            spawnLocation = null;
        }
        else return;
    }

}
    
