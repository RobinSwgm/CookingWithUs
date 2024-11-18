using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float turnSpeed;
    public InputActionReference turn;
    private float turnInput;

    public Animator animator;

    private void Start()
    {
        animator.SetFloat("PlayerSpeed", 1);
    }

    private void Update()
    {
        turnInput = turn.action.ReadValue<float>();
        transform.Rotate(Vector3.up * turnInput * turnSpeed * Time.deltaTime);
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }
}
