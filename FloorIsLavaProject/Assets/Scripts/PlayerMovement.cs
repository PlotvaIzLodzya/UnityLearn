using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private int jumpCounter = 0;
    private bool isGrounded;
    private int _maxJumpAmount = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MovePlayer( float _speed, float verticalInput, float horizontalInput)
    {
        transform.rotation = Quaternion.LookRotation(new Vector3(Camera.main.transform.forward.x, 0, Camera.main.transform.forward.z));


        transform.Translate(transform.forward.normalized * _speed * Time.deltaTime * verticalInput, Space.World);
        transform.Translate(transform.right.normalized * _speed * Time.deltaTime * horizontalInput, Space.World);
    }

    private void Jump(Rigidbody _playerRb, float _jumpForce)
    {
        _playerRb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        jumpCounter++;
    }

    bool IsAbleToJump()
    {
        return jumpCounter < _maxJumpAmount;
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
        if (other.gameObject.CompareTag("PowerUp"))
        {
            if (other.gameObject.name == "AddJump(Clone)")
            {
                _maxJumpAmount++;
            }
            Destroy(other.gameObject);
        }
    }

    public void PlayerJump(Rigidbody _playerRb, float _jumpForce)
    {
        if (isGrounded)
        {
            Jump(_playerRb, _jumpForce);
            isGrounded = false;
        } else {
            if (IsAbleToJump())
            {
                _playerRb.velocity = Vector3.zero;
                Jump(_playerRb, _jumpForce);
            }
        }
    }

    public void SetMaxAmountJump(int _amount)
    {
        _maxJumpAmount = _amount;
    }

}
