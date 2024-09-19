using UnityEngine;
using UnityEngine.InputSystem;

public class InputSystem : MonoBehaviour
{
    public InputSystem_Actions playerInputAction;
    public InputAction move;
    public InputAction interact;
    public InputAction dropItem;

    private void Awake()
    {
        playerInputAction = new InputSystem_Actions();
    }
    private void OnEnable()
    {
        move = playerInputAction.Player.Move;
        move.Enable();

        interact = playerInputAction.Player.Interact;
        interact.Enable();
        interact.performed += OnInteractPerformed;

        dropItem = playerInputAction.Player.DropItem;
        dropItem.Enable();
        dropItem.performed += OnDropItemPerformed;
    }

    private void OnDisable()
    {
        move.Disable();
        interact.Disable();
    }

    private void OnInteractPerformed(InputAction.CallbackContext context)
    {
        GameManager.acc.PM.PActions.Interact();
    }
    private void OnDropItemPerformed(InputAction.CallbackContext context)
    {
        GameManager.acc.PM.PActions.DropItem();
    }
}
