using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    public float selfDestructDelay = 10f; // Time before the object self-destructs

    void Start()
    {
        Invoke("DestroyPrefab", selfDestructDelay);
    }

    void DestroyPrefab()
    {
        Destroy(gameObject);
    }
}

