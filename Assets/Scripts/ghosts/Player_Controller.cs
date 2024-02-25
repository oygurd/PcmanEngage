using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    [SerializeField] LayerMask whatIsWall;
    [SerializeField] input_player inputs;
    [SerializeField] float speed, boxCastDistensForwaerd, boxCastDistensNew;
    [SerializeField] Vector3 boxCastSkale;
    private Vector3 curentDirectin;
    [SerializeField] Transform gfx;

    // Update is called once per frame
    void Update()
    {
        curentDirectin = ColculateNewVector3();
        transform.Translate(Time.deltaTime * speed * curentDirectin);
    }

    private Vector3 ColculateNewVector3()
    {
        if (checkIfWall(inputs.lastinput, boxCastDistensNew))
        {
            gfx.rotation = Quaternion.LookRotation(inputs.lastinput);
            return inputs.lastinput;
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
