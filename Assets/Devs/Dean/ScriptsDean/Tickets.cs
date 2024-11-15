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

    public TextMeshProUGUI ticketList;

    public int difficulty = 1;

    public List<string> ticket;
    public List<string> ingredients;

    private void Start()
    {
        CreateTicket();
        UpdateTicketList();
        CreateBurgerTicket();
    }

    private void CreateTicket()
    {
        ticket = new List<string>();
        ticket.Add("BottomBun");
        int size = Random.Range(1, difficulty + 1);
        for (int i = 0; i < size; i++)
        {
            int choice = Random.Range(0, ingredients.Count);
            ticket.Add(ingredients[choice]);
        }
        ticket.Add("TopBun");
    }

    private void UpdateTicketList()
    {
        ticketList.text = "";

        for (int i = 0;i < ticket.Count;i++)
        {
            ticketList.text += $"{ticket[i]}\n";
        }
    }

    private void CreateBurgerTicket()
    {
        burgerTicketList = new List<GameObject>();
        burgerTicketList.Add(burgerBottomBun);

        int size = Random.Range(1, difficulty + 1);
        for (int i = 0; i < size; i++)
        {
            int choice = Random.Range(0, burgerIngredientList.Count);
            burgerTicketList.Add(burgerIngredientList[choice]);
        }

        burgerTicketList.Add(burgerTopBun);
    }

    private void UpdateBurgerTicket()
    {

    }
}
