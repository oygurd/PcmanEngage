using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portal : MonoBehaviour
{
    [SerializeField] Transform portalEndLocashen;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "playerforportal")
        {
            other.transform.position = portalEndLocashen.position;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
