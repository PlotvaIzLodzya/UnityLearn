﻿ using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5;
    public float jumpForce = 4;

    private Rigidbody playerRb;

    private bool isGrounded;

    private int jumpCounter = 0;
    public int maxJumpAmount = 1;
    public float jumpCooldown =2f;
    private int gravityModifier = 4;



    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        jumpPlayer();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            jumpCounter = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("PowerUp"))
        {
            if (other.gameObject.name == "AddJump(Clone)")
            {
                maxJumpAmount++;
            }
            Destroy(other.gameObject);
        }
    }
    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * speed * Time.deltaTime * verticalInput, Space.Self);
        transform.Translate(Vector3.right * speed * Time.deltaTime * horizontalInput, Space.Self);
    }

    void jumpPlayer()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                jumpCounter++;
                isGrounded = false;
            } else {
                if (IsAbleToJump())
                {
                    playerRb.velocity = Vector3.zero;
                    playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                    jumpCounter++;
                }
            }
        }
    }

    bool IsAbleToJump()
    {
        return jumpCounter < maxJumpAmount;
    }
}