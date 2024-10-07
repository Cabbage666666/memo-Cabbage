using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleWallCreator : MonoBehaviour
{
    public Vector3 wallPosition = new Vector3(0, 0, 0);
    public Vector3 wallSize = new Vector3(10, 10, 1);

    void Start()
    {
        CreateInvisibleWall(wallPosition, wallSize);
    }

    void CreateInvisibleWall(Vector3 position, Vector3 size)
    {
        GameObject invisibleWall = new GameObject("InvisibleWall");
        invisibleWall.transform.position = position;

        BoxCollider boxCollider = invisibleWall.AddComponent<BoxCollider>();
        boxCollider.size = size;

        // 确保空气墙不可见
        Renderer renderer = invisibleWall.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.enabled = false;
        }
    }
}