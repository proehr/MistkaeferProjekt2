using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PowerUp : MonoBehaviour
{
    [SerializeField] private PowerUpTypes powerUpType;
    [SerializeField] private MeshRenderer[] meshRenderer;
    [SerializeField] private Collider collider;
    public PowerUpTypes Type => powerUpType;

    private void OnTriggerEnter(Collider other)
    {
        meshRenderer[0].enabled = false;
        meshRenderer[1].enabled = false;
        collider.enabled = false;
    }
}
