using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    [SerializeField] private float velocity = 0.5f;

    [SerializeField] private MoneyManager MM;


    void FixedUpdate()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        this.transform.position += movement * velocity;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Item")
        {
            Interactable interactable = other.GetComponent<Interactable>();
            Debug.Log(interactable != null);
            if (interactable != null)
            {
                interactable.Interact();
            }
        }
        else if (other.tag == "Coin")
        {
            MM.AddMoney(5);
            Destroy(other.gameObject);
        }
        else if (other.tag == "Super Coin")
        {
            MM.AddMoney(25);
            Destroy(other.gameObject);
        }
        else if (other.tag == "Lose") 
        {
            MM.LoseMoney();
            Destroy(other.gameObject);
        }
    }
}