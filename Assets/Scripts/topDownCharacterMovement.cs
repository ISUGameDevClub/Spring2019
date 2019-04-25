using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopDownCharacterMovement : MonoBehaviour
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

    private int collectedBasicPickups;
    public Text countText;



    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
        newScale = transform.localScale;

        collectedBasicPickups = 0;
        SetCountText();
    }

    private void FixedUpdate()
    {
        flipFaceDirection();
        movePlayer();

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pickup")){
            collectedBasicPickups += 1;
            SetCountText();
            Destroy(other.gameObject);
        }        
    }

    private void SetCountText()
    {
        countText.text = "Count: " + collectedBasicPickups.ToString();
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
            newScale.x = 1;
            transform.localScale = newScale;
        }
        if (movementInputX < 0 && !facingLeft) //Facing left
        {
            facingRight = false;
            facingLeft = true;
            facingUp = false;
            facingDown = false;
            playerSpriteRenderer.sprite = facingRightSprite;
            newScale.x = -1;
            transform.localScale = newScale;
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

