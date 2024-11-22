using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaPepperoni : MonoBehaviour
{
    [SerializeField] GameObject pizzaPepperoniPrefab;

    [SerializeField]
    private GameObject _parentRightHand;

    private bool iscreated;

    [SerializeField]
    private Transform _spawn;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E) || Input.GetKey(KeyCode.UpArrow))
            {
                if (!iscreated)
                {

                    //zorgt ervoor dat de pepperoni boven de sauce van de pizza spawnt
                    Vector3 adjustedSpawnPosition = _spawn.position + new Vector3(0f, 0.08f, 0f);

                    //Debug.Log("Hit player");

                    GameObject pepperoniObj = Instantiate(pizzaPepperoniPrefab, adjustedSpawnPosition, Quaternion.identity, _parentRightHand.transform);

                    //pepperoniObj.transform.localScale = new Vector3(0.008f, 0.0002f, 0.008f); // change its local scale in x y z format
                    //pepperoniObj.transform.localRotation = Quaternion.Euler(0f, 0f, 90f);
                    iscreated = true;
                }
            }
        }
    }
}
