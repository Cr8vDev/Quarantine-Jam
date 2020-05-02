using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MovementType
{
    Sidescroller,
    TopDown
}

public enum CurrentDirection
{
    East,
    West,
    North,
    South,
    NorthEast,
    NorthWest,
    SouthEast,
    SouthWest
}

public class PlayerMovement : MonoBehaviour
{
    [Header("Common Gameplay Properties")]
    private Rigidbody2D rb2d;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float jumpForce;

    private CurrentDirection currentDirection;



    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }



    public CurrentDirection GetCurrentDirection()
    {
        return currentDirection;
    }



    public void IsGravityScaleActivated(bool activate)
    {
        if (activate)
        {
            if (rb2d.gravityScale == 0)
            {
                rb2d.gravityScale = 1f;
            }
        }
        else
        {
            if (rb2d.gravityScale == 1f)
            {
                rb2d.gravityScale = 0f;
            }
        }
    }



    public void MovementSideScroller(float xDir)
    {
        rb2d.velocity = (new Vector2(speed * xDir * Time.deltaTime, rb2d.velocity.y));
    }



    public void MovementTopDown(float xDir, float yDir)
    {
        rb2d.velocity = (new Vector2(speed * xDir, speed * yDir) * Time.deltaTime);

        if (xDir < 0f)
        {
            if (Mathf.Approximately(yDir, 0f))
            {
                currentDirection = CurrentDirection.West;
            }
            else if (yDir > 0f)
            {
                currentDirection = CurrentDirection.NorthWest;
            }
            else if (yDir < 0f)
            {
                currentDirection = CurrentDirection.SouthWest;
            }
        }
        else if (xDir > 0f)
        {
            if (Mathf.Approximately(yDir, 0f))
            {
                currentDirection = CurrentDirection.East;
            }
            else if (yDir > 0f)
            {
                currentDirection = CurrentDirection.NorthEast;
            }
            else if (yDir < 0f)
            {
                currentDirection = CurrentDirection.SouthEast;
            }
        }
        else if (yDir > 0f)
        {
            currentDirection = CurrentDirection.North;
        }
        else if (yDir < 0f)
        {
            currentDirection = CurrentDirection.South;
        }
    }



    public void Idle()
    {
        rb2d.velocity = new Vector2(0f, 0f);
    }



    public void Jump()
    {
        rb2d.velocity = Vector2.up * jumpForce;
    }
}
