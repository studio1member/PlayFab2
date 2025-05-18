using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerStatus player;
    private float hor;
    private void Awake()
    {
        this.player = transform.root.GetComponent<PlayerStatus>();
    }
    private void Update()
    {
        this.hor = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space) && this.player.groundCheck) _Jump();
    }
    private void FixedUpdate()
    {
        _Move();
        _Ground_Check();
    }
    private void _Move()
    {
        float hor = Mathf.Abs(this.player.rb.velocity.x);
        this.player.Anim.SetFloat("Move", hor);
        this.player.rb.velocity = new Vector3(this.hor * player.speedPlayer * 10f * Time.fixedDeltaTime, this.player.rb.velocity.y);
        if (this.hor > 0) this.player.transform.localScale = new Vector3(1, 1, 1);
        else if (this.hor < 0) this.player.transform.localScale = new Vector3(-1, 1, 1);
    }
    private void _Ground_Check() { this.player.groundCheck = Physics2D.Raycast(transform.position, Vector2.down, 1.5f, this.player.ground); }
    private void _Jump() { this.player.rb.AddForce(Vector2.up * this.player.jumpForcePlayer, ForceMode2D.Impulse); }
}
