using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour

{
    public GameManager manager;
    
    public float movePower = 1f;
    private float speed = 5.0f;
    GameObject scanObject;

    Rigidbody2D rigid;
    public SpriteRenderer rend;
    Animator animator;

   

    // Start is called before the first frame update
    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();

        rend = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetAxisRaw("Horizontal") == 0)
        {

            animator.SetBool("move", false);
            animator.SetBool("run", false);
            animator.SetBool("swing", false);
            animator.SetBool("bow", false);
            animator.SetBool("item_pickup", false);
           
        }

        else if (Input.GetAxisRaw("Horizontal") > 0)
        {

            animator.SetBool("move", true);
        }

        else if (Input.GetAxisRaw("Horizontal") < 0)
        {

            animator.SetBool("move", true);
        }

        else if (Input.GetKey(KeyCode.RightControl))
        {
            speed += 10.0f;
            animator.SetBool("run", true);
        }

        if (Input.GetKey(KeyCode.X))
        {
            animator.SetBool("swing", true);

        }

        else if (Input.GetKey(KeyCode.V))
        {
            animator.SetBool("bow", true);
        }

        else if(Input.GetMouseButtonDown(0))
        {
            manager.Action(scanObject);
        }

    }

    void FixedUpdate()
    {
        Move ();
    }

    void Move()
    {
        Vector3 moveVelocity = Vector3.zero;

        if(Input.GetAxisRaw("Horizontal")<0)
        {
            moveVelocity = Vector3.left;

            rend.flipX = false;
        }

        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            moveVelocity = Vector3.right;
            rend.flipX = true;
        }

        transform.position += moveVelocity * movePower * Time.deltaTime;
    }
}
