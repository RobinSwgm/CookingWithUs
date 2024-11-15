using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Tickets : MonoBehaviour
{
    public GameObject burgerBottomBunImage;
    public GameObject burgerTopBunImage;
    public GameObject burgerMeatImage;

    public int difficulty = 1;

    public List<string> ticket;
    public List<string> ingredients;

    private void Start()
    {
        CreateTicket();
    }

    private void CreateTicket()
    {
        ticket = new List<string>();
        ticket.Add("BottomBun");
        int size = Random.Range(1, difficulty);
        for (int i = 0; i < size; i++)
        {
            int choice = Random.Range(0, ingredients.Count);
            ticket.Add(ingredients[choice]);
            Debug.Log(choice);
        }
        ticket.Add("TopBun");

        if (ticket[0] == "BottomBun" && ticket[1] == "BurgerMeat" && ticket[ticket.Count - 1] == "TopBun")
        {
            burgerBottomBunImage.SetActive(true);
            burgerMeatImage.SetActive(true);
            burgerTopBunImage.SetActive(true);
        }
    }
}
