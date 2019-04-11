using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : GridMovable
{
    char lastMove;

    // Start is called before the first frame update
    protected override void Start()
    {
        lastMove = 'x';
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {

        int x = (int)Input.GetAxisRaw("Horizontal");
        int y = (int)Input.GetAxisRaw("Vertical");

        if (x != 0 && y != 0)
        {
            if (lastMove == 'x')
                x = 0;
            else if (lastMove == 'y')
                y = 0;
        }

        // if moving, attempt move
        if ( (x != 0 || y != 0) && !moving )
        {
            if (x != 0)
                lastMove = 'x';
            if (y != 0)
                lastMove = 'y';
            base.Move(x, y);
        }
    }
}
