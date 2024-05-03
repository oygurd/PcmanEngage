using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class collisionEventGhost : MonoBehaviour
{
    [SerializeField] string whatIsPlayer;
    private ghostStateMeneger menegerState;
    private ghostStateMeneger stateMeneger;
    private manager meneger;

    private void Start()
    {
        menegerState = GetComponent<ghostStateMeneger>();
        stateMeneger = GetComponent<ghostStateMeneger>();
        GameObject meneger1 = GameObject.FindGameObjectWithTag("meneger");
        meneger = meneger1.GetComponent<manager>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == whatIsPlayer)
        {
            Debug.Log(!menegerState.afraid);
            if (!menegerState.afraid && !menegerState.death && !menegerState.onFire)
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
