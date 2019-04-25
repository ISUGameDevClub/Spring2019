using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SidescrollingCharacterMovement : MonoBehaviour
{
    public float playerSpeed; // How much sonic the player is.
    private Rigidbody2D playerRigidbody; // Unity object used to manipulate the physics of things in game.
    private float movementInput; // Stores whether player is pressing left or right.

    private bool facingRight = true; // Is the sprite facing right?

    public float jumpPower; // How much leg day the player put in.
    private bool isGrounded = true; // Is the character on the ground?
    public Transform groundCheck; // A position used to detect whether the player is on the ground.
    public float checkRadius; // The radius of where to check for the ground from the player.
    public LayerMask whatIsGrounded; // Used to determine what assets of the game are actually the ground. EX: the background isnt ground!

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    // Called every physics-step of the game(Different from frame). All physics manipulations should be done in this method to ensure consistant framerate accross multiple platforms(which may have different framerates?).
    void FixedUpdate()
    {
        jump();

        movePlayer();

        checkCorrectFaceDirection();

    }

    void jump()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGrounded);
        if (Input.GetAxis("Vertical") > 0 && isGrounded) // Checks if Unity set inputs have been pressed and if player is on ground.
        {
            playerRigidbody.velocity = Vector2.up * jumpPower;
        }
    }

    void movePlayer()
    {
        movementInput = Input.GetAxis("Horizontal");
        playerRigidbody.velocity = new Vector2(movementInput * playerSpeed, playerRigidbody.velocity.y);
    }

    void checkCorrectFaceDirection()
    {
        if ((movementInput > 0 && !facingRight) || (movementInput < 0 && facingRight)) //If player isn't facing correct direction for input.
        {
            facingRight = !facingRight; //Swaps to correct value.

            //Vector2 theScale = transform.localScale;    //Sets the x localScale(the sprite direction on the x axis) to its opposite.
            //theScale.x *= -1;
            //transform.localScale = theScale;

            transform.Rotate(0f, 180f, 0f); //Rotates the sprite around y axis (gives it a spin).
        }
    }
}

