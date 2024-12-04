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
    [SerializeField] private AudioSource playerSFXSource;
    [SerializeField] private AudioClip playerSteppingSound;
    [SerializeField] private AudioClip playerThrowingSound;
    [SerializeField] private AudioClip playerTrippingSound;
    [SerializeField] private float turnInput;
    public InputActionReference grab;
    public InputActionReference drop;

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
            if (drop.action.inProgress)
            {
                ThrowItems();
                hasCooked = false;
            }
        }
    }

    //private IEnumerator stepSfxLogic()
    //{
    //    while (true)
    //    {
    //        yield return new WaitForSeconds(moveSpeed / 100);
    //        if (!playerSFXSource.isPlaying)
    //        playerSFXSource.PlayOneShot(playerSteppingSound);
    //    }
    //}

    private IEnumerator StartUp()
    {
        yield return new WaitForSeconds(waitTime);
        //StartCoroutine(stepSfxLogic());
        canMove = true;
    }

    public IEnumerator Trippped()
    {
        playerSFXSource.PlayOneShot(playerTrippingSound);
        canMove = false;
        moveSpeed = 0;
        rb.velocity = new Vector3(0,0,0);
        yield return new WaitForSeconds(tripTime);
        canMove = true;
    }

    private void ThrowItems()
    {
        if (currentItems.Count != 0)
        {
            playerSFXSource.PlayOneShot(playerThrowingSound);

            Vector3 newSpawnPosition = new Vector3(0f, 10f, 0f);
            GameObject newDrop = Instantiate(DropHolder, spawnPosition.position, Quaternion.identity);
            for (int i = 0; i < currentItems.Count; i++)
            {
                Vector3 adjustedSpawnPosition = new Vector3(0f, 0.04f * i, 0f);
                Instantiate(currentItems[i], newDrop.transform.position + newDrop.transform.up * (0.04f * i), Quaternion.identity, newDrop.transform);
                Debug.Log("Dropped!");
            }
            for (int i = 0; i < currentItems.Count; i++)
            {
                GameObject ingredient = currentItems[i];
                Destroy(ingredient);
                currentItems.Remove(ingredient);
                i--;
            }
            ResetBurgerIngredients();
            ResetPizzaIngredients();
        }
    }

    public void ResetPizzaIngredients()
    {
        PizzaDough.iscreated = false;
        PizzaSauce.iscreated = false;
        PizzaMushroom.iscreated = false;
        PizzaPepperoni.iscreated = false;
    }
    public void ResetBurgerIngredients()
    {
        BurgerBottomBun.iscreated = false;
        BurgerCheese.iscreated = false;
        BurgerMeat.iscreated = false;
        BurgerSalad.iscreated = false;
        BurgerTomato.iscreated = false;
        BurgerTopBun.iscreated = false;
    }
}
