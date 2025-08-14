using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; // ADDED

public class PauseMenu : MonoBehaviour
{
    public GameObject MainPauseMenu;
    public GameObject PauseOptionsMenu;

    // ADDED
    public GameObject firstSelectedMain;     // Resume button
    public GameObject firstSelectedOptions;  // Options menu first button
    private EventSystem eventSystem;         // reference to EventSystem

    private void Awake()
    {
        eventSystem = EventSystem.current; // initialize EventSystem
    }

    private void OnEnable()
    {
        MainPauseMenu.SetActive(true);
        PauseOptionsMenu.SetActive(false);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // automatically select first button for keyboard/gamepad
        if (firstSelectedMain != null)
            eventSystem.SetSelectedGameObject(firstSelectedMain);
    }

    private void OnDisable()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // clear selection
        eventSystem.SetSelectedGameObject(null);
    }

    // switch to options menu
    public void OpenOptions()
    {
        MainPauseMenu.SetActive(false);
        PauseOptionsMenu.SetActive(true);

        if (firstSelectedOptions != null)
            eventSystem.SetSelectedGameObject(firstSelectedOptions);
    }

    // switch back to main menu
    public void BackToMain()
    {
        PauseOptionsMenu.SetActive(false);
        MainPauseMenu.SetActive(true);

        if (firstSelectedMain != null)
            eventSystem.SetSelectedGameObject(firstSelectedMain);
    }
}
