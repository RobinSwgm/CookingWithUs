using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InAndOutOven : MonoBehaviour
{
    private bool m_IsEnabled;
    [SerializeField] private float m_OvenTimer;
    [SerializeField] private PlayerMovement playerscript;

    public bool isCooked = false;
    public List<GameObject> cookingList;
    public TextMeshProUGUI ovenTimer;

    private void Update()
    {
        if (m_IsEnabled)
        {
            m_OvenTimer -= Time.deltaTime;
            if (m_OvenTimer <= 0)
            {
                m_IsEnabled = false;
                isCooked = true;
            }
        }
        ovenTimer.text = "Timer: " + Mathf.Round(m_OvenTimer).ToString();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovement _playerComponent = other.GetComponent<PlayerMovement>();
            if (_playerComponent.grab.action.inProgress)
            {
                if (_playerComponent != null)
                {
                    if (_playerComponent.currentItems.Count > 0 && !m_IsEnabled && !isCooked && !_playerComponent.hasCooked)
                    {
                        m_OvenTimer = 3;
                        m_IsEnabled = true;
                        for (int i = 0; i < _playerComponent.currentItems.Count; i++)
                        {
                            GameObject ingredient = _playerComponent.currentItems[i];
                            ingredient.SetActive(false);
                        }
                    }

                    if (_playerComponent.currentItems.Count > 0 && !m_IsEnabled && isCooked && !_playerComponent.hasCooked)
                    {
                        for (int i = 0; i < _playerComponent.currentItems.Count; i++)
                        {
                            GameObject ingredient = _playerComponent.currentItems[i];
                            ingredient.SetActive(true);
                            isCooked = false;
                            _playerComponent.hasCooked = true;
                        }
                    }
                }
            }
        }
    }
}
