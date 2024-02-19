using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shadersManager : MonoBehaviour
{
    [Header("Materials")]
    [SerializeField] Material normalAndHit;


    Renderer materialsRend;



    // Start is called before the first frame update
    void Start()
    {
        materialsRend = GetComponent<Renderer>();
        materialsRend.enabled = true;

    }

    // Update is called once per frame
    void Update()
    {
        
    }



}
