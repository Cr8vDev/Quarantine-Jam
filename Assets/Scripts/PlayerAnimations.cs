using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ReferenceDirection
{
    Left,
    Right
}



public class PlayerAnimations : MonoBehaviour
{
    [SerializeField]
    private ReferenceDirection referenceDirection;

    private SpriteRenderer spriteRenderer;

    private Animator animator;


    
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        animator = GetComponent<Animator>();

        animator.speed = 0f;
    }



    public void HorizontalAnimation(float dirX)
    {
        if(dirX > 0f)
        {
            animator.speed = 1f;

            if (referenceDirection == ReferenceDirection.Left)
            {
                spriteRenderer.flipX = true;
            }
            else
            {
                spriteRenderer.flipX = false;
            }

            animator.SetBool("Horizontal", true);
            animator.SetBool("Up", false);
            animator.SetBool("Down", false);
        }
        else if(dirX < 0f)
        {
            animator.speed = 1f;

            if (referenceDirection == ReferenceDirection.Left)
            {
                spriteRenderer.flipX = false;
            }
            else
            {
                spriteRenderer.flipX = true;
            }

            animator.SetBool("Horizontal", true);
            animator.SetBool("Up", false);
            animator.SetBool("Down", false);
        }
    }



    public void VerticalAnimation(float dirY)
    {
        animator.speed = 1f;

        if (dirY > 0.05f)
        {
            animator.SetBool("Up", true);
            animator.SetBool("Horizontal", false);
            animator.SetBool("Down", false);
        }
        else if (dirY < -0.05f)
        {
            animator.SetBool("Down", true);
            animator.SetBool("Horizontal", false);
            animator.SetBool("Up", false);
        }
    }



    public void Idle()
    {
        animator.speed = 0f;
    }
}
