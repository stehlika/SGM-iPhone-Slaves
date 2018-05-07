using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MakeBox : MonoBehaviour
{

    [SerializeField] GameObject boxPrefab;
    [SerializeField] float timeToPress = 3.0f;

    [SerializeField] float pressingTimer = 0.0f;
    [SerializeField] bool inProgress = false;

    [SerializeField] Slider timeSlider;

    [SerializeField] GameObject enteredPlayer;


	private void Update()
	{
	}


    private void OnTriggerEnter(Collider other)
    {
        enteredPlayer = other.gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        enteredPlayer = null;
        pressingTimer = 0f;
        timeSlider.value = pressingTimer;

    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetButton("Interact_P1") || Input.GetButton("Interact_P2"))
        {
            float currentValue = pressingTimer / timeToPress;
            timeSlider.value = currentValue;

            pressingTimer += Time.deltaTime;

            if (pressingTimer > timeToPress)
            {
                //Should make a new box
                SpawnBox();
            }
        }

    }

    private void SpawnBox()
    {
        // Instantiate new box
        pressingTimer = 0f;


        GameObject objectToSpawn = Instantiate(boxPrefab);
        Vector3 newPosition = new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z);
        objectToSpawn.transform.position = newPosition;
        objectToSpawn.transform.rotation = transform.rotation;
        objectToSpawn.SetActive(true);

        Debug.Log(enteredPlayer.name);

        enteredPlayer.GetComponent<PickUp>().AttachObject(objectToSpawn);

    }

}
