using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalaxScript : MonoBehaviour
{
    [SerializeField] GameObject bgTile;
    [SerializeField] Transform camera;
    [SerializeField] private int strech = 2;
    private static int tileCount = 1;

    void Start()
    {
        camera = GameObject.FindObjectOfType<Camera>().transform;

        GameObject bgObject = Instantiate(bgTile, transform.position + Vector3.up * 13.33f * tileCount, Quaternion.identity);
        bgObject.transform.parent = transform;
        tileCount++;
    }

    private void Update()
    {
        if (camera == null ) return;
        transform.position = camera.position.y/1000 * Vector3.up;
        if (transform.childCount < strech)
        {
            GameObject bgObject = Instantiate(bgTile, transform.position + Vector3.up * 13.33f * tileCount, Quaternion.identity);
            bgObject.transform.parent = transform;
            tileCount++;
        }
    }
}
