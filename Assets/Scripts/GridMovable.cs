using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GridMovable : MonoBehaviour
{
    public float moveTime = 0.2f; // total movement time in seconds?

    protected bool moving = false;

    private float moveTimeInv; // inverse of moveTime
    private Rigidbody2D rb;    // Rigidbody of inheriting class

    // Protected and virtual, so can be overridden.
    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveTimeInv = 1.0f / moveTime;
    }

    protected void Move(int x, int y)
    {
        moving = true;

        // vector to move toward
        Vector3 toward = transform.position + new Vector3(x, y, 0.0f);

        //begin coroutine
        StartCoroutine( CoMovement(toward) );
    }

    protected IEnumerator CoMovement(Vector3 toward)
    {
        float sqrDist = (toward - transform.position).sqrMagnitude;

        while(sqrDist > float.Epsilon) // while there's still distance to cover
        {
            // use Rigidbody2D coords to calculate
            transform.position = Vector3.MoveTowards(transform.position, toward, moveTimeInv * Time.deltaTime);

            // update square distance for next call/loop
            sqrDist = (toward - transform.position).sqrMagnitude;

            yield return null;
        }

        moving = false;
    }
}
