using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostStateMeneger : MonoBehaviour
{
    private ghost_input ghost_Input;
    private ghost_controler1 controler;
    [SerializeField] GameObject lookDefolt;

    //death
    public bool death;
    [SerializeField] Transform home;
    [SerializeField] string whatIsHome;
    [SerializeField] GameObject lookDeath;

    //afraid
    public bool afraid;
    [SerializeField] GameObject lookAfraid;

    //onFire
    public bool onFire;
    [SerializeField] GameObject lookOnFire;

    // Start is called before the first frame update
    void Start()
    {
        ghost_Input = GetComponent<ghost_input>();
        controler = GetComponent<ghost_controler1>();
    }
    private void onChangState(float time)
    {
        if (death)
        {
            ghost_Input.arraymod2 = 3;
            StopAllCoroutines();
            lookTernOfAll();
            lookDeath.SetActive(true);
            onFire = false;
            afraid = false;
        }
        else if (afraid)
        {
            ghost_Input.arraymod2 = 2;
            StopAllCoroutines();
            StartCoroutine(timeAfraide(time));
            lookTernOfAll();
            lookAfraid.SetActive(true);
            onFire = false;
        }
        else if (onFire)
        {
            ghost_Input.arraymod2 = 2;
            StopAllCoroutines();
            StartCoroutine(timeOnFier(time));
            lookTernOfAll();
            lookOnFire.SetActive(true);
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
        controler.slodeFor(time);
    }

    public void startOnFire(float time)
    {
        onFire = true;
        onChangState(time);
        controler.slodeFor(time);
    }

    //kensel death
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == whatIsHome)
        {
            death = false;
            ghost_Input.arraymod2 = -1;
            lookTernOfAll();
            lookDefolt.SetActive(true);
        }

    }

    private IEnumerator timeOnFier(float time)
    {
        yield return new WaitForSeconds(time);
        ghost_Input.arraymod2 = -1;
        onFire = false;
        lookTernOfAll();
        lookDefolt.SetActive(true);
    }
    private IEnumerator timeAfraide(float time)
    {
        yield return new WaitForSeconds(time);
        ghost_Input.arraymod2 = -1;
        afraid = false;
        lookTernOfAll();
        lookDefolt.SetActive(true);
    }

    private void lookTernOfAll()
    {
        lookDeath.SetActive(false);
        lookAfraid.SetActive(false);
        lookOnFire.SetActive(false);
        lookDefolt.SetActive(false);
    }



}

