using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireEfect : MonoBehaviour
{
    [SerializeField] GameObject a, b;
    [SerializeField] bool isOnFire = false;
    public void startFier(float time)
    {
        Debug.Log("enterd");
        StartCoroutine(startFier1(time));
    }
    private IEnumerator startFier1(float time)
    {
        Debug.Log("start");
        a.SetActive(true);
        b.SetActive(true);
        isOnFire = true;
        yield return new WaitForSeconds(time);
        a.SetActive(false);
        b.SetActive(false);
        isOnFire = false;
        Debug.Log("end");
    }
}
