using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class input_player : MonoBehaviour
{
    public Vector3 lastinput;

    // Update is called once per frame
    void Update()
    {
        float horizontal, vertical;
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        if (!(horizontal == 0))
            vertical = 0;
        if (horizontal != 0 || vertical != 0)
            lastinput = new Vector3(horizontal, 0, vertical);
    }
}
