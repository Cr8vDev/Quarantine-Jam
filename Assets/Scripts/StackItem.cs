using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackItem : MonoBehaviour
{
    private Transform collisionObject;
    private bool isStackable = false;
    private StackItem itemStacked;

    public void SetStackItem(StackItem sItemStacked)
    {
        itemStacked = sItemStacked;
    }

    public void Stack()
    {
        collisionObject.transform.parent.GetComponent<StackItem>().SetStackItem(this);
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        transform.position = collisionObject.position + new Vector3(0f, 0.15f, 0f);
    }

    public bool IsStackable()
    {
        return isStackable;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag[0] == '1' && collision.tag[1] == '0')
        {
            collisionObject = collision.transform;
            isStackable = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag[0] == '1' && collision.tag[1] == '0')
        {
            collisionObject = null;
            isStackable = false;
        }
    }
}
