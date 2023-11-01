using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSortingOrder : MonoBehaviour
{
    private int sortingOrder = 0;
    private SpriteRenderer selfSprite;

    private void Start()
    {
        selfSprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        sortingOrder = Mathf.FloorToInt(transform.position.y * -15);
        selfSprite.sortingOrder = sortingOrder;
    }
}
