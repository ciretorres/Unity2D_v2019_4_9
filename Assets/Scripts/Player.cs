using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //public float speed = 32f;
    public float speed = 64f;

    private Animator animator;

    Rigidbody2D rigidBody;

    Vector2 mov;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //animator.SetFloat("Speed", speed);

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if (horizontal != 0 || vertical != 0)
        {
            animator.SetFloat("Horizontal", horizontal);
            animator.SetFloat("Vertical", vertical);

            animator.SetFloat("Speed", 1);
        }
        else
        {
            animator.SetFloat("Speed", 0);
        }

        mov = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")            
        ).normalized;

        //transform.position = Vector3.MoveTowards(
        //    transform.position,
        //    transform.position + mov,
        //    speed * Time.deltaTime
        //);

        //animator.SetFloat("Horizontal", mov.x);
        //animator.SetFloat("Vertical", mov.y);

    }

    private void FixedUpdate()
    {
        rigidBody.MovePosition(rigidBody.position + mov * speed * Time.deltaTime);
    }
}
