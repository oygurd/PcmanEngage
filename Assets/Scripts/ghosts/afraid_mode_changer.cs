using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class afraid_mode_changer : MonoBehaviour
{
    [SerializeField] ghost_input ghost_Input;
    [SerializeField] int active;
    [SerializeField] bool afraid;

    public void afradTernOn(float time)
    {
        StartCoroutine(afraidFor(time));
    }

    private IEnumerator afraidFor(float time)
    {
        active++;
        ghost_Input.arraymod2 = 2;
        afraid = true;
        yield return new WaitForSeconds(time);
        active--;
        if (active == 0)
        {
            ghost_Input.arraymod2 = -1;
            afraid = false;
        }
    }
}
