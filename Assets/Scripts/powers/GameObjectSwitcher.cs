using UnityEngine;
using System.Collections;

public class GameObjectSwitcher : MonoBehaviour
{
    public GameObject[] firstSet;   // Array to hold the first set of game objects
    public GameObject[] secondSet;  // Array to hold the second set of game objects

    public float delayBeforeSwitch = 10f;  // Delay before switching between sets

    private Coroutine switchCoroutine;  // Coroutine reference to handle switching

    public void TriggerSwitch()
    {
        if (switchCoroutine == null)
        {
            switchCoroutine = StartCoroutine(SwitchSets());
        }
    }

    IEnumerator SwitchSets()
    {
        // Toggle between the two sets of game objects immediately
        ActivateSet(firstSet, !firstSet[0].activeSelf);
        ActivateSet(secondSet, !secondSet[0].activeSelf);

        // Wait for the specified delay
        yield return new WaitForSeconds(delayBeforeSwitch);

        // Toggle back to the original state
        ActivateSet(firstSet, !firstSet[0].activeSelf);
        ActivateSet(secondSet, !secondSet[0].activeSelf);

        switchCoroutine = null;
    }

    void ActivateSet(GameObject[] set, bool active)
    {
        foreach (GameObject obj in set)
        {
            obj.SetActive(active);
        }
    }
}
