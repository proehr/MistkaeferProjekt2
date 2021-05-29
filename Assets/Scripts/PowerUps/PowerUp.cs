using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

/*
 * Contains the Type and the spawn Count of the individual PowerUp
 * Destroys PowerUp on collision
 */

public class PowerUp : MonoBehaviour
{
    [SerializeField] private PowerUpTypes powerUpType;
    [SerializeField] private int count = 0; // indicates how many times the PowerUp should be spawned
    public PowerUpTypes Type => powerUpType;
    public int Count => count;

    // on collision with player, the powerUp gets destroyed
    private void OnTriggerEnter(Collider other) 
    {
        Destroy(gameObject);
    }
}
