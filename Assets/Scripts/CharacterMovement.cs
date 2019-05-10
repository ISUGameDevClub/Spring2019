using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float playerSpeed;
    private Rigidbody2D playerRigidbody;
    private float movementInputX;
    private float movementInputY;

    private Vector2 newScale;
    private bool facingRight = true;
    private bool facingLeft;
    private bool facingUp;
    private bool facingDown;
    public Sprite facingUpSprite;
    public Sprite facingDownSprite;
    public Sprite facingRightSprite;
    private SpriteRenderer playerSpriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
        newScale = transform.localScale;
    }

    private void FixedUpdate()
    {
        flipFaceDirection();
        movePlayer();

    }

    private void movePlayer()
    {
        movementInputX = Input.GetAxisRaw("Horizontal");
        movementInputY = Input.GetAxisRaw("Vertical");
        playerRigidbody.velocity = new Vector2(movementInputX * playerSpeed, movementInputY * playerSpeed);
    }

    private void flipFaceDirection()
    {
        if (movementInputX > 0 && !facingRight) //Facing right
        {
            facingRight = true;
            facingLeft = false;
            facingUp = false;
            facingDown = false;
            playerSpriteRenderer.sprite = facingRightSprite;
            if(transform.localScale.x < 0)
            {
                newScale.x = newScale.x * -1;
                transform.localScale = newScale;
            }
        }
        if (movementInputX < 0 && !facingLeft) //Facing left
        {
            facingRight = false;
            facingLeft = true;
            facingUp = false;
            facingDown = false;
            playerSpriteRenderer.sprite = facingRightSprite;
            if (transform.localScale.x > 0)
            {
                newScale.x = newScale.x * -1;
                transform.localScale = newScale;
            }
        }
        if (movementInputY > 0 && !facingUp) //Facing up
        {
            facingRight = false;
            facingLeft = false;
            facingUp = true;
            facingDown = false;
            playerSpriteRenderer.sprite = facingUpSprite;
        }
        if (movementInputY < 0 && !facingDown) //Facing down
        {
            facingRight = false;
            facingLeft = false;
            facingUp = false;
            facingDown = true;
            playerSpriteRenderer.sprite = facingDownSprite;
        }
    }
}

