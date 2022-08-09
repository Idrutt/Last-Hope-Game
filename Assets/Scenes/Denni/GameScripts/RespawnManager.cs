using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RespawnManager: MonoBehaviour
{
    public UnityEvent Respawn;

    public Transform respawnPoint;

    public Transform Player;
    
 
    public void RespawnPlayer()
    {      
       Player.position = respawnPoint.position;     
    }

    public void setSpawn()
    {
        respawnPoint.position = this.transform.position;
    }
}
