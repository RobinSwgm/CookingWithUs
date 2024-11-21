using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoughCopy : MonoBehaviour
{
    [SerializeField] GameObject pizzaDoughPrefab;

    [SerializeField]
    private GameObject _parentRightHand;

    [SerializeField]
    private Transform _spawn;

    private PlayerMovement playerScript;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerScript = other.GetComponent<PlayerMovement>();
            if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (playerScript.currentItems.Count == 0)
                {
                    Debug.Log("Hit player");
                    GameObject doughObj = Instantiate(pizzaDoughPrefab, _spawn.position, Quaternion.identity, _parentRightHand.transform);
                    //doughObj.transform.localScale = new Vector3(0.02f, 0.0003f, 0.02f); // change its local scale in x y z format
                    //doughObj.transform.localRotation = Quaternion.Euler(0f, 0f, 90f);
                    playerScript.currentItems.Add(doughObj);
                }
            }
        }
    }
}
