using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab; // 子弹预制体
    public float bulletSpeed = 5f;  // 子弹速度
    public int bulletCount = 12;    // 子弹数量

    void Update()
    {
        if (Input.GetMouseButtonDown(1)) // 检测鼠标右键点击
        {
            ShootBullets();
        }
    }

    void ShootBullets()
    {
        for (int i = 0; i < bulletCount; i++)
        {
            float randomAngle = Random.Range(0f, 360f); // 随机角度
            float bulletDirX = Mathf.Cos(randomAngle * Mathf.Deg2Rad);
            float bulletDirY = Mathf.Sin(randomAngle * Mathf.Deg2Rad);

            Vector3 bulletMoveDirection = new Vector3(bulletDirX, bulletDirY, 0).normalized * bulletSpeed;

            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletMoveDirection.x, bulletMoveDirection.y);
        }
    }
}