using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [Tooltip("Item that the chest contains.")]
    public GameObject item;
    [Tooltip("Requires and consumes a key.")]
    public bool needsKey;
    [Tooltip("Sprite to change to when chest is opened.")]
    public Sprite openedSprite;

    //private SpriteRenderer os;
    private GameObject plr;
    private SpriteRenderer cur;

    // Start is called before the first frame update
    void Start()
    {
        plr = GameObject.Find("Player");
        cur = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (!needsKey)
            {
                if (openedSprite != null)
                {
                    cur.sprite = openedSprite;
                }

            }
        }
    }
}
