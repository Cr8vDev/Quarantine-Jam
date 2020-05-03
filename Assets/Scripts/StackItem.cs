using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackItem : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb2d;

    private bool isStacked = false;

    private bool inputE = false;

    private BaseStack baseStack;

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

    private void AddToStack()
    {
        isStacked = true;
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
                baseStack = collision.GetComponent<BaseStack>();
                isOnPlatform = true;
                colliderName = collision.name;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag[0] == '2')
        {
            baseStack = null;
            isOnPlatform = false;
            colliderName = "";
        }
    }

    public void SetItemOnStack()
    {
        if (baseStack != null)
        {
            baseStack.Stack(transform);
            rb2d.bodyType = RigidbodyType2D.Kinematic;
            AddToStack();
            baseStack = null;
        }
    }
}
