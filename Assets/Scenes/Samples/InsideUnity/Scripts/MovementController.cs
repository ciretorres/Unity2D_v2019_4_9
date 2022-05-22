using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    // Toma el rigidbody de este objeto
    new Rigidbody2D rigidbody;
    Animator animator;

    public float speed = 64f;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float hor = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");

        if(hor != 0 || ver != 0)
        {
            //Vector2 velocity = new Vector2(hor, ver);
            //Vector2 velocity = new Vector2(hor, ver) * speed;
            Vector2 velocity = new Vector2(hor, ver).normalized * speed;

            //rigidbody.velocity = Vector2.right;
            rigidbody.velocity = velocity;

            animator.SetFloat("Horizontal", hor);
            animator.SetFloat("Vertical", ver);
            animator.SetBool("Moving", true);
        }
        else
        {
            rigidbody.velocity = Vector2.zero;
            animator.SetBool("Moving", false);
        }

        
    }
}
