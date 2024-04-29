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
        if (Input.GetKeyDown(KeyCode.D))
        {
            animations.SetBool("melt", true);
            animations.SetBool("static", false);

        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            animations.SetBool("melt", false);
            animations.SetBool("spawn", false);
            animations.SetBool("static", true);

        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            animations.SetBool("spawn", true);
            animations.SetBool("static", false);

        }
    }

    public void startMelt()
    {
        animations.SetBool("melt", true);
        animations.SetBool("static", false);
    }
    public void startSpown()
    {
        animations.SetBool("spawn", true);
        animations.SetBool("static", false);
    }
}
