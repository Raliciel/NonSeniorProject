using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkScript : MonoBehaviour
{
    public Vector3 size;
    private Bounds bounds;
    void Start()
    {
        bounds = GetBound();
        size = bounds.size;
    }

    Bounds GetBound()
    {
        Bounds bounds = new Bounds();
        Renderer[] renderers = gameObject.GetComponentsInChildren<Renderer>();
        if (renderers.Length > 0)
        {
            //Find first enabled renderer to start encapsulate from it
            foreach (Renderer renderer in renderers)
            {
                if (renderer.enabled)
                {
                    bounds = renderer.bounds;
                    break;
                }
            }

            //Encapsulate for all renderers

            foreach (Renderer renderer in renderers)
            {
                if (renderer.enabled)
                {
                    bounds.Encapsulate(renderer.bounds);
                }
            }
        }

        return bounds;
    }

    public Vector3 GetSize()
    {
        return size;
    }

    private void OnDrawGizmos()
    {
        Color color = new Vector4(0, .5f, .5f, 0.5f);
        Gizmos.color = color;
        Gizmos.DrawCube(bounds.center, bounds.size);
    }

}
