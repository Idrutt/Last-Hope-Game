using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int curHealth = 0;
    public int maxHealth = 100;

    public HealthBar healthBar;


    public Transform Player;


    public Transform respawnHere;
    public bool Isdead = false;


    public UnityEvent onDeath;
    public UnityEvent onRespawn;

    GameObject respawnButton;

    void Start()
    {
        curHealth = maxHealth;

        respawnButton = GameObject.FindWithTag("RespawnButton");
        respawnButton.SetActive(false);
    }

    void Update()
    {
       

        if (curHealth <= 0)
        {
            onDeath.Invoke();

            respawnButton.SetActive(true);
        }
    }

    public void DamagePlayer(int damage)
    {
        curHealth -= damage;

        healthBar.SetHealth(curHealth);
    }
    public void HealPlayer(int Healing)
    {

        if (curHealth <= 75)
        {
            curHealth += Healing;
        }


        healthBar.SetHealth(curHealth);
    }

    public void PlayerDied()
    {
        new WaitForSeconds(3);
        onRespawn.Invoke();
        this.transform.position = respawnHere.transform.position;
        curHealth = 100;
        healthBar.SetHealth(curHealth);
        respawnButton.SetActive(false);

    }

}