using System.Collections.Generic;
using UnityEngine;

public class PickupScriptWrongVrsion : MonoBehaviour
{
    [SerializeField]
    private List<string> _foods;
    [SerializeField]
    private List<GameObject> _foodObj;

    [SerializeField]
    private Transform _spawn;

    [SerializeField]
    private GameObject _parentRightHand;

    private void Start()
    {
        _foods = new List<string>();
        _foodObj = new List<GameObject>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Food")
        {

            if (!_foods.Contains(other.gameObject.name))
            {
                Debug.Log(other.gameObject.name);

                if (Input.GetKey(KeyCode.E) || Input.GetKey(KeyCode.UpArrow))
                {
                    _foods.Add(other.gameObject.name);
                    _foodObj.Add(other.gameObject);
                    PickUpItems();
                }
            }
            else
            {
                Debug.Log("{other.gameObject.name} is already in your inventory.");
            }
        }
    }

    public void PickUpItems()
    {
        if (_foodObj.Count > 0)
        {
            Instantiate(_foodObj[0], _spawn.position, Quaternion.identity, _parentRightHand.transform);
            _foodObj[0].transform.localScale = new Vector3(0.01f, 0.01f, 0.01f); // change its local scale in x y z format

        }

    }
}
