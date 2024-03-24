using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mods_chase_akater : MonoBehaviour
{
    [SerializeField] ghost_input ghost_Input;
    [SerializeField] float[] timeToSwich = new float[0];
    private int curent = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(changBetwin());
    }
    private IEnumerator changBetwin()
    {
        yield return new WaitForSeconds(timeToSwich[curent]);
        if (ghost_Input.arraymod1 == 0)
            ghost_Input.arraymod1 = 1;
        else
            ghost_Input.arraymod1 = 0;
        curent++;
        if (curent < timeToSwich.Length)
            StartCoroutine(changBetwin());
    }


}
