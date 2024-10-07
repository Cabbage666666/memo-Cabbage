using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private PlayerController playerController;
    private bool isFacingRight;
    

    void Start()
    {
        playerController = GetComponentInParent<PlayerController>();
         if (playerController != null)
        {
            bool facingRight = playerController.IsFacingRight; 
        }
    }
    
   void Update()
    {
        // 获取鼠标位置
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0; // 确保 z 轴为 0

        // 计算枪口指向鼠标的方向
        Vector3 direction = mousePosition - transform.position;

        // 计算枪口指向鼠标的角度
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // 设置枪口的旋转
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        // 在 x < 0 时翻转枪口
        if (direction.x < 0)
        {
            transform.localScale = new Vector3(1, -1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        
        // 根据人物的方向调整枪的翻转
        if (!playerController.IsFacingRight)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
    }
}
