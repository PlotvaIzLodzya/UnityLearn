using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitKey : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<GameManager>().GetComponent<GameManager>().exitKeyCounter++;
            Destroy(gameObject);
            Debug.Log("exit key counter: " + FindObjectOfType<GameManager>().GetComponent<GameManager>().exitKeyCounter);
        }
    }
}
