using UnityEngine;
using UnityEngine.SceneManagement;

public class MENU : MonoBehaviour
{
    
    public void ChoiMoi()
    {
        SceneManager.LoadScene(1);
    }

    public void Pause()
    {
        Time.timeScale = 0f;
    }

    public void ThoatMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Thoat()
    {
        Application.Quit();
    }
    public void ChooseChar()
    {
        SceneManager.LoadScene(2);
    }
}
