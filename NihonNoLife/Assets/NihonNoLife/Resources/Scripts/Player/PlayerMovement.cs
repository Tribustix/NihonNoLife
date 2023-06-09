using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 2f;
    public Vector2 movement;

    private Rigidbody2D rigid;
    private Animator animator;
    private bool playerPaused = false;

    public GameObject smartphone;

    public VectorValue startingPosition;

    private void Awake()
    {
        transform.position = startingPosition.initialValue;
    }

    private void Start() 
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.None;
    }

    private void Update() 
    {
        
        if(!playerPaused) 
        {
            movement.x = Input.GetAxis("Horizontal");
            movement.y = Input.GetAxis("Vertical");

            animator.SetFloat("Speed", movement.sqrMagnitude);

            if (movement.x != 0)
            {
                animator.SetFloat("InputX", movement.x);
                animator.SetFloat("InputY", 0);
            }

            if (movement.y != 0)
            {
                animator.SetFloat("InputY", movement.y);
                animator.SetFloat("InputX", 0);
            }
        }

        if(Input.GetKeyDown(KeyCode.P)) 
        {
            if (smartphone.activeSelf) 
            {
                smartphone.SetActive(false);
                playerPaused = false;
                speed = 2f;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            } 
            else 
            {
                smartphone.SetActive(true);
                playerPaused = true;
                speed = 0f;
               
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    private void FixedUpdate() 
    {
        rigid.MovePosition(rigid.position + movement.normalized * (speed * Time.deltaTime));
    }
}
