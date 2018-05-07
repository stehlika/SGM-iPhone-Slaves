using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerScript : MonoBehaviour {
    [SerializeField]
    private GameObject objectToDestroy;
    /*[SerializeField]
    private GameObject anotherObjectToDestroy;*/
	
	// Update is called once per frame
	void Update () {
        
	}

    public void Action()
    {
        //Tuna nam treba iny selection (basically musime do objectToDestroy
        //a do anotherObjectToDestroy nejako napasovat objectKtoryMasVRuke
        //a objectKtoryJeNaStole a in the meantime checkovat ci su vobec kompatibilne
        // --nemiesat pocitac s telefonom atd--).
        /*anotherObjectToDestroy = GameObject.FindGameObjectWithTag(anotherObjectToDestroy.tag);
        Destroy(anotherObjectToDestroy);*/
        Destroy(objectToDestroy);
        
    }
    public Transform GetSpawnLocation()
    {

       if (objectToDestroy!=null){
            Transform temp = null;
            temp = objectToDestroy.transform;

            return temp;
        } return null;

    }
    public void SetObjectToBeDestroyed(GameObject obj1)
    {
        this.objectToDestroy = obj1;
    }
    public GameObject GetObjectToBeDestroyed()
    {
        return objectToDestroy;
    }
}
