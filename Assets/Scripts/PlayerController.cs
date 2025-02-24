using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public static PlayerController instance;
    [SerializeField] private float velocity = 0.5f;
    [SerializeField] GameObject powerupUI;
    [SerializeField] private MoneyManager MM;

    private void Awake()
    {

        if (instance == null) instance = this;
        else Destroy(gameObject);
    }
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
    }
}