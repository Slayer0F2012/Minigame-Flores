using UnityEngine;

public class Merchant : MonoBehaviour
{
    public Item item1;
    public Item item2;
    public Item item3;
    public bool canBuy;

    private void Update()
    {
        if (canBuy)
        {
            SellStuff();
        }
    }
    private void SellStuff()
    {
        
            if (Inventory.instance.HasItem(item1))
            {
                Inventory.RemoveItem(item1);
                MoneyManager.instance.AddMoney(item1.price);
            }
            else if (Inventory.instance.HasItem(item2))
            {
                Inventory.RemoveItem(item2);
                MoneyManager.instance.AddMoney(item2.price);
            }
            else if (Inventory.instance.HasItem(item3))
            {
                Inventory.RemoveItem(item3);
                MoneyManager.instance.AddMoney(item3.price);
            }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            canBuy = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            canBuy = false;
    }
}
