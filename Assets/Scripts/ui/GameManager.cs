using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isMultiplayer = false;
    [Range (0,1)]
    [SerializeField] float musicVolume, efectsVolume;

    void Awake()
    {
        // אין להשמיד את האובייקט הזה בזמן טעינת סצנות חדשות
        DontDestroyOnLoad(gameObject);
    }

/*    public void isMultyplayerSetTo(bool anser)
    {
        isMultiplayer = anser;
    }*/
}
