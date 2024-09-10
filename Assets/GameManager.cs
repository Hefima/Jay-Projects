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

    private void Awake()
    {
        acc = this;
    }

    private void Update()
    {

    }

    private void FixedUpdate()
    {
        PM.PMove.Movement(IS.move.ReadValue<Vector2>());
    }
}
