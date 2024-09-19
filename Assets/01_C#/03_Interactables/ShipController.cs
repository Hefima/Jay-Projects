using UnityEngine;

public class ShipController : MonoBehaviour, IInteractable
{

    public bool IsCarried { get; set; }

    public void Interact(PlayerManager playerManager)
    {
        if (playerManager.playerMovementState == PlayerMovementState.OnGround)
        {
            GameManager.acc.PM.playerObj.transform.position = transform.position;
            playerManager.PActions.ControllShip();
        }
    }
}
