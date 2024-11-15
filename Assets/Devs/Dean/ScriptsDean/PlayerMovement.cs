using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float turnSpeed;
    public InputActionReference turn;
    private float turnInput;

  private void Update()
    {
        turnInput = turn.action.ReadValue<float>();
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        transform.Rotate(transform.up * turnInput * turnSpeed * Time.deltaTime);
    }
}
