using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform target;
    public static Camera mainCamera;
    private Vector3 cameraTransform;
    [SerializeField] private float offsetY = -10;
    [SerializeField] private float offsetZ = -10;

    private void Awake()
    {
        mainCamera = GetComponent<Camera>();
        cameraTransform = transform.position;
        target = GameObject.FindWithTag("Player").transform;

        if (FindObjectOfType<PlayerControl>() != null)
        {
            transform.position = new Vector3(cameraTransform.x, target.position.y + offsetY, offsetZ);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) return;
        //Change Only when Player is proceed higher
        if (transform.position.y < target.position.y + offsetY)
        {
            transform.position = new Vector3(cameraTransform.x, target.position.y + offsetY, offsetZ);
        }
    }
}
