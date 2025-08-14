using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems; // ADDED

public class GamePauseSystem : MonoBehaviour
{
    public static bool inPausedState = false;
    private InputSystem_Actions inputSystem;
    private InputAction pause;
    public GameObject PauseMenu;

    // ADDED
    public GameObject firstSelectedMain; // first button in pause menu
    private InputActionMap uiMap;        // UI action map reference

    private void Awake()
    {
        inputSystem = new InputSystem_Actions();
        uiMap = inputSystem.UI; // reference UI map
    }

    private void OnEnable()
    {
        pause = inputSystem.Player.Pause;
        pause.Enable();
    }

    private void OnDisable()
    {
        pause.Disable();
    }

    void Update()
    {
        if (pause.WasPressedThisFrame()) //IMPORTANT!!
        {
            PauseGame();
        }
    }

    public void PauseGameNoMenu()
    {
        if (inPausedState)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void PauseGame()
    {
        inPausedState = !inPausedState;

        if (!inPausedState)
        {
            Time.timeScale = 1f; //Unpause game
            if (PauseMenu != null)
                PauseMenu.SetActive(false);

            uiMap.Disable(); // disable UI inputs
            inPausedState = false;
            Debug.Log("Game is unpaused");
        }
        else
        {
            Time.timeScale = 0f; //Pause game
            if (PauseMenu != null)
                PauseMenu.SetActive(true);

            uiMap.Enable(); // enable UI inputs

            // set first button for navigation
            if (firstSelectedMain != null)
                EventSystem.current.SetSelectedGameObject(firstSelectedMain);

            inPausedState = true;
            Debug.Log("Game is paused");
        }
    }
}
