using UnityEngine;
using UnityEngine.InputSystem;

public class InputSystem : MonoBehaviour
{
    public InputSystem_Actions playerInputAction;
    public InputAction move;

    private void Awake()
    {
        playerInputAction = new InputSystem_Actions();
    }
    private void OnEnable()
    {
        move = playerInputAction.Player.Move;
        move.Enable();
    }

    private void OnDisable()
    {
        move.Disable();
    }
}
