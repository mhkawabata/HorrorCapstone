using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float interactRadius = 3f;
    public Transform interactionTransform; //used to check for doors, one sided interaction things etc. put an empty gameobject on object for this and drag in

    //private void OnDrawGizmosSelected()
    //{
    //    if (interactionTransform == null)
    //        interactionTransform = transform;

    //    Gizmos.color = Color.yellow;
    //    Gizmos.DrawWireSphere(transform.position, interactRadius);
    //}
    public virtual void Interact()
    {   
        //different interactions for diff objects
        Debug.Log("interacting with " + transform.name);
    }

    private void OnTriggerStay(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            Debug.Log("player in range");
            if (Input.GetMouseButtonDown(0))
            {
                Interact();
            }
        }
    }
}
