using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialDispenser : Interactable {

    [SerializeField] private GameObject prefab;

	public override void Interact()
	{
        base.Interact();

        GameObject objectToSpawn = Instantiate(prefab);
        Vector3 newPosition = new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z);
        objectToSpawn.transform.position = newPosition;
        objectToSpawn.transform.rotation = transform.rotation;
        objectToSpawn.SetActive(true);


   	}
}


