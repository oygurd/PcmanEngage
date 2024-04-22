using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class icePointInstanshiat : MonoBehaviour
{
    [SerializeField] GameObject iceCubePrefab;

    public void instansiatePrefab()
    {
       Instantiate(iceCubePrefab, transform.position, Quaternion.identity);
    }
}
