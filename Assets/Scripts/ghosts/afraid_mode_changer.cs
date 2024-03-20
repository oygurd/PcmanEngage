using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class afraid_mode_changer : MonoBehaviour
{
    [SerializeField] ghost_input[] ghost_Input = new ghost_input[0];
    [SerializeField] int active;
    public bool afraid;
    [SerializeField] ghost_death[] death = new ghost_death[0];

    public void afradTernOn(float time)
    {
        StartCoroutine(afraidFor(time));
    }

    private IEnumerator afraidFor(float time)
    {
        active++;
        for (int i = 0; i < ghost_Input.Length; i++)
        {
            if (!death[i].death)
                ghost_Input[i].arraymod2 = 2;
            afraid = true;
        }

        yield return new WaitForSeconds(time);
        active--;
        for (int i = 0; i < ghost_Input.Length; i++)
        {
            if (active == 0 && !death[i].death)
            {
                ghost_Input[i].arraymod2 = -1;
                afraid = false;
            }
        }
    }   
/*        active++;
        for (int i =0; i<ghost_Input.Length; i++)
        {
            ghost_Input[i].arraymod2 = 2;
            afraid = true;
        }

        yield return new WaitForSeconds(time);
        active--;
        for (int i = 0; i < ghost_Input.Length; i++)
        {
            if (active == 0)
            {
                ghost_Input[i].arraymod2 = -1;
                afraid = false;
            }
        }*/
        /*        ghost_Input.arraymod2 = 2;
                afraid = true;
                yield return new WaitForSeconds(time);
                active--;
                if (active == 0)
                {
                    ghost_Input.arraymod2 = -1;
                    afraid = false;
                }*/
    
}
