using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class collisionEventGhost : MonoBehaviour
{
    [SerializeField] string whatIsPlayer;
    [SerializeField] UnityEvent colideNotAfraid, colideAfraid;
    [SerializeField] afraid_mode_changer isAfraid;
    [SerializeField] ghost_death death;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == whatIsPlayer)
        {
            if (!isAfraid.afraid)
            {
                colideNotAfraid.Invoke();
            }
            else
            {
                colideAfraid.Invoke();
            }
        }

    }
}
