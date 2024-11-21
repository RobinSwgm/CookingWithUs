using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float turnSpeed;
    public float acceleration = 1;
    public float deceleration = 1;
    public float maxSpeed = 7;
    public float minSpeed = 1;
    public InputActionReference turn;
    [SerializeField] private float turnInput;

    public Rigidbody rb;

    public Animator animator;
        
    private void Update()
    {
        animator.SetFloat("PlayerSpeed", moveSpeed / maxSpeed);
        turnInput = turn.action.ReadValue<float>();
        if (turnInput != 0 && moveSpeed >= minSpeed)
        {
            moveSpeed -= deceleration * Time.deltaTime;
            moveSpeed = Mathf.Min(moveSpeed, maxSpeed);
        }
        if (turnInput == 0 && moveSpeed < maxSpeed)
        {
            moveSpeed += acceleration * Time.deltaTime;
            moveSpeed = Mathf.Min(moveSpeed, maxSpeed);
        }
        rb.velocity = transform.forward * moveSpeed;
        Quaternion deltaRotation = Quaternion.Euler(Vector3.up * turnInput * turnSpeed * Time.deltaTime);
        rb.MoveRotation(rb.rotation * deltaRotation);
    }
}
