using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorFood : MonoBehaviour
{
    public PlayerMovement playerScript;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerScript = other.GetComponent<PlayerMovement>();
            playerScript.StartCoroutine(playerScript.Trippped());
            Destroy(gameObject);
        }
    }
}
