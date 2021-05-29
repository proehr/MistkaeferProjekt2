using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class PowerUpHandler : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidbody = null;
    [SerializeField] private int powerUpDuration = 5;
    [SerializeField] private TextMeshProUGUI powerUpUIText;
    
    private void Start()
    {
        SetUpState.OnEnterSetUpEvent += ResetEffects;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUps"))   // if player picks-up a power up
        {
            PowerUpTypes upgradeType  = other.GetComponent<PowerUp>().Type;
            powerUpUIText.text = upgradeType.ToString(); // set ui text
            
            switch (upgradeType)
            {
                case PowerUpTypes.AntiGravity:  
                    StartCoroutine(TurnGravityOff( powerUpDuration/2));
                    break;
                case PowerUpTypes.SpeedDown:
                    StartCoroutine(IncreaseDrag( powerUpDuration, 3));
                    break;
                case PowerUpTypes.SpeedUp:
                    StartCoroutine(IncreaseSpeed( powerUpDuration));
                    break;
            }
        }
    }
    // called on game over
    public void ResetEffects()  
    {
        rigidbody.useGravity = true;
        CancelInvoke(nameof(SpeedUp));
        rigidbody.drag = 0;
        ResetUI();
    }
    
    // increases the drag on the player's rigidbody for a giving time
    private IEnumerator IncreaseDrag(float time, int drag)
    {
        rigidbody.drag = drag;
        yield return new WaitForSeconds(time);
 
        rigidbody.drag = 0;
        ResetUI();
    }
    
    // turns off the players gravity, allowing for jumps over holes or walls 
    private IEnumerator TurnGravityOff(float time)
    {
        rigidbody.useGravity = false;
        yield return new WaitForSeconds(time);
 
        rigidbody.useGravity = true;
        ResetUI();
    }
    
    // increases the players speed for a certain amount of time 
    private IEnumerator IncreaseSpeed(float time)
    {
        InvokeRepeating(nameof(SpeedUp),0, 0.2f); // calls SpeedUp every 0.2 seconds
        yield return new WaitForSeconds(time);
 
        CancelInvoke(nameof(SpeedUp)); 
        ResetUI();
    }
    
    // accelerates the player
    private void SpeedUp()
    {
        rigidbody.AddForce(Physics.gravity * (20), ForceMode.Acceleration);
    }

    private void ResetUI()
    {
        powerUpUIText.text = "";
    }

}
