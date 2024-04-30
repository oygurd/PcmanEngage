using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerrefrens : MonoBehaviour
{
    private GameManager maneger;
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] manegerobject = GameObject.FindGameObjectsWithTag("all seans menejer");
        maneger = manegerobject[0].GetComponent<GameManager>();
    }

    public void changInGameManegerIsMultiplayerTo(bool anser)
    {
        maneger.isMultiplayer = anser;
    }
}
