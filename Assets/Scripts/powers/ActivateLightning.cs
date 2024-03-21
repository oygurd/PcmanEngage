using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class ActivateLightning : MonoBehaviour
{
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
        }

    }
}
