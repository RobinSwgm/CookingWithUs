using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaDough : MonoBehaviour
{
    [SerializeField] GameObject pizzaDoughPrefab;

    [SerializeField]
    private GameObject _parentRightHand;

    [SerializeField]
    private Transform _spawn;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E) || Input.GetKey(KeyCode.UpArrow))
            {
                Debug.Log("Hit player");
                GameObject slaObj = Instantiate(pizzaDoughPrefab, _spawn.position, Quaternion.identity, _parentRightHand.transform);
                slaObj.transform.localScale = new Vector3(0.02f, 0.0003f, 0.02f); // change its local scale in x y z format
            }
        }
    }
}
