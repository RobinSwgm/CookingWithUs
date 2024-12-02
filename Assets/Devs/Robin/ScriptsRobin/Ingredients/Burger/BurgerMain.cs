using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgerMain : MonoBehaviour
{
    // [SerializeField] GameObject pizzaDoughPrefab;

    public GameObject _parentRightHand;

    public Transform _spawn;

    public PlayerMovement playerScript;


    protected virtual void AdjustedSpawnPoint()
    {

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerScript = other.GetComponent<PlayerMovement>();
            if (Input.GetKey(KeyCode.E) || Input.GetKey(KeyCode.UpArrow))
            {
                AdjustedSpawnPoint();
                Debug.Log("Hit player");

            }
        }
    }
}
