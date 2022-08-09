using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactible : MonoBehaviour
{
    public UnityEvent OnEnter;
    public UnityEvent OnExit;

    public UnityEvent RespawnPoint;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            OnEnter.Invoke();
        }
        if (collision.CompareTag("Respawn"))
        {
            RespawnPoint.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            OnExit.Invoke();
        }
    }


}
