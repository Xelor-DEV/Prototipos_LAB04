using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void VictoryScene()
    {
        SceneManager.LoadScene("WinResults");
    }
    public void DefeatScene()
    {
        SceneManager.LoadScene("DefeatResults");
    }
}