using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushItem : MonoBehaviour
{
    [SerializeField]
    private GameObject popStack;

    private BaseStack baseStack;

    private PlayerMovement playerMovement;

    private bool inputF = false;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag[0] == '2')
        {
            if (collision.GetComponent<BaseStack>().GetStackObjectsCount() > 0)
            {
                popStack.SetActive(true);

                baseStack = collision.GetComponent<BaseStack>();
            }
            else
            {
                popStack.SetActive(false);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag[0] == '2')
        {
            popStack.SetActive(false);

            baseStack = null;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (baseStack != null)
            {
                baseStack.Pop();
                popStack.SetActive(false);
            }
        }
    }
}
