using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : Status
{
    [Header("Layer Mask")]
    public LayerMask ground;
    public LayerMask enemy;

    [Header("Move")]
    public float speedPlayer = 50f;

    [Header("Jump")]
    public float jumpForcePlayer = 20f;
    public bool groundCheck;
}
