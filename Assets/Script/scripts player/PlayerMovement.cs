using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float speed;
    private Rigidbody2D rb2d;
    private Vector2 direction;
    private Camera cam;
    [SerializeField] private Animator animator;
    private bool isMoving;

    public Vector2 Direction
    {
        get
        {
            return direction;
        }
    }

    private void Awake()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        rb2d = GetComponent<Rigidbody2D>();
        direction = Vector2.up;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Rotate();
        Move();
        Animator();
    }

    void Rotate()
    {
        Vector2 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 playerPosition = transform.position;
        Vector2 direction = mousePosition - playerPosition;
        direction = direction.normalized;
        //transform.up = direction;

    }

    void Move()
    {
                           
               
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");



        if (horizontal != 0f || vertical != 0f)
        {
            direction = new Vector2(horizontal, vertical).normalized;
            //animator.SetFloat("X", direction.x);
            //animator.SetFloat("Y", direction.y);
            //IsMoving = direction.magnitude > 0;
        }
       

        //if (horizontal > 0) transform.localScale = new Vector2(1, 1);
        //else if (horizontal < 0) transform.localScale = new Vector2(-1, 1);

        rb2d.velocity = new Vector2(horizontal, vertical).normalized * speed;
        
    }

    void Animator()
    {
        Vector2 input = new(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (input.x != 0)
        {
            transform.localScale = new Vector3(input.x, 1, 1);
        }

        isMoving = input != Vector2.zero;

        if (isMoving)
        {
            animator.SetFloat("X", input.x);
            animator.SetFloat("Y", input.y);
        }

        animator.SetBool("IsMoving", isMoving);


    }

}