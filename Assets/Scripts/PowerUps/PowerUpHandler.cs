using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PowerUpHandler : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidbody = null;
    [SerializeField] private bool speedUp = false;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUps"))
        {
            PowerUpTypes upgradeType  = other.GetComponent<PowerUp>().Type;

            switch (upgradeType)
            {
                case PowerUpTypes.AntiGravity:
                    rigidbody.useGravity = false;
                    StartCoroutine(TurnGravityOff( 2));
                    break;
                case PowerUpTypes.SpeedDown:
                    // transform.Translate(Vector3.forward * _rigidbody.velocity.magnitude/2 * Time.deltaTime);
                    StartCoroutine(IncreaseDrag( 10, 3));
                    break;
                case PowerUpTypes.SpeedUp:
                    speedUp = true;
                    StartCoroutine(IncreaseSpeed( 10));
                    //_rigidbody.velocity.Set(_rigidbody.velocity.x * 2,_rigidbody.velocity.x * 2,_rigidbody.velocity.x * 2);
                    break;
                
            }
            
        }
    }

    private void SpeedUp()
    {
       // _rigidbody.AddForce(_rigidbody.velocity.x * 5,_rigidbody.velocity.x * 5,_rigidbody.velocity.x * 5);
       rigidbody.AddForce(Physics.gravity * (30), ForceMode.Acceleration);
    }

    private IEnumerator IncreaseSpeed(float time)
    {
        InvokeRepeating(nameof(SpeedUp),0, 0.2f);
        yield return new WaitForSeconds(time);
 
        CancelInvoke(nameof(SpeedUp));
        speedUp = false;
    }
    private IEnumerator IncreaseDrag(float time, int drag)
    {
        rigidbody.drag = drag;
        yield return new WaitForSeconds(time);
 
        rigidbody.drag = 0;
    }
    private IEnumerator TurnGravityOff(float time)
    {
        yield return new WaitForSeconds(time);
 
        rigidbody.useGravity = true;
    }
}
