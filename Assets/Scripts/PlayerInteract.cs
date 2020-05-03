using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField]
    private GameObject pressC;

    [SerializeField]
    private GameObject pressF;
    [SerializeField]
    private TextMeshProUGUI popText;

    private BaseStack baseStack;

    private StackItem stackItem;

    private PlayerMovement playerMovement;

    private bool inputF = false;

    [SerializeField]
    private GameObject pressE;
    [SerializeField]
    private TextMeshProUGUI stackText;

    private bool isClimable = false;



    public BaseStack GetBaseStack()
    {
        return baseStack;
    }



    public bool IsClimable()
    {
        return isClimable;
    }



    public void PopItem()
    {
        if (baseStack != null)
        {
            baseStack.Pop();
            pressF.SetActive(false);
        }
    }



    public void StackItem()
    {
        if (stackItem != null)
        {
            stackItem.SetItemOnStack();
            pressE.SetActive(false);
        }
    }



    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }



    private void OnTriggerStay2D(Collider2D collision)
    {
        //Interact Range Of Item
        if (collision.tag[0] == '1' && collision.tag[1] == '0')
        {
            stackItem = collision.GetComponentInParent<StackItem>();

            if (!stackItem.IsStacked())
            {
                if (stackItem.IsOnPlatform())
                {
                    stackText.text = "Press E To Stack To " + stackItem.GetColliderName();
                    pressE.SetActive(true);
                }
            }
        }

        if (collision.tag[0] == '2')
        {
            if (collision.GetComponent<BaseStack>().GetStackObjectsCount() > 0)
            {
                baseStack = collision.GetComponent<BaseStack>();

                popText.text = "Press F To Unstack " + collision.name;
                pressF.SetActive(true);

                if (collision.GetComponent<BaseStack>().GetStackObjectsCount() == 1)
                {
                    isClimable = true;
                    pressC.SetActive(true);
                }
            }
        }
    }



    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag[0] == '2')
        {
            pressF.SetActive(false);

            isClimable = false;
            pressC.SetActive(false);

            baseStack = null;
        }

        if (collision.tag[0] == '1' && collision.tag[1] == '0')
        {
            stackItem = null;

            pressE.SetActive(false);
        }
    }
}
