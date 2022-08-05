using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int curHealth = 0;
    public int maxHealth = 100;
   
    public HealthBar healthBar;
  
    

    public UnityEvent onDeath;

    void Start()
    {
        curHealth = maxHealth;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            DamagePlayer(10);
        }

        if (curHealth <= 0)
        {
            onDeath.Invoke();
        }
    }

    public void DamagePlayer(int damage)
    {
        curHealth -= damage;

        healthBar.SetHealth(curHealth);
    }
    public void HealPlayer(int Healing)
    {
        curHealth += Healing;

        healthBar.SetHealth(curHealth);
    }
   


}