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
    [SerializeField] int pointsOnDefe;
    private AudioSource audioSource;

    private void Start()
    {
        menegerState = GetComponent<ghostStateMeneger>();
        stateMeneger = GetComponent<ghostStateMeneger>();
        audioSource = GetComponent<AudioSource>();
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
                audioSource.Play();
            }
            else
            {
                //death.changToDeath();
                stateMeneger.startDeath();
                meneger.AddPoints(pointsOnDefe);
            }
        }

    }
}
