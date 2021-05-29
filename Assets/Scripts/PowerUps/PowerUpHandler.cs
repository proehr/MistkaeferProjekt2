using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
/*
 * Handles the applying of power-up's effects and the power-up effect indicator UI
 */
public class PowerUpHandler : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidbody = null;
    [SerializeField] private int powerUpDuration = 5;
    [SerializeField] private TextMeshProUGUI powerUpUIText;
    
    private String antiGravityText = "";
    private String speedUDownText = "";
    private String speedUpText = "";
    
    private void Start()
    {
        SetUpState.OnEnterSetUpEvent += ResetEffects; // ResetEffects is called everytime the SetUpState is entered
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUps"))   // if player picks-up a power-up
        {
            PowerUpTypes upgradeType  = other.GetComponent<PowerUp>().Type; // get power-up type
            
            switch (upgradeType)
            {
                case PowerUpTypes.AntiGravity:
                    StartCoroutine(TurnGravityOff(powerUpDuration/2));
                    break;
                case PowerUpTypes.SpeedDown:
                    StartCoroutine(IncreaseDrag(powerUpDuration, 3));
                    break;
                case PowerUpTypes.SpeedUp:
                    StartCoroutine(IncreaseSpeed(powerUpDuration));
                    break;
            }
        }
    }
    // called on game over
    public void ResetEffects()  
    {
        // reverts any possibly active effects
        rigidbody.useGravity = true;
        CancelInvoke(nameof(SpeedUp));
        rigidbody.drag = 0;
        
        // reset UI text
        antiGravityText = "";
        speedUDownText = "";
        speedUpText = "";
        SetUI();
    }
        
    // turns off the players gravity, allowing for jumps over holes or walls 
    private IEnumerator TurnGravityOff(float time)
    {
        rigidbody.useGravity = false;
        antiGravityText = "AntiGravity \n\n";
        SetUI();
        yield return new WaitForSeconds(time);
 
        rigidbody.useGravity = true;
        antiGravityText = "";
        SetUI();
    }

    // increases the drag on the player's rigidbody, slowing him down
    private IEnumerator IncreaseDrag(float time, int drag)
    {
        rigidbody.drag = drag;
        speedUDownText = "SpeedDown \n\n";
        SetUI();
        yield return new WaitForSeconds(time);
 
        rigidbody.drag = 0;
        speedUDownText = "";
        SetUI();
    }

    // increases the players speed for a certain amount of time 
    private IEnumerator IncreaseSpeed(float time)
    {
        speedUpText = "SpeedUp";
        SetUI();
        InvokeRepeating(nameof(SpeedUp),0, 0.2f); // calls SpeedUp every 0.2 seconds
        yield return new WaitForSeconds(time);
 
        CancelInvoke(nameof(SpeedUp)); 
        speedUpText = "";
        SetUI();
    }
    
    // accelerates the player
    private void SpeedUp()
    {
        rigidbody.AddForce(Physics.gravity * (20), ForceMode.Acceleration);
    }

    // Updates the PowerUp-UI -> displaying all active effects
    private void SetUI()
    {
        powerUpUIText.text = antiGravityText + speedUDownText + speedUpText;
    }
}
