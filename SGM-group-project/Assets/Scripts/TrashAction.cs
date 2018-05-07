using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashAction : Interactable {


	public override void Interact()
	{
        base.Interact();

        // Should destroy object in hand;
        Destroy(GameManagement.Instance.getPlayer1HoldingObject());



	}

	private void OnCollisionStay(Collision collision)
	{
        Debug.Log("Collision with: " + collision.gameObject.name);


        PickUp pickupable = collision.collider.GetComponent<PickUp>();
        GameObject attachedObject = pickupable.getAttachedObject();

        if (attachedObject != null)
        {
            Destroy(attachedObject);

        }
        else
        {
            Debug.LogWarning("Item is not pickupable");
        }
	}
}
