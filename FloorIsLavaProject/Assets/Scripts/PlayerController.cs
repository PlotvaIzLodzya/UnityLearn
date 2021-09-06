 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float _speed = 5;
    public float jumpForce = 490 ;

    private Rigidbody _playerRb;
    public Camera _camera;

    private bool isGrounded;

    private int jumpCounter = 0;
    public int maxJumpAmount = 1;
    private int gravityModifier = 4;

    Vector3 _normal;



    // Start is called before the first frame update
    void Start()
    {
        _playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 _forward = _camera.transform.forward;
        //Vector3 _right = _camera.transform.right;

        jumpPlayer();
        MovePlayer();
    }

    private void OnCollisionEnter(Collision collision)
    {
        _normal = collision.contacts[0].normal;
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
                Jump();
                isGrounded = false;
            } else {
                if (IsAbleToJump())
                {
                    _playerRb.velocity = Vector3.zero;
                    Jump();
                }
            }
        }
    }

    bool IsAbleToJump()
    {
        return jumpCounter < maxJumpAmount;
    }

    private void Jump()
    {
        _playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        jumpCounter++;
    }
    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        transform.rotation = Quaternion.LookRotation(new Vector3(Camera.main.transform.forward.x, 0, Camera.main.transform.forward.z));

       transform.Translate(Project(_camera.transform.forward).normalized * _speed * Time.deltaTime * verticalInput, Space.World);
       transform.Translate(Project(_camera.transform.right).normalized *  _speed * Time.deltaTime * horizontalInput, Space.World);
    }

    public Vector3 Project (Vector3 _forward)
    {
        return _forward - Vector3.Dot(_forward, _normal) * _normal;
    }

}
