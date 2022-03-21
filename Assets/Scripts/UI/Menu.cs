using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().name == "GameScene")
        {
            SceneTransition.SwitchToScene("MenuScene");
        }
    }

    public void GoToGame()
    {
        SceneTransition.SwitchToScene("GameScene");
    }
}
