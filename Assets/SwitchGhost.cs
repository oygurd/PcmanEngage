using UnityEngine;

public class SwitchGhost : MonoBehaviour
{
    private ghost_input[] ghosts; // Array to hold references to the Ghost_input scripts
    private int currentGhostIndex = 0; // Index of the currently active ghost
    [SerializeField] bool switchActive = false;
    private GameObject[] indicator = new GameObject[0];

    void Start()
    {
        // Find all GameObjects with Ghost_input script
        GameObject[] ghostObjects = GameObject.FindGameObjectsWithTag("Ghost");
        ghosts = new ghost_input[ghostObjects.Length];

        // Get references to Ghost_input scripts
        for (int i = 0; i < ghostObjects.Length; i++)
        {
            ghosts[i] = ghostObjects[i].GetComponent<ghost_input>();
        }

        // Find all GameObjects with Ghost_input script
        indicator = GameObject.FindGameObjectsWithTag("indicator");

    }

    void Update()
    {
        // Check if switching functionality is active
        if (!switchActive)
            return;

        // Switch ghosts using Q key or number keys (1, 2, 3, 4)
        if (Input.GetKeyDown(KeyCode.Q))
        {
            // Increment the index to switch to the next ghost
            currentGhostIndex = (currentGhostIndex + 1) % ghosts.Length;
            ActivateGhost(currentGhostIndex);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ActivateGhost(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && ghosts.Length >= 2)
        {
            ActivateGhost(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && ghosts.Length >= 3)
        {
            ActivateGhost(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4) && ghosts.Length >= 4)
        {
            ActivateGhost(3);
        }
    }

    void ActivateGhost(int index)
    {
        // Deactivate all ghosts
        for (int i = 0; i < ghosts.Length; i++)
        {
            ghosts[i].isMultiplayer = false;
            indicator[i].SetActive(false);
        }

        // Activate the ghost at the specified index
        ghosts[index].isMultiplayer = true;
        indicator[index].SetActive(true);
    }

    [SerializeField] input_player inputPlayer;
    public void ToggleSwitching(bool active)
    {
        switchActive = active;
        ActivateGhost(currentGhostIndex);
        inputPlayer.isMultiplayer = true;
    }
}
