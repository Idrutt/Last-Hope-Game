using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    Health playerHealth;

    private void Start()
    {
        playerHealth = GameObject.FindObjectOfType<Health>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == ("Player"))//or tag
        {
            print("hello");
            playerHealth.DamagePlayer(25);

        }
    }
}
