using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{

    private Vector3 screenPoint;
    private Vector3 offset;
    private Rigidbody objectRigidbody;
    private Vector3 startPoint;
    private Vector3 releasePoint;
    private Vector3 throwDirecation;
    private bool isDragged;
    private float forceMultiplier = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        objectRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        AffectedByGravity();
    }



    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        objectRigidbody.velocity = Vector3.zero;
        isDragged = true;
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        StartCoroutine("SettingStartPoint");
    }

    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;

    }
    private void OnMouseUp()
    {
        releasePoint = transform.position;
        throwDirecation = releasePoint - startPoint;
        isDragged = false;
        objectRigidbody.AddForce(throwDirecation * forceMultiplier, ForceMode.Impulse);
    }

    IEnumerator SettingStartPoint()
    {
        while (isDragged)
        {
            yield return new WaitForSeconds(0.2f);
            startPoint = transform.position;
        }
    }

    private void AffectedByGravity()
    {
        objectRigidbody.useGravity = !isDragged;
    }
}
