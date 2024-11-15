using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float turnSpeed;
    public InputActionReference turn;
    private float turnInput;

    public Animator animator;

    private Vector3 lastPosition;
    private float currentSpeed;

    private void Start()
    {
        lastPosition = transform.position;
    }

    private void Update()
    {
        turnInput = turn.action.ReadValue<float>();
        transform.Rotate(Vector3.up * turnInput * turnSpeed * Time.deltaTime);
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        currentSpeed = (transform.position - lastPosition).magnitude / Time.deltaTime;
        animator.SetFloat("PlayerSpeed", currentSpeed);
        lastPosition = transform.position;
        Debug.Log(currentSpeed);
    }
}
