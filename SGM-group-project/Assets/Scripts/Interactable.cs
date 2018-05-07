using UnityEngine;

public class Interactable : MonoBehaviour
{

    public float radius = 4f;
    public Transform interactionTransform;

    private GameObject player1;
    private GameObject player2;


    bool hasInteracted = false;

	void Start()
	{
        player1 = GameManagement.Instance.getPlayer1();
        player2 = GameManagement.Instance.getPlayer2();
	}

	public virtual void Interact()
    {
        Debug.Log("Interacting with " + transform.name);
    }

    void Update()
    {
        if (Input.GetButtonDown("Interact_P1")) 
        {
            Action(player1);
        } 


        if (Input.GetButtonDown("Interact_P2") )
        {
            Action(player2);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (interactionTransform == null)
            interactionTransform = transform;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }


	private void OnCollisionExit(Collision collision)
	{
        Debug.Log("collicion exited");
        hasInteracted = false;
	}

    private void Action(GameObject obj)
    {
        if (!hasInteracted)
        {
            float distance = Vector3.Distance(obj.transform.position, interactionTransform.position);
            if (distance <= radius)
            {
                Interact();
                hasInteracted = true;
            }
        }
        
    }
}