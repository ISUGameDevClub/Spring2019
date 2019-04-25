using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterMovement : MonoBehaviour
{
    public float playerSpeed;
    private Rigidbody2D playerRigidbody;
    private float movementInput;

    private bool facingRight = true;

    public float jumpPower;
    private bool isGrounded = true;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGrounded;

    //public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();

    }

    // FixedUpdate called every physics updop
    void FixedUpdate()
    {
       // jump();
        movePlayer();
       // checkCorrectFaceDirection();
        // animator.SetFloat("Speed", Mathf.Abs(movementInput));
    }

    void movePlayer()
    {
        movementInput = Input.GetAxis("Horizontal");
        playerRigidbody.velocity = new Vector2(movementInput * playerSpeed, playerRigidbody.velocity.y);
    }

    void checkCorrectFaceDirection()
    {
        if ((movementInput > 0 && !facingRight) || (movementInput < 0 && facingRight))
            facingRight = false;
        else
            facingRight = true;
    }
}
