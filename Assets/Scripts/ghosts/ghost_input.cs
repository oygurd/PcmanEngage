using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghost_input : MonoBehaviour
{
    public Vector3 lastinput;
    [SerializeField] ghost_controler1 controler;
    [SerializeField] float maxDistens;
    [SerializeField] LayerMask whatIsWall;
    private float closest;
    [SerializeField] Transform target;

    // Update is called once per frame
    void Update()
    {
        closest = 200;
        CheckDirecshenAndClosest(new Vector3(1, 0, 0));
        CheckDirecshenAndClosest(new Vector3(-1, 0, 0));
        CheckDirecshenAndClosest(new Vector3(0, 0, 1));
        CheckDirecshenAndClosest(new Vector3(0, 0, -1));
    }

    private void CheckDirecshenAndClosest(Vector3 direcshen)
    {
        Vector3 tempWalkPoint;
        tempWalkPoint = new Vector3(transform.position.x + direcshen.x, transform.position.y, transform.position.z + direcshen.z);
        if (!Physics.Raycast(transform.position, direcshen, maxDistens, whatIsWall))
        {
            if (closest > Vector3.Distance(tempWalkPoint, target.position))
            {
                closest = Vector3.Distance(tempWalkPoint, target.position);
                lastinput = direcshen;
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
