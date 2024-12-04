using UnityEngine;

public class PizzaMain : MonoBehaviour
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
            /*if (Input.GetKey(KeyCode.E) || Input.GetKey(KeyCode.UpArrow))
            {
                AdjustedSpawnPoint();
                Debug.Log("Hit player");

            }*/

            if (playerScript.grab.action.inProgress)
            {
                AdjustedSpawnPoint();
                Debug.Log("Hit player");
            }
        }
    }
}
