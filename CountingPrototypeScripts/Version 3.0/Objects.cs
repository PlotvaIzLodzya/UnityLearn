using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objects : MonoBehaviour
{

    private Vector3 screenPoint;
    private Rigidbody objectRigidbody;
    private bool isDragged;
    private GameManager gameManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        objectRigidbody = GetComponent<Rigidbody>();
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ConstrainObject();
    }

    public void OnMouseDown()
    {
        isDragged = true;
    }
    void OnMouseDrag()
    {
        if (gameManagerScript.isPreparationTime == false && isDragged == true)
        {   
            screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
            gameObject.transform.position = new Vector3(0, transform.position.y, transform.position.z);
            Vector3 forceDirection = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z)) - transform.position;
            objectRigidbody.AddForce(forceDirection * gameManagerScript._forceMultiplier, ForceMode.VelocityChange);
        }
    }

    private void OnMouseUp()
    {
        isDragged = false;
    }

    private void ConstrainObject()
    {
        objectRigidbody.useGravity = !isDragged;

        if (isDragged)
            objectRigidbody.velocity = Vector3.zero;
    }

    private void OnTriggerEnter(Collider other)
    {
        isDragged = false;
    }

}
