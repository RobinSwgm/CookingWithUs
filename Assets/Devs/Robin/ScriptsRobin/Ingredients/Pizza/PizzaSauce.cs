using UnityEngine;

public class PizzaSauce : MonoBehaviour
{
    [SerializeField] GameObject pizzaSaucePrefab;

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

                    //zorgt ervoor dat de sauce boven de bodem van de pizza spawnt
                    Vector3 adjustedSpawnPosition = _spawn.position + new Vector3(0f, 0.02f, 0f);

                    //Debug.Log("Hit player");

                    GameObject sauceObj = Instantiate(pizzaSaucePrefab, adjustedSpawnPosition, Quaternion.identity, _parentRightHand.transform);

                   // sauceObj.transform.localScale = new Vector3(0.015f, 0.0003f, 0.015f); // change its local scale in x y z format
                    //sauceObj.transform.localRotation = Quaternion.Euler(0f, 0f, 90f);
                    iscreated = true;
                }
            }
        }
    }
}
