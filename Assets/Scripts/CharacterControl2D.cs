using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterControl2D : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 motionVector;
    [SerializeField] float speed = 5f;
    public Vector2 lastMotionVector;
    bool isMoving = true;

    Animator animator;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame


   void Update()
    {
      

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        motionVector = new Vector2(
            horizontal,
            vertical
            );
        animator.SetFloat("horizontal", horizontal);
        animator.SetFloat("vertical", vertical);


        isMoving = (horizontal != 0 ||  vertical != 0);
        animator.SetBool("isMoving", isMoving);

        if(isMoving )
        {
            lastMotionVector = new Vector2(horizontal, vertical).normalized;
            animator.SetFloat("lastHorizontal", horizontal);
            animator.SetFloat("lastVertical", vertical);

        }


    }
    void FixedUpdate()
    {
        Move();
    }



    private void Move()
    {
        rb.velocity = motionVector * speed;
    }
}
