using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class point : MonoBehaviour
{
    //regiler point
    [SerializeField] GameObject pointRegiler;

    //power ups and rerety
    [SerializeField] GameObject[] powerUps = new GameObject[2];

    //setings
    [SerializeField] float delay;
    [SerializeField] int frequency;
    [SerializeField] int powerUpRarity;

    //in class valus
    private float delayCurent;

    private void Start()
    {
        delayCurent = delay;
    }

    // Update is called once per frame
    void Update()
    {
        if (delayCurent >= 0)
        {
            delayCurent -= Time.deltaTime;
            return;
        }
        else
        {
            //Do Something after delay hits 0
            int random1 = Random.Range(1, frequency);
            if (random1 == 1) cratePickUp();
            else delayCurent = 1;
        }
        //Do Something else while delay counting down
    }

    private void cratePickUp()
    {
        int random2 = Random.Range(1, powerUpRarity);
        if (random2 > 1)
            Instantiate(pointRegiler, transform.position, Quaternion.identity);
        else
        {
            spownPowerUp();
        }
        Destroy(gameObject);
    }

    private void spownPowerUp()
    {
        int random3 = Random.Range(0, powerUps.Length);
        Instantiate(powerUps[random3], transform.position, Quaternion.identity);
    }

}