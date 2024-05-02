
//pointMeneger

using UnityEngine;
using System;
using System.Collections.Generic;

public class pointMeneger : MonoBehaviour
{
    [Serializable]
    public class PrefabInfo
    {
        public GameObject prefab;
        public int min, maxExtra;
        //public int minAmount;
        [Range(0, 1)]
        public float extraChance;
    }

    [SerializeField] List<PrefabInfo> prefabList;
    [SerializeField] GameObject defaultPrefab;

    [SerializeField] List<Transform> locations;

    void Start()
    {
        // Find all objects with the "PointLocation" tag and store their transforms
        GameObject[] pointLocationObjects = GameObject.FindGameObjectsWithTag("PointLocation");
        locations = new List<Transform>();
        foreach (GameObject obj in pointLocationObjects)
        {
            locations.Add(obj.transform);
        }

        int listStartCount = locations.Count;

        // Instantiate prefabs at each location
        for (int i = 0; i < listStartCount; i++)
        {
            Debug.Log("Before removal: " + locations.Count);
            InstantiatePrefabAtLocation();
        }
    }

    private int curentPrefabNumber = 0;

    void InstantiatePrefabAtLocation()
    {
        GameObject prefabToInstantiate = defaultPrefab;

        if(curentPrefabNumber < prefabList.Count)
        {
            if (prefabList[curentPrefabNumber].min > 0)
            {
                prefabToInstantiate = prefabList[curentPrefabNumber].prefab;
                prefabList[curentPrefabNumber].min--;
            }
            else
            {
                prefabList[curentPrefabNumber].maxExtra--;
                if (prefabList[curentPrefabNumber].maxExtra >= 0 && UnityEngine.Random.value < prefabList[curentPrefabNumber].extraChance)
                {
                    prefabToInstantiate = prefabList[curentPrefabNumber].prefab;
                }
                if (prefabList[curentPrefabNumber].maxExtra == 0)
                    curentPrefabNumber++;
            }

            /*            else if (prefabList[curentPrefabNumber].maxExtra > 0 && UnityEngine.Random.value < prefabList[curentPrefabNumber].extraChance)
                        {
                            prefabToInstantiate = prefabList[curentPrefabNumber].prefab;
                            prefabList[curentPrefabNumber].maxExtra--;
                            if (prefabList[curentPrefabNumber].maxExtra == 0)
                                curentPrefabNumber++;
                            return;
                        }
                        else
                            prefabList[curentPrefabNumber].maxExtra--;*/
        }
        Transform locationToFill = locations[UnityEngine.Random.Range(0, locations.Count)];
        //Debug.Log("Before removal: " + locations.Count);
        locations.Remove(locationToFill);
        //Debug.Log("After removal: " + locations.Count);
        Instantiate(prefabToInstantiate, locationToFill.position, locationToFill.rotation);



        // Instantiate prefabs at each location
        /*        for (int i = 0; i < listStartCount; i++)
                {
                    Debug.Log("enterd");
                    float prefabListStartMax = prefabList[i].minToMax.y;
                    for (int z = 0; z < prefabListStartMax; z++)
                    {
                        // Check if the minimum amount of this prefab has been reached
                        if (prefabList[z].minToMax.x > 0)
                        {
                            prefabToInstantiate = prefabList[z].prefab;
                            prefabList[z].minToMax.x--;
                            break;
                        }
                        // Check if there's a chance for extra instances of this prefab
                        else if (UnityEngine.Random.value < prefabList[z].extraChance)
                        {
                            prefabToInstantiate = prefabList[z].prefab;
                            break;
                        }
                    }
                }*/





        /*
                // Choose a random prefab from prefabList
                GameObject prefabToInstantiate = defaultPrefab;
                foreach (PrefabInfo prefabInfo in prefabList)
                {
                    // Check if the minimum amount of this prefab has been reached
                    if (prefabInfo.minAmount > 0)
                    {
                        prefabToInstantiate = prefabInfo.prefab;
                        prefabInfo.minAmount--;
                        break;
                    }
                    // Check if there's a chance for extra instances of this prefab
                    else if (UnityEngine.Random.value < prefabInfo.extraChance)
                    {
                        prefabToInstantiate = prefabInfo.prefab;
                        break;
                    }
                }

                // Instantiate the chosen prefab at the current location
                Instantiate(prefabToInstantiate, location.position, location.rotation);*/
    }
}
