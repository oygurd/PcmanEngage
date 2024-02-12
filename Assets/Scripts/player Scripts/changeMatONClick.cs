using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeMatONClick : MonoBehaviour
{
    public Material[] mat;
    public int numUp = 0;

    Renderer pacman;

    // Start is called before the first frame update
    void Start()
    {
        pacman = GetComponent<Renderer>();
        pacman.enabled = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            numUp++;
            
            if (numUp >= 5)
        {
            numUp = 0;
        }
        }

        pacman.material = mat[numUp];

        

    }
}
