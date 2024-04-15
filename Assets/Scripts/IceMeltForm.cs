using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceMeltForm : MonoBehaviour
{
    Animator animations;
    // Start is called before the first frame update
    void Start()
    {
        animations = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animations.SetBool("melt", true);
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            animations.SetBool("melt", false);
            animations.SetBool("spawn", false);

        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            animations.SetBool("spawn", true);
        }
    }
}
