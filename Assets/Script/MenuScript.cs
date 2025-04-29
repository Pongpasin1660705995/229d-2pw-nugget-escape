using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
}
