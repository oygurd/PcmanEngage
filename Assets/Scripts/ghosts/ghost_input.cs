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
        if (newLastinput == -lastinput)
        {
            check(newLastinput);
/*            newLastinput = -lastinput;
            Debug.Log("back");*/
        }
        lastinput = newLastinput;

        /*        newLastinput = new Vector3(0, 0, 0);
                Vector3 curentOpesitDirecshen = opisitVector3();
                closest = 200;
                if (!(curentOpesitDirecshen == new Vector3(1, 0, 0)))
                    CheckDirecshenAndClosest(new Vector3(1, 0, 0));
                if (!(curentOpesitDirecshen == new Vector3(-1, 0, 0)))
                    CheckDirecshenAndClosest(new Vector3(-1, 0, 0));
                if (!(curentOpesitDirecshen == new Vector3(0, 0, 1)))
                    CheckDirecshenAndClosest(new Vector3(0, 0, 1));
                if (!(curentOpesitDirecshen == new Vector3(0, 0, -1)))
                    CheckDirecshenAndClosest(new Vector3(0, 0, -1));
                if (newLastinput == Vector3.zero)
                {
                    CheckDirecshenAndClosest(curentOpesitDirecshen);
                    Debug.Log("back");
                }
                lastinput = newLastinput;*/
    }

    private void check(Vector3 direcshen)
    {
        closest = 100;
        if (direcshen != new Vector3(1, 0, 0))
        {
            CheckDirecshenAndClosest(new Vector3(1, 0, 0));
        }
        if (direcshen != new Vector3(-1, 0, 0))
        {
            CheckDirecshenAndClosest(new Vector3(-1, 0, 0));
        }
        if (direcshen != new Vector3(0, 0, 1))
        {
            CheckDirecshenAndClosest(new Vector3(0, 0, 1));
        }
        if (direcshen != new Vector3(0, 0, -1))
        {
            CheckDirecshenAndClosest(new Vector3(0, 0, -1));
        }
        if (closest == 100)
        {
            newLastinput = direcshen;
        }
    }

    private void CheckDirecshenAndClosest(Vector3 direcshen)
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
                //if (direcshen != -lastinput)
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
