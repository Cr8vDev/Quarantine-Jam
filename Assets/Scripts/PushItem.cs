using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PushItem : MonoBehaviour
{
    [SerializeField]
    private GameObject pressF;

    private BaseStack baseStack;

    private StackItem stackItem;

    private PlayerMovement playerMovement;

    private bool inputF = false;

    [SerializeField]
    private GameObject pressE;
    [SerializeField]
    private TextMeshProUGUI stackText;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Layers
        if (collision.tag[0] == '2')
        {
            if (collision.GetComponent<BaseStack>().GetStackObjectsCount() > 0)
            {
                baseStack = collision.GetComponent<BaseStack>();

                pressF.SetActive(true);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //Interact Range Of Item
        if (collision.tag[0] == '1' && collision.tag[1] == '0')
        {
            stackItem = collision.GetComponentInParent<StackItem>();

            if (stackItem.IsOnPlatform())
            {
                stackText.text = "Press E To Stack To " + stackItem.GetColliderName();
                pressE.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag[0] == '2')
        {
            pressF.SetActive(false);

            baseStack = null;

            pressE.SetActive(false);
        }

        if (collision.tag[0] == '1' && collision.tag[1] == '0')
        {
            stackItem = null;

            pressE.SetActive(false);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (baseStack != null)
            {
                baseStack.Pop();
                pressF.SetActive(false);
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (stackItem != null)
            {
                stackItem.SetItemOnStack();
                pressE.SetActive(false);
            }
        }
    }
}
