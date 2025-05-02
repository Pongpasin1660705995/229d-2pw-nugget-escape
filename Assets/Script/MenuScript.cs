using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("GamePlay");
    }

    public void SettingMenuOpen()
    {
        SceneManager.LoadScene("Setting Menu");
    }

    public void MainMenuOpen()
    {
        SceneManager.LoadScene("Main Menu");
    }
    
    public void ExitGame()
    {
        Application.Quit();
    }

    public void CreditsOpen()
    {
        SceneManager.LoadScene("End Credit");
    }
}
