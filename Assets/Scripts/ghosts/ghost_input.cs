using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghost_input : MonoBehaviour
{
    public Vector3 lastinput, newLastinput;
    [SerializeField] ghost_controler1 controler;
    [SerializeField] float maxDistens;
    [SerializeField] LayerMask whatIsWall;
    private float closest;
    [SerializeField] Transform[] target = new Transform[1];
    public int arraymod1, arraymod2;

    // Update is called once per frame
    void Update()
    {
        newLastinput = new Vector3(0, 0, 0);
        closest = 200;
        CheckDirecshenAndClosest(new Vector3(1, 0, 0));
        CheckDirecshenAndClosest(new Vector3(-1, 0, 0));
        CheckDirecshenAndClosest(new Vector3(0, 0, 1));
        CheckDirecshenAndClosest(new Vector3(0, 0, -1));
/*        if (newLastinput == new Vector3(0, 0, 0))
        {
            newLastinput = -lastinput;
        }*/
        lastinput = newLastinput;
    }


    private void CheckDirecshenAndClosest(Vector3 direcshen)
    {
        if (direcshen != -lastinput)
        {
            Vector3 tempWalkPoint;
            tempWalkPoint = new Vector3(transform.position.x + direcshen.x, transform.position.y, transform.position.z + direcshen.z);
            Vector3 targetNow;
            if (arraymod2 == -1)
                targetNow = target[arraymod1].position;
            else
                targetNow = target[arraymod2].position;
            if (!Physics.Raycast(transform.position, direcshen, maxDistens, whatIsWall))
            {
                if (closest > Vector3.Distance(tempWalkPoint, targetNow))
                {
                    closest = Vector3.Distance(tempWalkPoint, targetNow);
                    newLastinput = direcshen;
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, lastinput);
/*        Gizmos.DrawRay(transform.position, new Vector3(1, 0, 0));
        Gizmos.DrawRay(transform.position, new Vector3(-1, 0, 0));
        Gizmos.DrawRay(transform.position, new Vector3(0, 0, 1));
        Gizmos.DrawRay(transform.position, new Vector3(0, 0, -1));*/
    }
}
