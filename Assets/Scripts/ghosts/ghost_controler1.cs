using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghost_controler1 : MonoBehaviour
{
    [SerializeField] LayerMask whatIsWall;
    [SerializeField] ghost_input inputs;
    [SerializeField] float speed, boxCastDistensForwaerd, boxCastDistensNew;
    [SerializeField] Vector3 boxCastSkale;
    private Vector3 curentDirectin = new Vector3(-1, 0, 0);

    // Update is called once per frame
    void Update()
    {
        curentDirectin = ColculateNewVector3();
        transform.Translate(Time.deltaTime * speed * curentDirectin);
    }

    private Vector3 ColculateNewVector3()
    {
        if (checkIfWall(curentDirectin, boxCastDistensForwaerd))
        {
            return curentDirectin;
        }
        else
            if (checkIfWall(inputs.lastinput, boxCastDistensNew))
        {
            return inputs.lastinput;
        }
        else
            return Vector3.zero;
        /*        if (checkIfWall(inputs.lastinput, boxCastDistensNew))
                {
                    return inputs.lastinput;
                }
                else
                    if (checkIfWall(curentDirectin, boxCastDistensForwaerd))
                    {
                        return curentDirectin;
                    }
                    else
                        return Vector3.zero;*/

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
