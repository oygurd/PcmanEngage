using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostsAnim : MonoBehaviour
{
    Animator ghostAnim;

    [SerializeField] ghost_controler1 controler;


    // Start is called before the first frame update
    void Start()
    {
        ghostAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        GhostIdleAndMove();
    }


    public void GhostIdleAndMove()
    {
        if (controler.curentDirectin == Vector3.zero)
        {
            ghostAnim.SetBool("isIdle", true);
            ghostAnim.SetBool("isMoving", false);
        }

        else
        {
            ghostAnim.SetBool("isIdle", false);
            ghostAnim.SetBool("isMoving", true);
        }
    }


    
}
