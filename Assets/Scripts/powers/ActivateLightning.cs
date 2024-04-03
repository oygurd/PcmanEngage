using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class ActivateLightning : MonoBehaviour
{
    [SerializeField] Animator distortion; //activates global volume to add more effects
    [SerializeField] VisualEffect lightning;
    public bool pressed = false;


    private void Update()
    {
        playLightningBolt();
    }

    public void playLightningBolt()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            lightning.SendEvent("onPlayBolt");
            pressed = true;
            distortion.SetBool("Distortion", true);

        }
        

    }

        
}
