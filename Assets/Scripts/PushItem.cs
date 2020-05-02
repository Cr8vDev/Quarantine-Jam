using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushItem : MonoBehaviour
{
    [SerializeField]
    private float interactableCarryDistance;

    private Transform colliderObject;

    private bool isCarryingInteractable = false;

    private PlayerMovement playerMovement;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag[0] == '1' && collision.tag[1] == '0')
        {
            colliderObject = collision.transform.parent;

            colliderObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag[0] == '1' && collision.tag[1] == '0')
        {
            colliderObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;

            colliderObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);

            colliderObject = null;
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            if(colliderObject.GetComponent<StackItem>() != null)
            {
                if(colliderObject.GetComponent<StackItem>().IsStackable())
                {
                    colliderObject.GetComponent<StackItem>().Stack();
                }
            }
        }
    }
}
