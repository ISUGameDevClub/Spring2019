using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : MonoBehaviour
{
    [Tooltip("The door that this object will unlock.")]
    public GameObject door;

    [Tooltip("The sprite the door will switch to when activated. (Optional)")]
    public Sprite doorOpen;

    [Tooltip("The sprite this object will change to when activated. (Optional)")]
    public Sprite activated;

    private GameObject player;
    private SpriteRenderer doorSprite;
    private SpriteRenderer buttonSprite;

    void Start()
    {
        door = GameObject.Find(door.name);
        player = GameObject.Find("Player");
        doorSprite = door.GetComponent<SpriteRenderer>();
        buttonSprite = this.GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.Equals(player)) // The collision was caused by the player
        {
            if (doorOpen != null) // There is a sprite in the variable
            {
                doorSprite.sprite = doorOpen;
            }
            if (activated != null)
            {
                buttonSprite.sprite = activated;
            }
            door.GetComponent<BoxCollider2D>().enabled = false;

        }
    }
}
