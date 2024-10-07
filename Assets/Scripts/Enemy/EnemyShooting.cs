using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyShooting : MonoBehaviour
{
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

    /// <summary>
    /// 玩家 Transform
    /// </summary>
    private Transform Player;

    public UnityEvent<Transform> OnTakeDamage;
    public float shootDamage = 20.0f;

     public class Attack
    {
        public Transform transform { get; set; }
        public float damage;
        private float shootDamage;

        public Attack(float shootDamage)
        {
            this.shootDamage = shootDamage;
        }
    }

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player")?.transform;
    }

    void FixedUpdate()
    {
        if (Player == null) return;

        m_nextFire += Time.fixedDeltaTime;

        if (m_nextFire > FireRate)
        {
            /// 获取Player坐标并转换成世界坐标
            Vector3 playerPosition = Player.position;

            // 因为是2D，用不到z轴。使将z轴的值为0
            playerPosition.z = 0;
 
            // 子弹角度
            float m_fireAngle = Vector2.Angle(playerPosition - this.transform.position, Vector2.up);
 
            if(playerPosition.x>this.transform.position.x)
            {
                m_fireAngle = -m_fireAngle;
            }
 
            // 计时器归零
            m_nextFire = 0;
 
            // 生成子弹
            GameObject m_bullet = Instantiate(Bullet, transform.position, Quaternion.identity) as GameObject;
 
            // 速度
            m_bullet.GetComponent<Rigidbody2D>().velocity = (playerPosition-transform.position).normalized * BulletSpeed;
 
            // 角度
            m_bullet.transform.eulerAngles = new Vector3(0, 0, m_fireAngle);

            // 设置子弹标签
            m_bullet.tag = "EnemyBullet";
        }
    }
         void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet") && Player)
        {
            Character playerCharacter = collision.gameObject.GetComponent<Character>();
            if (playerCharacter != null)
            {
                Attack attack = new Attack (shootDamage) ;
            
                playerCharacter.TakeDamage(attack);

                // 销毁子弹
                Destroy(collision.gameObject);
            };
        }
    }
}
   
