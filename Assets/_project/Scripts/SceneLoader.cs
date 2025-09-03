using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    private enum SceneName { DeathScene, MainMenu, WinScene, LEVELOne, LEVELTwo, LEVELThree, LEVELFour, nullScene }
    [SerializeField] private SceneName sceneName;

    private void Awake()
    {
        if (SceneManager.GetActiveScene().name == "Death Scene")
        {
            switch (PlayerPrefs.GetString("CurrScene"))
            {
                case ("LEVEL One"):
                    sceneName = SceneName.LEVELOne;
                    break;
                case ("LEVEL Two"):
                    sceneName =SceneName.LEVELTwo;
                    break;
                case ("LEVEL Three"):
                    sceneName=SceneName.LEVELThree;
                    break;
                case ("LEVEL Four"):
                    sceneName=SceneName.LEVELFour;
                    break;
            }
        }
    }
    public void LoadScene()
    {
        switch (sceneName)
        {
            case (SceneName.WinScene):
                SceneManager.LoadScene("Win Scene");
                break;
            case (SceneName.LEVELOne):
                SceneManager.LoadScene("LEVEL One");
                break;
            case (SceneName.MainMenu):
                SceneManager.LoadScene("Main Menu");
                break;
            case (SceneName.DeathScene):
                SceneManager.LoadScene("Death Scene");
                break;
            case (SceneName.LEVELTwo):
                SceneManager.LoadScene("LEVEL Two");
                break;
            case (SceneName.LEVELThree):
                SceneManager.LoadScene("LEVEL Three");
                break;
            case (SceneName.LEVELFour):
                SceneManager.LoadScene("LEVEL Four");
                break;
        }
    }

    private void OnDisable()
    {
        if (sceneName == SceneName.DeathScene)
        {
           Scene currentscene = SceneManager.GetActiveScene();
            PlayerPrefs.SetString("CurrScene",currentscene.name);
        }
    }
}
