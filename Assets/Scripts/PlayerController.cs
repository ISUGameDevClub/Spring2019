using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : GridMovable
{
    bool canPivot;
    char lastDir;
    // Start is called before the first frame update
    protected override void Start()
    {
        canPivot = false;
        lastDir = 'x';
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {

        int x = (int)Input.GetAxisRaw("Horizontal");
        int y = (int)Input.GetAxisRaw("Vertical");

        /* MOVEMENT TWEAKS */
        if ( x == 0 && y != 0 )
        {
            lastDir = 'y';
            canPivot = true;
        }
        if ( x != 0 && y == 0 )
        {
            lastDir = 'x';
            canPivot = true;
        }

        if (canPivot)
        {
            if (x != 0) // horizontal
            {
                if (lastDir == 'y')
                {

                }
            }
            if (y != 0) // vertical
            {
                x = 0;
            }
        }

        if (x != 0 && y != 0) // x AND y
        {
            canPivot = false;
        }
        if (x == 0 && y == 0)
        {
            lastDir = 'x';
        }
        /* ### */

        // if moving, attempt move
        if ( (x != 0 || y != 0) && !moving )
        {
            base.Move(x, y);
        }
    }
}
