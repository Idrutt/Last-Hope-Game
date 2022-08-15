
using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int curHealth = 1;

    public float healthBarLength;

    SwordScript playerScript;

    public bool hasHit = false;

    BoxCollider2D triggerBox;
    CapsuleCollider2D CapsuleCollider;
    void Start()
    {
        CapsuleCollider = GetComponent<CapsuleCollider2D>();
        triggerBox = GetComponent<BoxCollider2D>();
        playerScript = GameObject.FindObjectOfType<SwordScript>();
        healthBarLength = Screen.width / 2;
    }
    private void Update()
    {
        if (curHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    public void DamageEnemy()
    {
        curHealth -= playerScript.PlayerDamage;

    }
    
    public void EnemyDied()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Sword") && this.hasHit == false)
        {
            this.DamageEnemy();
            this.hasHit = true;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Sword"))
        {
            this.hasHit = false;
        }

    }

   

}
