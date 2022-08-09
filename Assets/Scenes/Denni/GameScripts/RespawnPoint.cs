using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RespawnPoint : MonoBehaviour
{
    Health Playerscript;
    [SerializeField] Transform checkpoint;

    bool istaken = false;

    // Start is called before the first frame update
    private void Start()
    {
        checkpoint = GetComponent<Transform>();

        Playerscript = GameObject.FindObjectOfType<Health>();
    }

    // Update is called once per frame
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && istaken == false)
        {

            Playerscript.respawnhere.transform.position = checkpoint.position;
            istaken = true;
        }
        
    }
}
