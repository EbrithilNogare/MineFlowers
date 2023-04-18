using UnityEngine;
using UnityEngine.SceneManagement;

[ExecuteInEditMode]
public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Main");
    }

    public void LoadCreditsScrene()
    {

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
