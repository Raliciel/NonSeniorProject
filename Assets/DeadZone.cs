using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour 
{

    private Color color;
    private Vector2 boxSize;

    // Start is called before the first frame update
    private void OnDrawGizmos()
    {
        color = new Vector4(1, 0, 0, 0.5f);
        Gizmos.color = color;
        Gizmos.DrawCube(transform.position, boxSize);
    }

    bool PlayerCheck()
    {
        Collider2D[] Colli = Physics2D.OverlapBoxAll(transform.position, boxSize, 0);
        foreach (Collider2D col in Colli)
        {
            if (col.transform.CompareTag("Player"))
            {
                return true;
            }
        }
        return false;
    }

    private void Start()
    {
        boxSize = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerCheck())
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>().Death();
        }
    }
}
