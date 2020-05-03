using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StackItem : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb2d;

    private bool isStacked = false;

    [SerializeField]
    private GameObject pressE;
    [SerializeField]
    private TextMeshProUGUI tmPro;

    private bool inputE = false;

    private BaseStack baseStack;

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!IsStacked())
        {
            if (collision.tag[0] == '2')
            {
                baseStack = collision.GetComponent<BaseStack>();

                tmPro.text = "Press E To Stack To " + collision.name;
                pressE.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag[0] == '2')
        {
            pressE.SetActive(false);
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            if (baseStack != null)
            {
                baseStack.Stack(transform);
                rb2d.bodyType = RigidbodyType2D.Kinematic;
                AddToStack();
                pressE.SetActive(false);
                baseStack = null;
            }
        }
    }
}
