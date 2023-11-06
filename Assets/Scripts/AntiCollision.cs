using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiCollision : MonoBehaviour
{
    [SerializeField] private BoxCollider2D platform;
    private Vector3 offset;
    private Color color;
    private Vector2 boxSize;
    // Start is called before the first frame update
    void Start()
    {
        platform.isTrigger = true; // this will make the collider disable
        offset = Vector3.up * platform.bounds.size.y;
        boxSize = platform.bounds.size;
    }

    private void OnDrawGizmos()
    {
        color = new Vector4(1, 0, 0, 0.5f);
        Gizmos.color = color;
        Gizmos.DrawCube(platform.bounds.center + offset, boxSize);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameObject.FindGameObjectWithTag("Player") == null) return;
        if (PlayerCheck())
        {
            platform.isTrigger = false;
        }
        else
        {
            platform.isTrigger = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>().SetGroundCheck(true); 
        }
    }

    public bool PlayerCheck()
    {
        Collider2D[] Colli = Physics2D.OverlapBoxAll(platform.bounds.center + offset, boxSize, 0);
        foreach (Collider2D col in Colli)
        {
            if (col.transform.CompareTag("Player"))
            {
                if (col.bounds.center.y - col.bounds.size.y / 2 <= platform.bounds.center.y + offset.y + boxSize.y / 2 &&
                    col.bounds.center.y - col.bounds.size.y / 2 >= platform.bounds.center.y + offset.y - boxSize.y / 2)
                {
                    return true;
                }
            }
        }
        return false;
    }
}
