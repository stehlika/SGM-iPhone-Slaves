using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergingDistanceScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("toto je check " +CheckPossibleMerge(GameObject.FindGameObjectWithTag("Component1"),
                GameObject.FindGameObjectWithTag("Component2")));
        }
    }

    public bool CheckPossibleMerge(GameObject obj1, GameObject obj2)
    {
        Transform position1 = obj1.transform;
        Transform position2 = obj2.transform;
        Debug.Log("position 1 " + position1 + " position2 "+position2);
        float distance = Vector3.Distance(position1.position, position2.position);
        Debug.Log("Distance je " + distance);
        if(distance<10 && obj1.tag!=obj2.tag)
        {
            return true;
        }
        return false;

    }
}
