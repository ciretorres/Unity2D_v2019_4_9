using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;

    private Rigidbody2D myRigidbody;
    private Animator animator;

    private Vector3 change;
    
    public bool canMove;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        myRigidbody = GetComponent<Rigidbody2D>();

        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        change = Vector3.zero;

        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        //Debug.Log(change);

        UpdateAnimationAndMove();
    }

    void UpdateAnimationAndMove()
    {
        if (canMove && change != Vector3.zero)
        {
            MoveCharacter();

            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);

            animator.SetBool("moving", true);
        }
        else
        {
            myRigidbody.velocity = Vector2.zero;
            animator.SetBool("moving", false);
        }
    }

    void MoveCharacter()
    {
        myRigidbody.MovePosition(transform.position + change * speed * Time.deltaTime);
    }
}
