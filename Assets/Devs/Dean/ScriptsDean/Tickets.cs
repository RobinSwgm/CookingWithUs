using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class Tickets : MonoBehaviour
{
    public GameObject burgerBottomBun;
    public GameObject burgerTopBun;
    public List<GameObject> burgerTicketList;
    public List<GameObject> burgerIngredientList;
    public Transform burgerSpawnLocation;
    public float burgerYOffset = -100f;
    public float burgerInitialOffset = -50f;

    public GameObject pizzaDough;
    public GameObject pizzaSauce;
    public List<GameObject> pizzaTicketList;
    public List<GameObject> pizzaIngredientList;
    public Transform pizzaSpawnLocation;
    public float pizzaYOffset = 100f;
    public float pizzaInitialOffset = 50f;

    public int difficulty = 1;

    private void Start()
    {
        UpdateBurgerTicket();
        UpdatePizzaTicket();
    }

    private void CreateBurgerTicket()
    {
        burgerTicketList = new List<GameObject>();
        burgerTicketList.Add(burgerTopBun);

        int size = Random.Range(1, difficulty + 1);
        for (int i = 0; i < size; i++)
        {
            int choice = Random.Range(0, burgerIngredientList.Count);
            burgerTicketList.Add(burgerIngredientList[choice]);
        }

        burgerTicketList.Add(burgerBottomBun);
    }

    private void UpdateBurgerTicket()
    {
        CreateBurgerTicket();
        Vector3 spawnLocation = burgerSpawnLocation.position;

        for (int i = 0; i < burgerTicketList.Count; i++)
        {
            GameObject spawnedObject = Instantiate(burgerTicketList[i], burgerSpawnLocation);
            spawnedObject.transform.localPosition = new Vector3(0, i * burgerYOffset + burgerInitialOffset, 0);
        }
    }

    private void CreatePizzaTicket()
    {
        pizzaTicketList = new List<GameObject>();
        pizzaTicketList.Add(pizzaDough);
        pizzaTicketList.Add(pizzaSauce);

        int size = Random.Range(1, difficulty + 1);
        for (int i = 0; i < size; i++)
        {
            int choice = Random.Range(0, pizzaIngredientList.Count);
            pizzaTicketList.Add(pizzaIngredientList[choice]);
        }
    }

    private void UpdatePizzaTicket()
    {
        CreatePizzaTicket();
        Vector3 spawnLocation = pizzaSpawnLocation.position;

        for (int i = 0; i < pizzaTicketList.Count; i++)
        {
            GameObject spawnedObject = Instantiate(pizzaTicketList[i], pizzaSpawnLocation);
            spawnedObject.transform.localPosition = new Vector3(0, i * pizzaYOffset + pizzaInitialOffset, 0);
        }
    }
}
