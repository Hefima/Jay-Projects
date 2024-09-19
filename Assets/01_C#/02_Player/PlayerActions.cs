using Unity.VisualScripting;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    [Header("Interact")]
    public Transform interactPnt;
    public float interactRadius;
    public LayerMask interactableMask;

    [Header("ItemPickup")]
    public Transform pickUpPnt;
    public Transform itemPntFront;
    public Transform itemPntBack;

    public GameObject carriedItemFront;
    public GameObject carriedItemBack;
    public void Interact()
    {
        if (GameManager.acc.PM.playerMovementState == PlayerMovementState.ConntrollingShip && GameManager.acc.SM.SMove.ShipStopped())
        {
            StopControllShip();
            return;
        }

        Collider2D hit = Physics2D.OverlapCircle(interactPnt.position, interactRadius, interactableMask);

        if (hit != null)
        {
            IInteractable interactable = hit.GetComponent<IInteractable>();

            if (interactable != null)
            {
                interactable.Interact(GameManager.acc.PM);
            }
        }
    }

    public void PickUpItem(GameObject obj)
    {
        if (carriedItemBack == null)
        {
            obj.transform.parent = GameManager.acc.PM.playerObj.transform;
            obj.transform.position = itemPntBack.position;
            carriedItemBack = obj;
            obj.GetComponent<IInteractable>().IsCarried = true;
        }
        else if (carriedItemFront == null)
        {
            obj.transform.parent = GameManager.acc.PM.playerObj.transform;
            obj.transform.position = itemPntFront.position;
            obj.GetComponent<IInteractable>().IsCarried = true;
            carriedItemFront = obj;

        }
        else
        {
            Debug.Log("CANT CARRY MORE OBJECTS");
        }
    }

    public void DropItem()
    {
        if (carriedItemFront != null)
        {
            carriedItemFront.GetComponent<IInteractable>().IsCarried = false;
            carriedItemFront.transform.parent = null;
            carriedItemFront = null;

            // if (carriedItemBack != null)
            // {
            //     carriedItemBack.transform.position = itemPntFront.position;
            //     carriedItemFront = carriedItemBack;
            //     carriedItemBack = null;
            // }
        }
        else if (carriedItemBack != null)
        {
            carriedItemBack.GetComponent<IInteractable>().IsCarried = false;
            carriedItemBack.transform.parent = null;
            carriedItemBack = null;
        }
    }

    public void ControllShip()
    {
        GameManager.acc.PM.playerMovementState = PlayerMovementState.ConntrollingShip;

        GameManager.acc.CM.cam.orthographicSize = GameManager.acc.PM.camSizeShip;
    }
    public void StopControllShip()
    {
        GameManager.acc.PM.playerMovementState = PlayerMovementState.OnGround;
        GameManager.acc.CM.cam.orthographicSize = GameManager.acc.PM.camSizePlayer;
    }
}
