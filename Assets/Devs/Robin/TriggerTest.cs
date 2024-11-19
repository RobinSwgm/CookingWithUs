using UnityEngine;

public class TriggerTest : MonoBehaviour
{
    [SerializeField] GameObject slaPrefab;

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
                GameObject slaObj = Instantiate(slaPrefab, _spawn.position, Quaternion.identity, _parentRightHand.transform);
                slaObj.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f); // change its local scale in x y z format
            }
        }
    }
}
