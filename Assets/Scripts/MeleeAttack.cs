using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    [SerializeField]
    private new Camera camera;
    [SerializeField]
    private float distance;
    [SerializeField]
    private float distanceToTravelAfterHit;
    [SerializeField]
    private float rate;

    private bool hit = false;
    private Vector2 targetPos;

    private RaycastHit2D ray;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = Physics2D.Raycast(transform.position, camera.ScreenToWorldPoint(Input.mousePosition) - transform.position, distance);

            if (ray.collider != null)
            {
                if (ray.collider.tag[0] == '1')
                {
                    hit = true;

                    targetPos = ray.collider.transform.position + ((camera.ScreenToWorldPoint(Input.mousePosition) - transform.position) * distanceToTravelAfterHit);
                }
            }
        }

        if(hit)
        {
            ray.collider.transform.position = Vector2.Lerp(ray.collider.transform.position, targetPos, Vector2.Distance(ray.collider.transform.position, targetPos) / rate);
        }
    }
}
