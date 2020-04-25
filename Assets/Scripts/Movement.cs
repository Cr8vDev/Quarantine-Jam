using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MovementType
{
    Sidescroller,
    TopDown
}

public enum ReferenceDirection
{
    Left,
    Right
}

public enum TopDownDirection
{
    Up,
    Down
}

public class Movement : MonoBehaviour
{
    [Header("Common Gameplay Properties")]
    [SerializeField]
    private Rigidbody2D rb2d;

    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private float speed;

    [SerializeField]
    private List<Sprite> upAnimation;
    [SerializeField]
    private List<Sprite> downAnimation;
    [SerializeField]
    private List<Sprite> horizontalAnimation;
    private int vIncrement = 0;
    private int hIncrement = 0;
    [SerializeField]
    private float animationDelay;
    private float setAnimationDelay = 0f;


    [SerializeField]
    private MovementType movementType;



    [Header("Sidescroller Type Game Properties")]
    [SerializeField]
    private ReferenceDirection referenceDirection;



    private void HorizontalAnimation()
    {
        if (Time.time > setAnimationDelay)
        {
            if (hIncrement >= horizontalAnimation.Count)
            {
                hIncrement = 0;
            }

            spriteRenderer.sprite = horizontalAnimation[hIncrement];
            hIncrement++;

            setAnimationDelay = Time.time + animationDelay;
        }
    }



    private void HorizontalMovement(float xDir)
    {
        if (xDir > 0)
        {
            rb2d.MovePosition(rb2d.position + new Vector2(speed, 0f) * Time.deltaTime);
        }
        else if (xDir < 0)
        {
            rb2d.MovePosition(rb2d.position - new Vector2(speed, 0f) * Time.deltaTime);
        }
    }


    private void IsGravityScaleActivated(bool activate)
    {
        if(activate)
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



    private void VerticalAnimation(TopDownDirection topDownDirection)
    {
        if (Time.time > setAnimationDelay)
        {
            if (vIncrement >= upAnimation.Count)
            {
                vIncrement = 0;
            }

            if (topDownDirection == TopDownDirection.Up)
            {
                spriteRenderer.sprite = upAnimation[vIncrement];
            }
            else if (topDownDirection == TopDownDirection.Down)
            {
                spriteRenderer.sprite = downAnimation[vIncrement];
            }

            vIncrement++;

            setAnimationDelay = Time.time + animationDelay;
        }
    }



    private void VerticalMovement(float yDir)
    {
        if(yDir > 0)
        {
            rb2d.MovePosition(rb2d.position + new Vector2(0f, speed) * Time.deltaTime);
        }
        else if (yDir < 0)
        {
            rb2d.MovePosition(rb2d.position - new Vector2(0f, speed) * Time.deltaTime);
        }
    }



    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }



    private void FixedUpdate()
    {
        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");

        if (x > 0.1f)
        {
            HorizontalAnimation();

            if (referenceDirection == ReferenceDirection.Left)
            {
                spriteRenderer.flipX = false;
            }
            else
            {
                spriteRenderer.flipX = true;
            }

            HorizontalMovement(x);
        }
        else if (x < -0.1f)
        {
            HorizontalAnimation();

            if (referenceDirection == ReferenceDirection.Left)
            {
                spriteRenderer.flipX = true;
            }
            else
            {
                spriteRenderer.flipX = false;
            }

            HorizontalMovement(x);
        }

        if (movementType == MovementType.Sidescroller)
        {
            IsGravityScaleActivated(true);
        }
        else
        {
            IsGravityScaleActivated(false);

            if (y > 0.1f)
            {
                VerticalAnimation(TopDownDirection.Up);
            }
            else if (y < -0.1f)
            {
                VerticalAnimation(TopDownDirection.Down);
            }

            VerticalMovement(y);
        }
    }
}
