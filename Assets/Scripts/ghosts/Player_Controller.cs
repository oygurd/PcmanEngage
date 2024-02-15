using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    [SerializeField] LayerMask whatIsWall;
    [SerializeField] input_player inputs;
    [SerializeField] float speed, boxCastDistens;
    [SerializeField] Vector3 nextPoint, consideredNextPoint, curentDirectin, boxCastSkale;
    
    // Start is called before the first frame update
    void Start()
    {
        nextPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //if (checkIfReachDestination())
        {
            curentDirectin = ColculateNewVector3();
            nextPoint = transform.position + curentDirectin;
        }
        transform.Translate(Time.deltaTime * speed * curentDirectin);
/*        if (checkIfReachDestination())
        {
*//*            consideredNextPoint = new Vector3(transform.position.x + inputs.lastinput.x, transform.position.y, transform.position.z + inputs.lastinput.z);*//*
            //Debug.Log(consideredNextPoint);
            if (checkIfWall(consideredNextPoint))
            {
                Debug.Log("is not wall");
                nextPoint = consideredNextPoint;
                goToVector3(nextPoint);
            }
        }*/
    }

    private Vector3 ColculateNewVector3()
    {
        if (checkIfWall(inputs.lastinput))
        {
            return inputs.lastinput;
        }
        else
            if (checkIfWall(curentDirectin))
            {
                return curentDirectin;
            }
            else
                return Vector3.zero;

    }

    private void goToVector3(Vector3 target)
    {
        //transform.Translate(nextPoint - transform.position * Time.deltaTime * speed);
    }
    private bool checkIfWall(Vector3 direction)
    {
        if (!Physics.BoxCast(transform.position, boxCastSkale, direction, Quaternion.identity, boxCastDistens, whatIsWall))
        {
            return true;
        }
        return false;
        /*        if (!Physics.Raycast(transform.position, Diretin, 10f, whatIsWall))
                {
                    return true;
                }
                return false;*/
    }
    private bool checkIfReachDestination()
    {
        if (isAlmostZero(transform.position.x - nextPoint.x) && isAlmostZero(transform.position.z - nextPoint.z))
            return true;
        else
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
