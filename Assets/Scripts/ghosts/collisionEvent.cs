using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class collisionEvent : MonoBehaviour
{
    [SerializeField] string whatIsPlayer;
    [SerializeField] UnityEvent colide;

/*    private void FixedUpdate()
    {
        Physics.SphereCast(transform.position, transform.position,)
    }*/
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == whatIsPlayer)
        {
            colide.Invoke();
        }
    }
}
