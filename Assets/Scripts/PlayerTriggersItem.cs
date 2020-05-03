using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTriggersItem : MonoBehaviour
{
    [SerializeField]
    private StackItem stackItem;
    [SerializeField]
    private Rigidbody2D rb2d;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!stackItem.IsStacked())
        {
            if (collision.tag[0] == '0')
            {
                rb2d.bodyType = RigidbodyType2D.Dynamic;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag[0] == '0')
        {
            rb2d.bodyType = RigidbodyType2D.Kinematic;
            rb2d.velocity = new Vector2(0f, 0f);
        }
    }
}
