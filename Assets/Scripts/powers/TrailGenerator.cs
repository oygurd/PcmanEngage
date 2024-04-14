using UnityEngine;

public class TrailGenerator : MonoBehaviour
{
    public GameObject cubePrefab; // Reference to your 4x4 cube prefab
    public int trailLength = 10; // Number of cubes in the trail
    public float cubeSpacing = 1.0f; // Spacing between cubes
    public float trailDuration = 5.0f; // Time duration for the trail to disappear

    private float timer = 0.0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= trailDuration)
        {
            timer = 0.0f;
        }

        if (timer >= cubeSpacing)
        {
            CreateCube();
            timer = 0.0f;
        }
    }

    void CreateCube()
    {
        GameObject cube = Instantiate(cubePrefab, transform.position, Quaternion.identity);
        // Adjust position based on the current number of cubes in the trail
        cube.transform.position += transform.forward * cubeSpacing * transform.childCount;
        // Add collider if the cube doesn't have one already
        if (cube.GetComponent<Collider>() == null)
            cube.AddComponent<BoxCollider>();
        // Destroy the cube after trailDuration
        Destroy(cube, trailDuration);
    }
}
