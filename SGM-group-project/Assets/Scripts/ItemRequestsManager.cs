using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemRequestsManager : MonoBehaviour
{
    [SerializeField] Sprite sprite;


    ItemRequest[] requests;
    ItemRequest currentRequest;
    [SerializeField] private int currentRequestIndex = 0;
    [SerializeField] float previousValue;
    [SerializeField] float timeValue;

    [SerializeField] GameObject ItemRequestUIPrefab;
    [SerializeField] GameObject ItemRequestUIPrefab1;


    private WaitForSeconds skipFrames = new WaitForSeconds(1);

    // Use this for initialization
    void Start()
    {

        requests = ItemRequestsFactory.Instance.getLevel01();
        currentRequest = requests[0];

        previousValue = currentRequest.timeToBuild;
        StartCoroutine(DecrementTime());

    }

    IEnumerator DecrementTime()
    {
        for (; ; ) { 
            setUpRequest();
            yield return skipFrames;
        }

    }

    void setUpRequest()
    {
        if(currentRequest.timeToBuild == 0)
        {
            Debug.LogWarning("Should take new ");
            currentRequestIndex++;
            currentRequest = requests[currentRequestIndex];
            spawnNewItemRequest();

        }

        if(currentRequestIndex == (requests.Length - 1))
        {
           // spawnNewItemRequest();


            //Should end the game
            //

            return;
        }

        currentRequest.timeToBuild--;

        timeValue = (float)currentRequest.timeToBuild / (float)previousValue;

        ItemRequestUIPrefab.GetComponent<ItemRequestUI>().UpdateUI(currentRequest, timeValue);


        Debug.LogWarning("Current index: " + currentRequestIndex);

    }

    private void spawnNewItemRequest()
    {
        //ItemRequestUIPrefab1.SetActive(true);

        //Debug.LogWarning("Should end the current reqiest");
        //GameObject requestUI = GameObject.FindGameObjectWithTag("ItemRequestUI");

        //GameObject objectToSpawn = Instantiate(ItemRequestUIPrefab);

        //Vector3 newPosition = new Vector3(transform.position.x + 5f, transform.position.y, transform.position.z);
        //objectToSpawn.transform.position = newPosition;
        //objectToSpawn.transform.rotation = transform.rotation;
        //objectToSpawn.SetActive(true);
        
    }


    public void ItemWasHandedIn(GameObject handedIn)
    {
        // Should dissapear currently making thing than update th ui with another request 
        Debug.Log("Item was handed in should update UI ");

        Debug.LogWarning("Should take new ");
        currentRequestIndex++;
        currentRequest = requests[currentRequestIndex];
        spawnNewItemRequest();
    }
}



// Make function that will handle the item requests countdown works. It should be like 
// You spawn firts request than wait some time (lets say 5 seconds before dealine) a new 
// Item request would be spawned. 
