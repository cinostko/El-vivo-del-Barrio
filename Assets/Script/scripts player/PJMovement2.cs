using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PJMovement2 : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Animator animator;
    private bool isMoving;
    Rigidbody2D rb;


    private void Awake()
    {
        animator = GetComponent<Animator>(); 
        rb= GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        Movement();

    }

    void Movement()
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

        rb.velocity = new Vector2(input.x, input.y).normalized * speed;
    }




}
