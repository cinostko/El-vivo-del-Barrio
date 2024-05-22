using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float speed;
    private Rigidbody2D rb2d;
    private Vector2 direction;
    private Camera cam;

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
    }

    void Update()
    {
        Rotate();
        Move();
    }

    void Rotate()
    {
        Vector2 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 playerPosition = transform.position;
        Vector2 direction = mousePosition - playerPosition;
        direction = direction.normalized;
        transform.up = direction;

    }

    void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if (horizontal != 0f || vertical != 0f)
        {
            direction = new Vector2(horizontal, vertical).normalized;
        }

        rb2d.velocity = new Vector2(horizontal, vertical).normalized * speed;
    }
}