using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour
{
    [Header("Component")]
    public Rigidbody2D rb;
    public Animator Anim;

    [Header("Status")]
    public float HpCurrent;
    public float HpMax = 100f;
    public virtual void Awake()
    {
        this.rb = GetComponent<Rigidbody2D>();
        this.Anim = GetComponent<Animator>();

        HpCurrent = HpMax;
    }
    public void _Damage_Recived(float damge)
    {
        HpCurrent -= damge;
    }
}
