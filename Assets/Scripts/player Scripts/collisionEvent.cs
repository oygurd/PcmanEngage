using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class collisionEvent : MonoBehaviour
{
    [SerializeField] string whatIsPlayer;
    [SerializeField] UnityEvent colide;
    //[SerializeField] GameObject pointSponer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == whatIsPlayer)
        {
            colide.Invoke();
            //Instantiate(pointSponer, other.transform.position, Quaternion.identity);
            other.transform.position = new Vector3(0, -7, 0);
        }
    }
}
