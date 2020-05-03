using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackItem : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb2d;

    private bool isStacked = false;

    private bool inputE = false;

    private BaseStack oldBaseStack;
    private BaseStack newBaseStack;

    private bool isOnPlatform = false;

    private string colliderName = "";



    public bool IsStacked()
    {
        return isStacked;
    }



    public void RemoveFromStack()
    {
        isStacked = false;
    }



    public bool IsOnPlatform()
    {
        return isOnPlatform;
    }



    public string GetColliderName()
    {
        return colliderName;
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!IsStacked())
        {
            if (collision.tag[0] == '2')
            {
                colliderName = collision.name;
                isOnPlatform = true;

                if (newBaseStack == null)
                {
                    newBaseStack = collision.GetComponent<BaseStack>();
                }
                else
                {
                    oldBaseStack = newBaseStack;
                    newBaseStack = collision.GetComponent<BaseStack>();
                }
            }
        }
    }



    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag[0] == '2')
        {
            if (oldBaseStack == null)
            {
                colliderName = "";
                isOnPlatform = false;
            }
            else
            {
                oldBaseStack = null;
            }
        }
    }



    public void SetItemOnStack()
    {
        if (!IsStacked())
        {
            if (isOnPlatform)
            {
                newBaseStack.Stack(transform);
                rb2d.bodyType = RigidbodyType2D.Kinematic;
                isStacked = true;
                newBaseStack = null;
                oldBaseStack = null;
                isOnPlatform = false;
                colliderName = "";
            }
        }
    }
}
