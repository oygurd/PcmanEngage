using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghost_death : MonoBehaviour
{
    public bool death;
    [SerializeField] ghost_input ghost_Input;
    [SerializeField] Transform home;
    [SerializeField] string whatIsPlayer;


/*    // Update is called once per frame
    void Update()
    {
        if (transform.position == home.position)
        {
            death = false;
            ghost_Input.arraymod2 = -1;
        }
    }*/
    public void changToDeath()
    {
        death = true;
        ghost_Input.arraymod2 = 3;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == whatIsPlayer)
        {
            death = false;
            ghost_Input.arraymod2 = -1;
        }

    }
}
