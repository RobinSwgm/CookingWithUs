using UnityEngine;

public class PizzaDough : MonoBehaviour
{
    [SerializeField] GameObject pizzaDoughPrefab;

    private bool iscreated;

    [SerializeField]
    private GameObject _parentRightHand;

    [SerializeField]
    private Transform _spawn;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E) || Input.GetKey(KeyCode.UpArrow))
            {
                Debug.Log("Hit player");
                if (!iscreated)
                {
                    GameObject doughObj = Instantiate(pizzaDoughPrefab, _spawn.position, Quaternion.identity, _parentRightHand.transform);
                    doughObj.transform.localScale = new Vector3(0.02f, 0.0003f, 0.02f); // change its local scale in x y z format
                    doughObj.transform.localRotation = Quaternion.Euler(0f, 0f, 90f);
                    iscreated = true;
                }
            }
        }
    }
}
