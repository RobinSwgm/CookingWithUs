using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementClone : MonoBehaviour
{
    public float moveSpeed;
    public float turnSpeed;
    public InputActionReference turn;
    [SerializeField] private float turnInput;

    public Rigidbody rb;

    public Animator animator;

    private void Start()
    {
        animator.SetFloat("PlayerSpeed", 1);
    }

    private void Update()
    {
        turnInput = turn.action.ReadValue<float>();
        //transform.Rotate(Vector3.up * turnInput * turnSpeed * Time.deltaTime);
        rb.rotation = Quaternion.Euler(Vector3.up * turnInput * turnSpeed);
        rb.velocity = transform.forward * moveSpeed;
    }
}
