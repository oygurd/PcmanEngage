using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireEfect : MonoBehaviour
{
    [SerializeField] GameObject a, b;
    //[SerializeField] bool isOnFire = false;
    public void startFier(float time)
    {
        StartCoroutine(startFier1(time));
    }
    private IEnumerator startFier1(float time)
    {
        a.SetActive(true);
        b.SetActive(true);
        //isOnFire = true;
        yield return new WaitForSeconds(time);
        a.SetActive(false);
        b.SetActive(false);
        //isOnFire = false;
    }
    public void startLitning(float time)
    {
        StartCoroutine(Litning(time));
    }
    private IEnumerator Litning(float time)
    {
        a.SetActive(true);
        //isOnFire = true;
        yield return new WaitForSeconds(time);
        a.SetActive(false);
        //isOnFire = false;
    }
}
