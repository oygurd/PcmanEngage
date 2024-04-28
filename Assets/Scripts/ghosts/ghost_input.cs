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
    public bool isMultiplayer;

    // Update is called once per frame
    void Update()
    {
        if (!isMultiplayer)
        {
            newLastinput = new Vector3(0, 0, 0);
            closest = 200;
            CheckDirecshenAndClosest(new Vector3(1, 0, 0));
            CheckDirecshenAndClosest(new Vector3(-1, 0, 0));
            CheckDirecshenAndClosest(new Vector3(0, 0, 1));
            CheckDirecshenAndClosest(new Vector3(0, 0, -1));
            if (newLastinput == new Vector3(0, 0, 0))
            {
                newLastinput = -controler.curentDirectin;
            }
            lastinput = newLastinput;
        }
        else
        {
            float horizontal = 0f, vertical = 0f;
            if (Input.GetKey(KeyCode.UpArrow))
                vertical = 1f;
            else if (Input.GetKey(KeyCode.DownArrow))
                vertical = -1f;
            if (Input.GetKey(KeyCode.LeftArrow))
                horizontal = -1f;
            else if (Input.GetKey(KeyCode.RightArrow))
                horizontal = 1f;
            if (!(horizontal == 0))
                vertical = 0;
            if (horizontal != 0 || vertical != 0)
                lastinput = new Vector3(horizontal, 0, vertical);
        }
    }
    Vector3 tempWalkPoint;

    private void CheckDirecshenAndClosest(Vector3 direcshen)
    {
        if (direcshen != -controler.curentDirectin)
        {
            tempWalkPoint = new Vector3(transform.position.x + direcshen.x * maxDistens, transform.position.y, transform.position.z + direcshen.z * maxDistens);
            Vector3 targetNow;
            if (arraymod2 == -1)
                targetNow = target[arraymod1].position;
            else
                targetNow = target[arraymod2].position;
            if (!Physics.Raycast(transform.position, direcshen , maxDistens, whatIsWall))
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
        Gizmos.color = Color.yellow;
        Gizmos.DrawCube(tempWalkPoint, new Vector3(1, 1, 1));
        /*        Gizmos.DrawRay(transform.position, new Vector3(1, 0, 0));
                Gizmos.DrawRay(transform.position, new Vector3(-1, 0, 0));
                Gizmos.DrawRay(transform.position, new Vector3(0, 0, 1));
                Gizmos.DrawRay(transform.position, new Vector3(0, 0, -1));*/
    }
}
