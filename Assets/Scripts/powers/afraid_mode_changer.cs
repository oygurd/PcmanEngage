using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class afraid_mode_changer : MonoBehaviour
{
    private ghost_input[] ghostsInputs;
    private ghost_death[] ghostsDeath;
    [SerializeField] int active;
    public bool afraid;

    private void Start()
    {
        // Find all GameObjects with Ghost_input script
        GameObject[] ghostObjects = GameObject.FindGameObjectsWithTag("Ghost");
        ghostsInputs = new ghost_input[ghostObjects.Length];
        ghostsDeath = new ghost_death[ghostObjects.Length];

        // Get references to Ghost_input scripts
        for (int i = 0; i < ghostObjects.Length; i++)
        {
            ghostsInputs[i] = ghostObjects[i].GetComponent<ghost_input>();
            ghostsDeath[i] = ghostObjects[i].GetComponent<ghost_death>();
        }
    }

    public void afradTernOn(float time)
    {
        StartCoroutine(afraidFor(time));
    }

    private IEnumerator afraidFor(float time)
    {
        active++;
        for (int i = 0; i < ghostsInputs.Length; i++)
        {
            if (!ghostsDeath[i].death)
                ghostsInputs[i].arraymod2 = 2;
            afraid = true;
        }

        yield return new WaitForSeconds(time);
        active--;
        for (int i = 0; i < ghostsInputs.Length; i++)
        {
            if (active == 0 && !ghostsDeath[i].death)
            {
                ghostsInputs[i].arraymod2 = -1;
                afraid = false;
            }
        }
    }   
    
}
