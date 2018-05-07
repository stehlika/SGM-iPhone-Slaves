using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereCasterScript : MonoBehaviour {
    public GameObject gameObjectHit;

    [SerializeField]
    private float radius;
    [SerializeField]
    private float maxDistance;
    public LayerMask layerMask;

    private Vector3 origin;
    private Vector3 direction;

    public float currentHitDistance;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        getCurrentObjectHit();
        origin =new Vector3(transform.position.x,transform.position.y+4f,transform.position.z);
        direction = transform.forward;

        RaycastHit hit;
        if (Physics.SphereCast(origin, radius, direction, out hit,
            maxDistance, layerMask, QueryTriggerInteraction.UseGlobal))
        {
            currentHitDistance = hit.distance;
            gameObjectHit = hit.transform.gameObject;
        }
        else
        {
            currentHitDistance = maxDistance;
            gameObjectHit = null;
        }

	}


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Debug.DrawLine(origin, origin + direction * currentHitDistance);
        Gizmos.DrawWireSphere(origin + direction * currentHitDistance, radius);
    }
    public GameObject getCurrentObjectHit()
    {
        
//        Debug.Log("hitting the object " + gameObjectHit);
        return gameObjectHit;
    }
}
