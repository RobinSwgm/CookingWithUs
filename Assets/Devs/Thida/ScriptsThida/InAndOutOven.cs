using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InAndOutOven : MonoBehaviour
{
    private bool m_IsEnabled; // staat de oven aan?
    private float m_OvenTimer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (m_IsEnabled)
        {
            // timer decreasen
            m_OvenTimer -= Time.deltaTime;
            if (m_OvenTimer < 0) // timer is voorbij!
            {
                m_IsEnabled = false; // oven gaat uit!
                // verwijder deeg
                // instantiate actual pizza!
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E) || Input.GetKey(KeyCode.UpArrow))
            {
                PlayerMovement _playerComponent = other.GetComponent<PlayerMovement>();
                if (_playerComponent != null)
                {
                    // hebben we deeg?
                    bool _hasDough = _playerComponent.HasDough();
                    if (_hasDough)
                    {
                        // ok, wehebben deeg
                        // we moeten deeg uit de handen verwijderen
                        // deeg spawnen in de oven
                        // particle system kan aan gaan (Vuur)
                        // timer gaat aan
                        m_OvenTimer = 10;
                        m_IsEnabled = true;
                    }
                }
            }
        }
        // 1: check of de speler hier is
        // 2: check of de speler minstens deeg in de hand is
        // 3: zoja, verwijder deeg uit de hand

    }
}
