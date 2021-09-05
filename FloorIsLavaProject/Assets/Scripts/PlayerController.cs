 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float _speed = 5;
    public float jumpForce = 490 ;

    private Rigidbody _playerRb;

    private bool isGrounded;

    private int jumpCounter = 0;
    public int maxJumpAmount = 1;
    private int gravityModifier = 4;
    private Vector3 _motion;



    // Start is called before the first frame update
    void Start()
    {
        _playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        jumpPlayer();
        MovePlayer();
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

    void jumpPlayer()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                _playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                jumpCounter++;
                isGrounded = false;
            } else {
                if (IsAbleToJump())
                {
                    _playerRb.velocity = Vector3.zero;
                    _playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                    jumpCounter++;
                }
            }
        }
    }

    bool IsAbleToJump()
    {
        return jumpCounter < maxJumpAmount;
    }
    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * _speed * Time.deltaTime * verticalInput, Space.Self);
        transform.Translate(Vector3.right * _speed * Time.deltaTime * horizontalInput, Space.Self);
    }

}
