using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MovementType
{
    Sidescroller,
    TopDown
}

public enum TopDownDirection
{
    Up,
    Down
}

public class PlayerMovement : MonoBehaviour
{
    [Header("Common Gameplay Properties")]
    private Rigidbody2D rb2d;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float jumpForce;



    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
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
