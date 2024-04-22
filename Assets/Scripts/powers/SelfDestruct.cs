using UnityEngine;
using UnityEngine.Events;

public class SelfDestruct : MonoBehaviour
{
    [SerializeField] float selfDestructDelay, meltTime; // Time before the object self-destructs
    [SerializeField] UnityEvent melt, spown;

    void Start()
    {
        Invoke("spownAnimashen", 0);
        Invoke("meltAnimashen", selfDestructDelay - meltTime );
        Invoke("DestroyPrefab", selfDestructDelay);
    }
    void spownAnimashen()
    {
        spown.Invoke();
    }

    void meltAnimashen()
    {
        melt.Invoke();
    }

    void DestroyPrefab()
    {
        Destroy(gameObject);
    }
}

