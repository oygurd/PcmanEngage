using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationtriger : MonoBehaviour
{
    [SerializeField] Animation animaishens;
    [SerializeField] string animashenName;

    public void startanimashen()
    {
        animaishens.Play(animashenName);
    }

}
