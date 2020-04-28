using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    [SerializeField]
    private new Camera camera;
    [SerializeField]
    private float distance;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D ray = Physics2D.Raycast(transform.position, camera.ScreenToWorldPoint(Input.mousePosition) - transform.position, distance);

            if (ray.collider != null)
            {
                if (ray.collider.tag[0] == '1')
                {
                    ray.collider.GetComponent<Rigidbody2D>().AddForce(camera.ScreenToWorldPoint(Input.mousePosition) - transform.position, ForceMode2D.Impulse);
                }
            }
        }
    }
}
