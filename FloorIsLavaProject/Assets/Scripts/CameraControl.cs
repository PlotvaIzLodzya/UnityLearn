using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float _ySensitivity;
    public float _xSensitivity;
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


        Vector3 angle = Vector3.up * verticalInput * _xSensitivity * Time.deltaTime;
        player.transform.Rotate(Vector3.up * horizontalInput * _ySensitivity * Time.deltaTime);

        transform.Translate(angle);

        transform.LookAt(player.transform.position + offset);

    }   


}
