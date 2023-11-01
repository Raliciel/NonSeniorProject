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
        platform = GetComponent<BoxCollider2D>();
        platform.isTrigger = true; // this will make the collider disable
        offset = Vector3.up * transform.localScale.y;
        boxSize = transform.localScale;
    }

    private void OnDrawGizmos()
    {
        color = new Vector4(1, 0, 0, 0.5f);
        Gizmos.color = color;
        Gizmos.DrawCube(transform.position + offset, boxSize);
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerCheck())
        {
            platform.isTrigger = false;
        }
        else
        {
            platform.isTrigger = true;
        }
    }

    bool PlayerCheck()
    {
        Collider2D[] Colli = Physics2D.OverlapBoxAll(transform.position + offset, boxSize, 0);
        foreach (Collider2D col in Colli)
        {
            if (col.transform.CompareTag("Player"))
            {
                return true;
            }
        }
        return false;
    }
}
