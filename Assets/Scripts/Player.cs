using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Player : MonoBehaviour
{
    [SerializeField] private SpriteRenderer characterRenderer;

    private Camera camera;

    Rigidbody2D _rigidbody = null;

    public float speed = 1f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        camera = Camera.main;
    }

    private void Update()
    {
        Movement();
    }

    public void Movement()
    {
        Vector3 moveVelocity = Vector3.zero;

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        moveVelocity = new Vector3(horizontal,vertical,0) * speed * Time.deltaTime;
        transform.position += moveVelocity;

        if(horizontal < 0)
        {
            characterRenderer.flipX = true;
        }
        else if(horizontal > 0)
        {
            characterRenderer.flipX = false;
        }
    }
}
