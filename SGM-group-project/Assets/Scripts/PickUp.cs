using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour {

    [SerializeField] GameObject attachedOject;
    [SerializeField] float distance = 4f;
    [SerializeField] float objectDistance = 1.7f;
    [SerializeField] float smooth = 4f;
    private Rigidbody objectRigidbody;
    [SerializeField] private string pickUp;
    [SerializeField] private SphereCasterScript sphereCaster;

	// Use this for initialization
	void Start () 
    {
        pickUp  = GetComponentInParent<CharacterMovement>().pickUpControl;
        sphereCaster = GetComponentInParent<SphereCasterScript>();
	}
	
	// Update is called once per frame
	void Update () {
        if(attachedOject != null)
        {
            Carry();

            if(Input.GetButtonDown(pickUp))
            {
                Detach();
                return;
            }

        } else 
        {
            if (Input.GetButtonDown(pickUp)) {
                Attach();
            }
                
        }
	}

    void Carry()
    {
        attachedOject.transform.position = transform.position + transform.forward * objectDistance;
    }

    void Attach() 
    {
        /*RaycastHit hit;
        
        if(Physics.Raycast (transform.position, transform.forward, out hit, distance))
        { 
            Debug.Log("Infront of: " + hit.collider.gameObject.name);
            Pickupable pickupable = hit.collider.GetComponent<Pickupable>();
            if(pickupable != null)
            {
                attachedOject = pickupable.gameObject;
                objectRigidbody = attachedOject.GetComponent<Rigidbody>();
                attachedOject.GetComponent<Rigidbody>().isKinematic = true;
            } else 
            {
                Debug.LogWarning("Item is not pickupable");
            }
        } */
        try {
            Pickupable pickupable = sphereCaster.getCurrentObjectHit().GetComponent<Pickupable>();
            if (pickupable != null)
            {
                attachedOject = sphereCaster.getCurrentObjectHit();
                attachedOject.GetComponent<Rigidbody>().isKinematic = true;
            } 
        } catch (System.Exception exception)
        {
            Debug.LogWarning(exception.ToString());    
        }

    }

    public void Detach(){
        attachedOject.GetComponent<Rigidbody>().isKinematic = false;
        attachedOject = null;
    }

    public GameObject getAttachedObject()
    {
        return attachedOject;
    }

    public void AttachObject(GameObject attachObj)
    {
        attachedOject = attachObj;
        attachedOject.GetComponent<Rigidbody>().isKinematic = true;
    }
}
