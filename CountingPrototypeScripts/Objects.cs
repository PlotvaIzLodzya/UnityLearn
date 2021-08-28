using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objects : MonoBehaviour
{

    private Vector3 screenPoint;
    private Vector3 offset;
    private Rigidbody objectRigidbody;
    private Vector3 startPoint;
    private Vector3 releasePoint;
    private Vector3 throwDirecation;
    private bool isDragged;
    private float _forceMultiplier;
    private GameManager gameManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        objectRigidbody = GetComponent<Rigidbody>();
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
        this._forceMultiplier = gameManagerScript._forceMultiplier;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ConstrainObject();
    }



    void OnMouseDown()
    {
        
        isDragged = true;
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        gameObject.transform.position = new Vector3(0, transform.position.y, transform.position.z);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

        StartCoroutine("SettingStartPoint");
    }

    void OnMouseDrag()
    {
        if (isDragged)
        {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
            transform.position = curPosition;
        }
    }
    private void OnMouseUp()
    {
        if (isDragged)
        {
            releasePoint = transform.position;
            throwDirecation = releasePoint - startPoint;
            isDragged = false;
            objectRigidbody.AddForce(throwDirecation * _forceMultiplier, ForceMode.Impulse);
        }
    }

    IEnumerator SettingStartPoint()
    {
        while (isDragged)
        {
            startPoint = transform.position;
            yield return new WaitForSeconds(0.25f);
        }
    }

    private void ConstrainObject()
    {
        objectRigidbody.useGravity = !isDragged;
        if (isDragged)
        {
            objectRigidbody.velocity = Vector3.zero;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") && isDragged)
        {
            isDragged = false; 
        }
    }


}
