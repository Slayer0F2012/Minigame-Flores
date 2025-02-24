using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int amountToAdd = 5;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            MoneyManager.instance.AddMoney(amountToAdd);
            Destroy(gameObject);
        }
    }
}
