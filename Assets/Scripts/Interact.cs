using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    [SerializeField]
    private char interactableObjectTag;

    [SerializeField]
    private float interactableCarryDistance;

    private Collider2D colliderObject;

    private bool isCarryingInteractable = false;

    private PlayerMovement playerMovement;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag[0] == interactableObjectTag)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                colliderObject = collision;

                isCarryingInteractable = true;

                colliderObject.transform.parent.SetParent(transform);
            }
        }
    }

    private void Update()
    {
        if (isCarryingInteractable)
        {
            if (playerMovement.GetCurrentDirection() == CurrentDirection.East)
            {
                colliderObject.transform.parent.position = transform.position + new Vector3(interactableCarryDistance, 0f, 0f);
            }
            else if (playerMovement.GetCurrentDirection() == CurrentDirection.West)
            {
                colliderObject.transform.parent.position = transform.position - new Vector3(interactableCarryDistance, 0f, 0f);
            }
            else if (playerMovement.GetCurrentDirection() == CurrentDirection.North)
            {
                colliderObject.transform.parent.position = transform.position + new Vector3(0f, interactableCarryDistance, 0f);
            }
            else if (playerMovement.GetCurrentDirection() == CurrentDirection.South)
            {
                colliderObject.transform.parent.position = transform.position - new Vector3(0f, interactableCarryDistance, 0f);
            }
            else if (playerMovement.GetCurrentDirection() == CurrentDirection.NorthEast)
            {
                colliderObject.transform.parent.position = transform.position + new Vector3(interactableCarryDistance, interactableCarryDistance, 0f);
            }
            else if (playerMovement.GetCurrentDirection() == CurrentDirection.NorthWest)
            {
                colliderObject.transform.parent.position = transform.position + new Vector3(-interactableCarryDistance, interactableCarryDistance, 0f);
            }
            else if (playerMovement.GetCurrentDirection() == CurrentDirection.SouthEast)
            {
                colliderObject.transform.parent.position = transform.position + new Vector3(interactableCarryDistance, -interactableCarryDistance, 0f);
            }
            else if (playerMovement.GetCurrentDirection() == CurrentDirection.SouthWest)
            {
                colliderObject.transform.parent.position = transform.position - new Vector3(interactableCarryDistance, interactableCarryDistance, 0f);
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                isCarryingInteractable = false;

                colliderObject.transform.parent.SetParent(null);

                colliderObject = null;
            }
        }
    }
}
