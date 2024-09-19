using Unity.Multiplayer.Center.Common.Analytics;
using UnityEngine;

public class ItemObj : MonoBehaviour, IInteractable
{
    public bool IsCarried { get; set; }
    public void Interact(PlayerManager playerManager)
    {
        playerManager.PActions.PickUpItem(gameObject);
    }
}
