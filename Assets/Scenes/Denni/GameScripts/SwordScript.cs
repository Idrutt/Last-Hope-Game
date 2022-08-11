using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SwordScript : MonoBehaviour
{
    public Animator animator;
    public float attackTime;
    public float startTimeAttack;
    public Transform attackLocation;
    public float attackRange;
    public LayerMask enemies;
    private void Start()
    {
        
    }
    void Update()
    {
        if (attackTime <= 0)
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
               
                
                 SwordSwing();
                
                Collider2D[] damage = Physics2D.OverlapCircleAll(attackLocation.position, attackRange, enemies);
                for (int i = 0; i < damage.Length; i++)
                {
                    Destroy(damage[i].gameObject);
                }

            }
            attackTime = startTimeAttack;
        }
        else
        {
            attackTime -= Time.deltaTime;
           
        }
    }




    void SwordSwing()
    {
        animator.SetTrigger("SwingSword");  //det här spelar animationen en gång
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackLocation.position, attackRange);
    }
}