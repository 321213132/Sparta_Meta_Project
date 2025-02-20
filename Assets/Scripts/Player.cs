using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Player : MonoBehaviour
{
    public Vector3 moveVelocity = Vector3.zero;

    Rigidbody2D _rigidbody;
    Animator _animator;
    string animState = "AnimState";


    public float speed = 5f;
    public float upDown = 4f;
    public float posY = 0f;
    public int num = 1;
    //입력받은 값을 받아 애니메이션 출력을 위한 ENUM
    enum States 
    {
        up = 1,
        down = 2,
        left = 3,
        right = 4,
        Idle = 5
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }
    private void Start()
    {
        
    }

    private void Update()
    {
        if(speed == 10f)
        {
            GameObject.Find("Player").transform.Find("Area").gameObject.SetActive(true);
            MinigameMove();
        }
        else
        {
            Movement();

        }

        MoveAnim();
    }

    public void MinigameMove()
    {
        moveVelocity = new Vector3(speed * Time.deltaTime,0);
        transform.position += moveVelocity;

        if(Input.GetKeyDown(KeyCode.W) && transform.position.y !=4)
        {
            posY += upDown;
            transform.position = new Vector3(transform.position.x, posY, transform.position.z);
        }
        if(Input.GetKeyDown(KeyCode.S) && transform.position.y != -4)
        {
            posY -= upDown;
            transform.position = new Vector3(transform.position.x, posY, transform.position.z);
        }
    }

    public void Movement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        moveVelocity = new Vector3(horizontal,vertical) * speed * Time.deltaTime;
        transform.position += moveVelocity;
    }

    public void MoveAnim()
    {
        if(moveVelocity.x > 0)//right
        {
            _animator.SetInteger(animState, (int)States.right);
        }
        else if(moveVelocity.x < 0)//left
        {
            _animator.SetInteger(animState, (int)States.left);
        }
        else if (moveVelocity.y > 0)//up
        {
            _animator.SetInteger(animState, (int)States.up);
        }
        else if (moveVelocity.y < 0)//down
        {
            _animator.SetInteger(animState, (int)States.down);
        }
        else
        {
            _animator.SetInteger(animState, (int)States.Idle);
        }
    }

    
}
