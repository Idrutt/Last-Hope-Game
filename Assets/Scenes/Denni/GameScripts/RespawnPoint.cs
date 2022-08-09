using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RespawnPoint : MonoBehaviour
{
    Health PlayerScript;

    [SerializeField] Transform checkPoint1;

    public bool istaken = false;

    private void Start()
    {
        checkPoint1 = GetComponent<Transform>();

        PlayerScript = GameObject.FindObjectOfType<Health>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && istaken == false)
        {
            PlayerScript.respawnHere.transform.position = checkPoint1.position;
            istaken = true;
        }
    }
}
