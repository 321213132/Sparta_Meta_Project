using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Player : MonoBehaviour
{
    [SerializeField] private SpriteRenderer characterRenderer;

    private Camera camera;

    Vector3 moveVelocity = Vector3.zero;

    Rigidbody2D _rigidbody;
    Animator _animator;
    string animState = "AnimState";
    
    public float speed = 1f;


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
        camera = Camera.main;
    }

    private void Update()
    {
        Movement();
        MoveAnim();
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
