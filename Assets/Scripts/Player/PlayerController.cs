using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    public PlayerInputControls inputControl;
    private Rigidbody2D rb;
    public Vector2 inputDirection;
    public float speed;
    
    private bool isFacingRight = true;

    public GameObject Player;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Player = this.gameObject;
    }

    public bool IsFacingRight
    {
        get { return isFacingRight; }
    }

    private void Awake()
    {
        inputControl = new PlayerInputControls();

        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        inputControl.Enable();
    }

    private void OnDisable()
    {
        inputControl.Disable();
    }

    private void Update()
    {
        inputDirection = inputControl.Gameplay.Move.ReadValue<Vector2>();

        if (Player == null)
        {
            Debug.Log("Player is null, loading GameOver scene.");
            SceneManager.LoadScene(2);
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
       rb.velocity  = new Vector2(inputDirection.x * speed * Time.deltaTime , inputDirection.y * speed * Time.deltaTime);

       int faceDir = (int)transform.localScale.x;

        if(inputDirection.x > 0)
        faceDir = 1;
         
        if(inputDirection.x < 0)
        faceDir = -1;
        
       //人物翻转
       transform.localScale = new Vector3(faceDir , 1 , 1);

       // 根据 inputDirection 更新人物的面向方向
        if (inputDirection.x > 0 && !isFacingRight)
        {
            Flip();
        }
        else if (inputDirection.x < 0 && isFacingRight)
        {
            Flip();
        }
    }

     private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        theScale.y *= -1;
        transform.localScale = theScale;
    }


}
