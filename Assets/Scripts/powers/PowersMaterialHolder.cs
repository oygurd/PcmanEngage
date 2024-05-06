using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PowersMaterialHolder : MonoBehaviour
{
    [SerializeField] Material Fire, Brick, /*Ice,*/ Thunder;
    [SerializeField] Renderer Renderer1;

    private void Start()
    {
        Renderer1 = GetComponent<Renderer>();
    }

    public void changToFire()
    {
        Renderer1.material = Fire;
    }
    public void changToBrick()
    {
        Renderer1.material = Brick;
    }
/*    public void changToIce()
    {
        Renderer1.material = Ice;
    }*/
    public void changToThunder()
    {
        Renderer1.material = Thunder;
    }

}
