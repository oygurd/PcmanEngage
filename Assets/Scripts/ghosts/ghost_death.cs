using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghost_death : MonoBehaviour
{
    public bool death;
    private ghost_input ghost_Input;
    private Transform home;
    [SerializeField] string whatIsHome;

    private void Start()
    {
        GameObject home1 = GameObject.FindGameObjectWithTag(whatIsHome);
        home = home1.GetComponent<Transform>();
        ghost_Input = GetComponent<ghost_input>();
    }

    public void changToDeath()
    {
        death = true;
        ghost_Input.arraymod2 = 3;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == whatIsHome)
        {
            death = false;
            ghost_Input.arraymod2 = -1;
        }

    }
}
