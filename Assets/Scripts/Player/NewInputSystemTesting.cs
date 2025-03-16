using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewInputSystemTesting : MonoBehaviour
{
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Jump" + context.phase);
            _rigidbody.AddForce(Vector3.up *5f, ForceMode.Impulse);
        }
    }

}
