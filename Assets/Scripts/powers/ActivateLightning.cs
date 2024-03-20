using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class ActivateLightning : MonoBehaviour
{
    [SerializeField] VisualEffect lightning;


    public void playLightningBolt()
    {
        //lightning.Play();
        lightning.SendEvent("onPlayBolt");
    }
}
