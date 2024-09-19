using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager acc;

    public InputSystem IS;
    public EventManager EM;
    public SceneHandler SH;
    public PlayerManager PM;

    public ShipManager SM;
    public CameraManager CM;

    private void Awake()
    {
        acc = this;
    }

    private void Update()
    {

    }

    private void FixedUpdate()
    {
        switch (PM.playerMovementState)
        {
            case PlayerMovementState.OnGround:
                PM.PMove.Movement(IS.move.ReadValue<Vector2>());
                CM.FollowObj(PM.playerObj);
                break;
            case PlayerMovementState.InSpace:
                PM.PMove.MovementSpace(IS.move.ReadValue<Vector2>());
                CM.FollowObj(PM.playerObj);
                break;
            case PlayerMovementState.ConntrollingShip:
                SM.SMove.ShipMove(IS.move.ReadValue<Vector2>());
                CM.FollowObj(SM.shipObj);
                break;
        }
    }
}
