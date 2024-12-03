using System;
using System.Collections;
using System.Collections.Generic;
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

    public List<GameObject> currentItems;
    public bool hasCooked = false;

    private bool canMove = false;
    public float waitTime = 3;

    public float tripTime = 2;

    public GameObject DropHolder;
    public Transform spawnPosition;

    private void Start()
    {
        StartCoroutine(StartUp());
    }

    private void Update()
    {
        if (canMove)
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

            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                ThrowItems();
                hasCooked = false;
            }
        }
    }

    private IEnumerator StartUp()
    {
        yield return new WaitForSeconds(waitTime);
        canMove = true;
    }

    public IEnumerator Trippped()
    {
        canMove = false;
        rb.velocity = new Vector3(0,0,0);
        yield return new WaitForSeconds(tripTime);
        canMove = true;
    }

    private void ThrowItems()
    {
        if (currentItems.Count != 0)
        {
            Vector3 newSpawnPosition = new Vector3(0f, 10f, 0f);
            GameObject newDrop = Instantiate(DropHolder, spawnPosition.position, Quaternion.identity);
            for (int i = 0; i < currentItems.Count; i++)
            {
                Vector3 adjustedSpawnPosition = new Vector3(0f, 0.04f * i, 0f);
                Instantiate(currentItems[i], newDrop.transform.position + newDrop.transform.up * (0.04f * i), Quaternion.identity, newDrop.transform);
            }
            for (int i = 0; i < currentItems.Count; i++)
            {
                GameObject ingredient = currentItems[i];
                Destroy(ingredient);
                currentItems.Remove(ingredient);
                i--;
            }
        }
    }
}
