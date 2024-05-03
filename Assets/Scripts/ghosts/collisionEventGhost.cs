using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class collisionEventGhost : MonoBehaviour
{
    [SerializeField] string whatIsPlayer;
    private ghostStateMeneger isAfraid;
    private ghost_death death;
    private ghostStateMeneger stateMeneger;
    private manager meneger;

    private void Start()
    {
        isAfraid = GetComponent<ghostStateMeneger>();
        death = GetComponent<ghost_death>();
        stateMeneger = GetComponent<ghostStateMeneger>();
        GameObject meneger1 = GameObject.FindGameObjectWithTag("meneger");
        meneger = meneger1.GetComponent<manager>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == whatIsPlayer)
        {
            if (!isAfraid.afraid)
            {
                meneger.playerHit();
            }
            else
            {
                //death.changToDeath();
                stateMeneger.startDeath();
            }
        }

    }
}
