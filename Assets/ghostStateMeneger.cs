using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostStateMeneger : MonoBehaviour
{
    private ghost_input ghost_Input;

    //death
    public bool death;
    [SerializeField] Transform home;
    [SerializeField] string whatIsHome;

    //afraid
    public bool afraid;

    //onFire
    public bool onFire;

    // Start is called before the first frame update
    void Start()
    {
        ghost_Input = GetComponent<ghost_input>();
    }
    private void onChangState(float time)
    {
        if (death)
        {
            ghost_Input.arraymod2 = 3;
            StopAllCoroutines();
        }
        else if (afraid)
        {
            ghost_Input.arraymod2 = 2;
            StopAllCoroutines();
            StartCoroutine(timeAfraide(time));
        }
        else if (onFire)
        {
            ghost_Input.arraymod2 = 2;
            StopAllCoroutines();
            StartCoroutine(timeOnFier(time));
        }
    }

    public void startDeath()
    {
        death = true;
        onChangState(0f);
    }

    public void startAfraid(float time)
    {
        afraid = true;
        onChangState(time);
    }

    public void startOnFire(float time)
    {
        onFire = true;
        onChangState(time);
    }

    //kensel death
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == whatIsHome)
        {
            death = false;
            ghost_Input.arraymod2 = -1;
        }

    }

    private IEnumerator timeOnFier(float time)
    {
        yield return new WaitForSeconds(time);
        ghost_Input.arraymod2 = -1;
        onFire = false;
    }
    private IEnumerator timeAfraide(float time)
    {
        yield return new WaitForSeconds(time);
        ghost_Input.arraymod2 = -1;
        afraid = false;
    }

}

