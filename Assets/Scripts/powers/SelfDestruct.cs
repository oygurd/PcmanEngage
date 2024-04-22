using UnityEngine;
using UnityEngine.Events;

public class SelfDestruct : MonoBehaviour
{
    [SerializeField] float selfDestructDelay, meltTime; // Time before the object self-destructs
    [SerializeField] UnityEvent melt;

    void Start()
    {
        Invoke("meltAnimashen", selfDestructDelay - meltTime );
        Invoke("DestroyPrefab", selfDestructDelay);
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

