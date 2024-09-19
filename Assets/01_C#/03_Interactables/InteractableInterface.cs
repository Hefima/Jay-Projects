using UnityEngine;

public interface IInteractable
{
    public bool IsCarried { get; set; }

    public void Interact(PlayerManager playerManager);
}
