using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mods_chase_skater_oreng : MonoBehaviour
{
    [SerializeField] ghost_input ghost_Input;
    public float sightRange;
    public bool playerInSightRange;
    public LayerMask whatIsPlayer;

    private void Update()
    {
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);

        if (playerInSightRange)
            ghost_Input.arraymod1 = 0;
        else
            ghost_Input.arraymod1 = 1;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, sightRange);
    }
}
