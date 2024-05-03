using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghost_controler1 : MonoBehaviour
{
    [SerializeField] LayerMask whatIsWall;
    [SerializeField] ghost_input inputs;
    [SerializeField] float speed, regilerSpeed, slodeSpeed, boxCastDistensForwaerd, boxCastDistensNew;
    [SerializeField] int slode;
    [SerializeField] Vector3 boxCastSkale;
    public Vector3 curentDirectin = new Vector3(-1, 0, 0);
    [SerializeField] Transform gfx;
    public bool stand;

    // Update is called once per frame
    void Update()
    {
        if (stand)
        {
            curentDirectin = new Vector3(0, 0, 0);
        }
        else
        {
            curentDirectin = ColculateNewVector3();
            transform.Translate(Time.deltaTime * speed * curentDirectin);
        }
    }

    private Vector3 ColculateNewVector3()
    {
        /*        if (checkIfWall(curentDirectin, boxCastDistensForwaerd))
                {
                    return curentDirectin;
                }
                else
                    if (checkIfWall(inputs.lastinput, boxCastDistensNew))
                {
                    return inputs.lastinput;
                }
                else
                    return Vector3.zero;*/
        if (checkIfWall(inputs.lastinput, boxCastDistensNew))
        {
            gfx.rotation = Quaternion.LookRotation(inputs.lastinput);
            return inputs.lastinput;
        }
        else
        {
            if (checkIfWall(curentDirectin, boxCastDistensForwaerd))
            {
                return curentDirectin;
            }
            else
            {
                Debug.Log("is in zero");
                return Vector3.zero;
            }
        }

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

    public void slodeFor(float time)
    {
        StartCoroutine(startSlode(time));
    }
    private IEnumerator startSlode(float time)
    {
        if (slode == 0)
            speed = slodeSpeed;
        slode++;
        yield return new WaitForSeconds(time);
        slode--;
        if (slode == 0)
            speed = regilerSpeed;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, curentDirectin * boxCastDistensForwaerd);
    }
}
