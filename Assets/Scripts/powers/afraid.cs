using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class afraid : MonoBehaviour
{
    [SerializeField] Transform a, b;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = a.position - b.position;
    }
}
