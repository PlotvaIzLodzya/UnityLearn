using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float sensitivity = 1;
    private float horizontalInput;
    private float verticalInput;
    public GameObject player;
    Vector3 offset = new Vector3(0, 2.0f, 0);
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void LateUpdate()
    {
        
        MoveCamera();
    }

    void MoveCamera()
    {
        
        horizontalInput = Input.GetAxis("HorizontalCamera");
        verticalInput = Input.GetAxis("VerticalCamera");
        player.transform.Rotate(Vector3.up * Time.deltaTime * horizontalInput * sensitivity);
        transform.Translate(Vector3.up * verticalInput * Time.deltaTime);
        transform.LookAt(player.transform.position + offset);

    }
}
