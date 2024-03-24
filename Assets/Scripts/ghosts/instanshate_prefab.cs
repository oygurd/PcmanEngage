using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instanshate_prefab : MonoBehaviour
{
    [SerializeField] GameObject spone;


    public void instanshiatPrefabInMyLocashen()
    {
        Instantiate(spone, transform.position, Quaternion.identity);
    }
}
