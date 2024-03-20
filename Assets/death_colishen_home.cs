using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class death_colishen_home : MonoBehaviour
{
    [SerializeField] string whatIsPlayer;
    [SerializeField] UnityEvent colide;



    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == whatIsPlayer)
        {
            colide.Invoke();
        }

    }
}
