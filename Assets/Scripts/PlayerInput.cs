using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField]
    private PlayerMovement playerMovement;
    [SerializeField]
    private PlayerAnimations playerAnimations;
    [SerializeField]
    private PlayerInteract playerInteract;

    [SerializeField]
    private PlayerAction playerAction;


    [SerializeField]
    private MovementType movementType;



    private void Start()
    {
        if (movementType == MovementType.Sidescroller)
        {
            playerMovement.IsGravityScaleActivated(true);
        }
        else
        {
            playerMovement.IsGravityScaleActivated(false);
        }
    }



    void FixedUpdate()
    {
        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");



        if ((x > 0.05f || x < -0.05f) || (y > 0.05f || y < -0.05f))
        {
            //Horizontal movement, which is common to Sidescroller and Top-Down.
            playerAnimations.HorizontalAnimation(x);

            //Determines the type of movement system
            if (movementType == MovementType.Sidescroller)
            {
                playerMovement.IsGravityScaleActivated(true);

                playerMovement.MovementSideScroller(x);
            }
            else
            {
                playerMovement.IsGravityScaleActivated(false);

                playerAnimations.VerticalAnimation(y);

                playerMovement.MovementTopDown(x, y);
            }
        }
        else if ((x < 0.95f || x > -0.95f) || (y < 0.95f || y > -0.95f))
        {
            if (movementType == MovementType.TopDown)
            {
                playerMovement.Idle();
            }

            playerAnimations.Idle();
        }



        if (movementType == MovementType.Sidescroller)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                playerMovement.Jump();
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            playerInteract.PopItem();
        }



        if (Input.GetKeyDown(KeyCode.E))
        {
            playerInteract.StackItem();
        }



        if (Input.GetKeyDown(KeyCode.C))
        {
            if (playerAction.GetPlayerAction() == Action.FreeRoam)
            {
                if (playerInteract.IsClimable())
                {
                    playerAction.ClimbUp();
                }
            }
            else
            {
                playerAction.ClimbDown();
            }
        }
    }
}
