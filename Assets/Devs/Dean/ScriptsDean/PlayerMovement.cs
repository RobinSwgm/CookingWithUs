using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    private Vector3 moveDirection;
    public InputActionReference move;

  private void Update()
    {
        moveDirection = move.action.ReadValue<Vector3>();
        rb.velocity = new Vector3(moveDirection.x * speed, gameObject.transform.position.y, moveDirection.z * speed);
    }
}
