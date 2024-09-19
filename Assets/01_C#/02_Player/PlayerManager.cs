using UnityEngine;

public enum PlayerMovementState
{
    OnGround,
    InSpace,
    ConntrollingShip,
}

public class PlayerManager : MonoBehaviour
{
    public GameObject playerObj;
    public PlayerMovement PMove;
    public PlayerActions PActions;

    public float camSizePlayer = 5f;
    public float camSizeShip = 10f;

    public PlayerMovementState playerMovementState = PlayerMovementState.OnGround;
}
