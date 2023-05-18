using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SignDam : MonoBehaviour
{
    [HideInInspector] public UnityEvent onDestroy = new UnityEvent();
    [HideInInspector] public UnityEvent onHit = new UnityEvent();
    [SerializeField] int totalHealth = 100;
    public int currentHealth;
    public GameObject SignMenu;
    private void Start()
    {
        currentHealth = totalHealth;
    }

    public void Hit(int damage)
    {
        onHit.Invoke();
        currentHealth -= damage;
        if (currentHealth <= 0)
        {


            Destroy();
            FindObjectOfType<AudioManager>().Play("Pop");
            SignMenu.SetActive(true);
        }
    }
    void Destroy()
    {
        onDestroy.Invoke();
        Destroy(gameObject);
       
    }
}
