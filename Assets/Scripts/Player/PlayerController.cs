using System;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    private Rigidbody2D rb;
    private PlayerStat playerStat;
    private bool isDashing = false;
    private bool canDash = true;
    private Vector2 dashDir;
    private Vector2 moveInput;

    public bool IsUntouchable { get; private set; }


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerStat = GetComponent<PlayerStat>();
    }

    private void Update()
    {
        moveInput = InputManager.Instance.moveInput;

        Move();
    }

    public void Move()
    {
        if (isDashing) return;
        rb.velocity = new Vector2(moveInput.x * playerStat.moveSpeed, moveInput.y * playerStat.moveSpeed);
    }

    public void TryDash()
    {
        if (!canDash || isDashing) return;

        if(moveInput != Vector2.zero)
        {
            dashDir = moveInput.normalized;
        }
        else
        {
            dashDir = Vector2.right;
        }

        StartCoroutine(Dash());

    }

    private IEnumerator Dash()
    {
        Debug.Log("Dashing");
        isDashing = true;
        canDash = false;

        IsUntouchable = true;

        Vector2 originalVelocity = rb.velocity;
        rb.velocity = dashDir * playerStat.dashSpeed;

        yield return new WaitForSeconds(playerStat.dashDuration);

        rb.velocity = originalVelocity;
        IsUntouchable = false;
        isDashing = false;

        yield return new WaitForSeconds(playerStat.dashCooldown);

        canDash = true;
    }
}
