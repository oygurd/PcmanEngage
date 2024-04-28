using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class input_player : MonoBehaviour
{
    public Vector3 lastinput;
    public bool isMultiplayer;

    // Update is called once per frame
    void Update()
    {

        float horizontal = 0f, vertical = 0f;
        if (!isMultiplayer)
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");
        }
        else
        {
            if (Input.GetKey(KeyCode.W))
                vertical = 1f;
            else if (Input.GetKey(KeyCode.S))
                vertical = -1f;

            if (Input.GetKey(KeyCode.A))
                horizontal = -1f;
            else if (Input.GetKey(KeyCode.D))
                horizontal = 1f;
        }
        if (!(horizontal == 0))
            vertical = 0;
        if (horizontal != 0 || vertical != 0)
            lastinput = new Vector3(horizontal, 0, vertical);
    }
}
