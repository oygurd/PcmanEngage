using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghost_controler : MonoBehaviour
{
    [SerializeField] LayerMask whatIsWall;
    [SerializeField] Transform target;
    private Vector3 NextBest;
    [SerializeField] float speed, boxCastDistensForwaerd, boxCastDistensNew;
    [SerializeField] Vector3 boxCastSkale;
    private Vector3 curentDirectin = new Vector3(1, 0, 0);

    // Update is called once per frame
    void Update()
    {
        NextBestCalculashen();
        curentDirectin = ColculateNewVector3();
        transform.Translate(Time.deltaTime * speed * curentDirectin);
        Debug.Log(curentDirectin + " curent direcshin");
    }
    private float howClose;
    private void CheckDirecshenAndClosest(Vector3 direcshen)
    {
        Vector3 tempWalkPoint;
        tempWalkPoint = new Vector3(transform.position.x + direcshen.x, transform.position.y, transform.position.z + direcshen.z);
        if (checkIfWall(tempWalkPoint, boxCastDistensNew))
        {
            if (howClose > Vector3.Distance(tempWalkPoint, target.position))
            {
                howClose = Vector3.Distance(tempWalkPoint, target.position);
                NextBest = direcshen;
            }
        }
    }
    private void NextBestCalculashen()
    {
        howClose = 200;
        CheckDirecshenAndClosest(new Vector3(1, 0, 0));
        CheckDirecshenAndClosest(new Vector3(-1, 0, 0));
        CheckDirecshenAndClosest(new Vector3(0, 0, 1));
        CheckDirecshenAndClosest(new Vector3(0, 0, -1));
        Debug.Log(NextBest + " nexbest");
    }
    private Vector3 ColculateNewVector3()
    {
        if (checkIfWall(NextBest, boxCastDistensNew))
        {
            return NextBest;
        }
        else
            if (checkIfWall(curentDirectin, boxCastDistensForwaerd))
            {
                return curentDirectin;
            }
            else
                return Vector3.zero;

    }

    private bool checkIfWall(Vector3 direction, float distens)
    {
        if (!Physics.BoxCast(transform.position, boxCastSkale, direction, Quaternion.identity, distens, whatIsWall))
        {
            return true;
        }
        return false;
    }
    private bool isAlmostZero(float a)
    {
        if (a > -0.05 && a < 0.05) return true;
        return false;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, curentDirectin);
    }
}
