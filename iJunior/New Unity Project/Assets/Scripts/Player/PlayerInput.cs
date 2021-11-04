using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    public event UnityAction CastSpellPressed;

    public event UnityAction<KeyCode> KeyboardButtonPressed;

    private void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            KeyboardButtonPressed?.Invoke(KeyCode.D);
        }

        if (Input.GetKey(KeyCode.A))
        {
            KeyboardButtonPressed?.Invoke(KeyCode.A);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            KeyboardButtonPressed?.Invoke(KeyCode.Space);
        }

        if (Input.GetMouseButtonDown(0))
        {
            CastSpellPressed?.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            KeyboardButtonPressed?.Invoke(KeyCode.E);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            KeyboardButtonPressed?.Invoke(KeyCode.Q);
        }
    }
}
