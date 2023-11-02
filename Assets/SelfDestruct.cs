using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    private Transform player;
    [SerializeField] float offset;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) return;
        if (transform.position.y < player.position.y - offset) Destroy(gameObject);
    }
}
