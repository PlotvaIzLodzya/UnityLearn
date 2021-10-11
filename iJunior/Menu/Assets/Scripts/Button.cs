using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(Button))]

public class Button : MonoBehaviour
{
    private RectTransform _button;
    // Start is called before the first frame update
    void Start()
    {
        _button = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
