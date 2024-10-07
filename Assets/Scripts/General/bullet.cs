using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class bullet : MonoBehaviour {
    private float m_nextFire;
 
    /// <summary>
    /// 开火速率
    /// </summary>
    public float FireRate = 2.0f;
 
    /// <summary>
    /// 子弹对象
    /// </summary>
    public GameObject Bullet;
 
    /// <summary>
    /// 子弹速度
    /// </summary>
    public float BulletSpeed;
 
    void FixedUpdate()
    {
        m_nextFire = m_nextFire + Time.fixedDeltaTime;
 
        if(Input.GetMouseButton(0) && m_nextFire>FireRate)
        {
            // 获取鼠标坐标并转换成世界坐标
            Vector3 m_mousePosition = Input.mousePosition;
            m_mousePosition = Camera.main.ScreenToWorldPoint(m_mousePosition);
            // 因为是2D，用不到z轴。使将z轴的值为0，这样鼠标的坐标就在(x,y)平面上了
            m_mousePosition.z = 0;
 
            // 子弹角度
            float m_fireAngle = Vector2.Angle(m_mousePosition - this.transform.position, Vector2.up);
 
            if(m_mousePosition.x>this.transform.position.x)
            {
                m_fireAngle = -m_fireAngle;
            }
 
            // 计时器归零
            m_nextFire = 0;
 
            // 生成子弹
            GameObject m_bullet = Instantiate(Bullet, transform.position, Quaternion.identity) as GameObject;
 
            // 速度
            m_bullet.GetComponent<Rigidbody2D>().velocity = ((m_mousePosition-transform.position).normalized * BulletSpeed);
 
            // 角度
            m_bullet.transform.eulerAngles = new Vector3(0, 0, m_fireAngle);
 
        }
 
    }
 
}
