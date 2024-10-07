using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bound : MonoBehaviour
{
        // 定义边界
    public float minX = -35f;
    public float maxX = 35f;
    public float minY = -20f;
    public float maxY = 20f;

    void Update()
    {
         // 边界检查
        CheckBounds();
    }

    private void CheckBounds()
    {
        Vector3 position = transform.position;

        // 限制玩家在边界内
        position.x = Mathf.Clamp(position.x, minX, maxX);
        position.y = Mathf.Clamp(position.y, minY, maxY);

        transform.position = position;
    }
}
